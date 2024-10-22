﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

namespace UnityEditor.GameFoundation
{
    /// <summary>
    /// A GUI control for adding/removing/editing details on anything that inherits GameItemDefinition.
    /// </summary>
    internal static class DetailEditorGUI
    {
        private static GUIContent s_DetailDefinitionsLabel = new GUIContent("Detail Definitions", "Detail definitions extend the information that is attached to a given definition.");
        private static GUIContent s_InheritedDetailDefinitionsLabel = new GUIContent("Inherited Detail Definitions", "Inherited detail definitions are attached to the Reference Definition and inherited by the current item. They extend the information that is attached to the current item, but can be overridden by attaching the same type of detail to the current item.");

        static BaseDetailDefinition m_detailDefinitionToRemove;

        /// <summary>
        /// Uses Unity GUI and GUILayout calls to draw a detail manager in a custom editor window.
        /// </summary>
        /// <param name="gameItemDefinition">The GameItemDefinition for which the Detail definitions are to be managed.</param>
        public static void DrawDetailView(GameItemDefinition gameItemDefinition)
        {
            EditorGUILayout.LabelField(s_DetailDefinitionsLabel, GameFoundationEditorStyles.titleStyle);

            using (new EditorGUILayout.VerticalScope(GameFoundationEditorStyles.boxStyle))
            {
                var detailDefinitions = gameItemDefinition.GetDetailDefinitions();

                if (detailDefinitions != null)
                {
                    // loop through details and render their property drawers
                    int detailCount = detailDefinitions.Length;
                    if (detailCount <= 0)
                    {
                        GUILayout.Label("no details attached", GameFoundationEditorStyles.centeredGrayLabel);
                    }
                    else
                    {
                        int i = 0;

                        foreach (var detailDefinition in detailDefinitions)
                        {
                            string detailDisplayName = detailDefinition.DisplayName();

                            // if the reference entity has this same detail type attached, then this is overriding that
                            if (gameItemDefinition.referenceDefinition != null)
                            {
                                foreach (BaseDetailDefinition compareDetailDefinition in gameItemDefinition.referenceDefinition.GetDetailDefinitions())
                                {
                                    if (compareDetailDefinition.GetType() == detailDefinition.GetType())
                                    {
                                        detailDisplayName += " (overriding)";
                                        break;
                                    }
                                }
                            }
                            GUIContent detailLabel = new GUIContent(detailDisplayName, detailDefinition.TooltipMessage());
                            GUILayout.Label(detailLabel, EditorStyles.boldLabel);

                            Rect removeButtonRect = GUILayoutUtility.GetLastRect();
                            removeButtonRect.x = removeButtonRect.x + removeButtonRect.width - 20f;
                            removeButtonRect.width = 20f;
                            if (GUI.Button(removeButtonRect, "<b>X</b>", GameFoundationEditorStyles.deleteButtonStyle))
                            {
                                if (EditorUtility.DisplayDialog("Are you sure?", "Do you want to delete " + detailDefinition.DisplayName() + "?", "Yes", "No"))
                                {
                                    m_detailDefinitionToRemove = detailDefinition;
                                }
                            }

                            Editor detailDefinitionEditor = Editor.CreateEditor(detailDefinition);

                            if (detailDefinitionEditor != null)
                            {
                                if (System.Attribute.GetCustomAttribute(
                                    detailDefinition.GetType(),
                                    typeof(System.ObsoleteAttribute))
                                    is System.ObsoleteAttribute obsoleteAttribute)
                                {
                                    EditorGUILayout.HelpBox($"Warning: {detailDefinition.GetType().Name} is obsolete. {obsoleteAttribute.Message}", MessageType.Warning);
                                }

                                detailDefinitionEditor.OnInspectorGUI();
                            }

                            i++;

                            if (i < detailCount)
                            {
                                DrawDetailSeparator();
                            }
                        }
                    }
                }
                else
                {
                    GUILayout.Label("Error: The Detail Definitions list is null!");
                }
            }

            if (m_detailDefinitionToRemove != null)
            {
                gameItemDefinition.RemoveDetailDefinition(m_detailDefinitionToRemove);
                m_detailDefinitionToRemove = null;
            }

            using (new GUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Add Detail", GUILayout.Width(200f)))
                {
                    DetailHelper.RefreshTypeDict();

                    // keep a list of the names of all detail types already added to this GameItemDefinition
                    List<BaseDetailDefinition> alreadyAddedDetails =
                        new List<BaseDetailDefinition>(gameItemDefinition.GetDetailDefinitions());

                    List<string> alreadyAddedDetailTypesNames = new List<string>();

                    foreach (BaseDetailDefinition detailDefinition in alreadyAddedDetails)
                    {
                        alreadyAddedDetailTypesNames.Add(detailDefinition.DisplayName());
                    }

                    bool newDetailTypesAvailable = false;
                    bool customDetailTypesAvailable = false;

                    GenericMenu detailChoicesMenu = new GenericMenu();

                    foreach (var detailDefinitionInfo in DetailHelper.defaultDetailDefinitionInfo)
                    {
                        if (!alreadyAddedDetailTypesNames.Contains(detailDefinitionInfo.Key))
                        {
                            newDetailTypesAvailable = true;

                            detailChoicesMenu.AddItem(
                                new GUIContent(detailDefinitionInfo.Key),
                                false,
                                () =>
                                {
                                    // create new detail definition
                                    var newDetailDefinition = ScriptableObject.CreateInstance(detailDefinitionInfo.Value) as BaseDetailDefinition;

                                    // add to GameItemDefinition
                                    gameItemDefinition.AddDetailDefinition(newDetailDefinition);
                                });
                        }
                    }

                    // Need to do a check first to determine if we should display the separator.
                    foreach (var detailDefinitionInfo in DetailHelper.customDetailDefinitionInfo)
                    {
                        if (!alreadyAddedDetailTypesNames.Contains(detailDefinitionInfo.Key))
                        {
                            customDetailTypesAvailable = true;
                            break;
                        }
                    }

                    if (customDetailTypesAvailable)
                    {
                        detailChoicesMenu.AddSeparator("");
                        
                        foreach (var detailDefinitionInfo in DetailHelper.customDetailDefinitionInfo)
                        {
                            if (!alreadyAddedDetailTypesNames.Contains(detailDefinitionInfo.Key))
                            {
                                detailChoicesMenu.AddItem(
                                    new GUIContent(detailDefinitionInfo.Key),
                                    false,
                                    () =>
                                    {
                                        // create new detail definition
                                        var newDetailDefinition = ScriptableObject.CreateInstance(detailDefinitionInfo.Value) as BaseDetailDefinition;

                                        // add to GameItemDefinition
                                        gameItemDefinition.AddDetailDefinition(newDetailDefinition);
                                    });
                            }
                        }
                    }

                    if (!newDetailTypesAvailable && !customDetailTypesAvailable)
                    {
                        detailChoicesMenu.AddDisabledItem(new GUIContent("all details already added"));
                    }

                    detailChoicesMenu.ShowAsContext();
                }

                GUILayout.FlexibleSpace();
            }

            // only show this section if inheritance is possible (not possible with GameItemDefinition, for example)
            if (gameItemDefinition.GetType() != typeof(GameItemDefinition))
            {
                EditorGUILayout.Space();

                EditorGUILayout.LabelField(s_InheritedDetailDefinitionsLabel, GameFoundationEditorStyles.titleStyle);

                using (new EditorGUILayout.VerticalScope(GameFoundationEditorStyles.boxStyle))
                {
                    if (gameItemDefinition.referenceDefinition != null)
                    {
                        var detailDefinitions = gameItemDefinition.referenceDefinition.GetDetailDefinitions();

                        if (detailDefinitions != null)
                        {
                            // loop through components and render their property drawers
                            int referenceDetailCount = detailDefinitions.Length;
                            if (referenceDetailCount <= 0)
                            {
                                GUILayout.Label("no details inherited", GameFoundationEditorStyles.centeredGrayLabel);
                            }
                            else
                            {
                                int i = 0;

                                foreach (var detailDefinition in detailDefinitions)
                                {
                                    // if this DetailDef type is also attached to the gameItemDefinition, then this has been overridden
                                    bool isOverridden = false;
                                    foreach (BaseDetailDefinition compareDetailDefinition in gameItemDefinition.GetDetailDefinitions())
                                    {
                                        if (compareDetailDefinition.GetType() == detailDefinition.GetType())
                                        {
                                            isOverridden = true;
                                            break;
                                        }
                                    }

                                    // this should always be disabled at editor time and runtime
                                    using (new EditorGUI.DisabledScope(true))
                                    {
                                        SerializedObject componentDefinitionSerializedObject = new SerializedObject(detailDefinition);

                                        string detailDisplayName = detailDefinition.DisplayName();

                                        if (isOverridden)
                                        {
                                            detailDisplayName += " (overridden)";
                                        }

                                        GUIContent detailLabel = new GUIContent(detailDisplayName, detailDefinition.TooltipMessage());
                                        GUILayout.Label(detailLabel, EditorStyles.boldLabel);

                                        if (!isOverridden)
                                        {
                                            Editor detailDefinitionEditor = Editor.CreateEditor(detailDefinition);

                                            if (detailDefinitionEditor != null)
                                            {
                                                detailDefinitionEditor.OnInspectorGUI();
                                            }
                                        }

                                        componentDefinitionSerializedObject.ApplyModifiedProperties();
                                    }

                                    i++;

                                    if (i < referenceDetailCount)
                                    {
                                        DrawDetailSeparator();
                                    }
                                }
                            }
                        }
                        else
                        {
                            GUILayout.Label("Error: The component definitions list is null!");
                        }
                    }
                    else
                    {
                        GUILayout.Label("no reference definition selected", GameFoundationEditorStyles.centeredGrayLabel);
                    }
                }
            }
        }

        static void DrawDetailSeparator()
        {
            GUILayout.Space(5f);
            Rect lineRect1 = EditorGUILayout.GetControlRect(false, 1);
            lineRect1.xMin -= 10;
            lineRect1.xMax += 10;
            EditorGUI.DrawRect(lineRect1, EditorGUIUtility.isProSkin ? Color.black : Color.gray);
        }
    }
}
