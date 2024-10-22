using System;
using System.Linq;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.AI.Planner.Utility;
using UnityEditor.AI.Planner.Utility;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI.Planner.DomainLanguage.TraitBased;

namespace UnityEditor.AI.Planner.Editors
{
    [CustomEditor(typeof(TraitDefinition))]
    class TraitDefinitionInspector : SaveableInspector
    {
        static string[][] s_DefaultTypes =
        {
            // These two arrays must stay in sync
            new[]
            {
                "Boolean",
                "Float",
                "Integer",
                "String/64",
                "String/512",
                "String/4096",
                "DomainObject",
                "Custom..."
            },
            new[]
            {
                "System.Boolean",
                "System.Single",
                "System.Int64",
                "Unity.Entities.NativeString64",
                "Unity.Entities.NativeString512",
                "Unity.Entities.NativeString4096",
                typeof(DomainObjectID).FullName,
                "Custom..."
            }
        };

        private NoHeaderReorderableList m_FieldList;

        void OnEnable()
        {
            m_FieldList = new NoHeaderReorderableList(serializedObject, serializedObject.FindProperty("m_Fields"),
                DrawFieldListElement, 3);

            DomainAssetDatabase.Refresh();
        }

        public override void OnInspectorGUI()
        {
            var trait = (TraitDefinition) target;

            serializedObject.Update();

            GUILayout.Label(EditorStyleHelper.fields, EditorStyles.boldLabel);
            m_FieldList.AdjustElementHeight(m_FieldList.count == 0?1:3);
            m_FieldList.DoLayoutList();

            GUILayout.Label(EditorStyleHelper.usages, EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical(GUI.skin.box);

            GUI.enabled = false;
            var used = IsTraitUsed(trait);
            GUI.enabled = true;

            if (!used)
            {
                GUILayout.Label("None", EditorStyles.miniLabel);
            }

            GUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();
        }

        private static bool IsTraitUsed(TraitDefinition trait)
        {
            var used = false;
            foreach (var action in DomainAssetDatabase.ActionDefinitions)
            {
                var usedByAction = action.Parameters.Any(param =>
                    param.RequiredTraits.Contains(trait) || param.ProhibitedTraits.Contains(trait));
                usedByAction |=
                    action.CreatedObjects.Any(co => co.RequiredTraits.Contains(trait) || co.ProhibitedTraits.Contains(trait));

                if (usedByAction)
                {
                    var rect = EditorGUILayout.GetControlRect();
                    EditorGUI.ObjectField(rect, action, typeof(ActionDefinition), false);

                    used = true;
                }
            }

            foreach (var termination in DomainAssetDatabase.StateTerminationDefinitions)
            {
                if (!termination.ObjectParameters.RequiredTraits.Contains(trait) &&
                    !termination.ObjectParameters.ProhibitedTraits.Contains(trait)) continue;

                var rect = EditorGUILayout.GetControlRect();
                EditorGUI.ObjectField(rect, termination, typeof(StateTerminationDefinition), false);

                used = true;
            }

            return used;
        }

        private void DrawFieldListElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            var list = m_FieldList.serializedProperty;
            var field = list.GetArrayElementAtIndex(index);

            rect.y += EditorGUIUtility.standardVerticalSpacing;
            rect.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(rect, field.FindPropertyRelative("m_Name"));

            rect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            var domainEnums = DomainAssetDatabase.EnumDefinitions.ToList();
            var typeNames = s_DefaultTypes[0].ToList();
            typeNames.InsertRange(typeNames.Count - 1, domainEnums.Select(e => $"Enums/{e.Name}"));

            var typeFullNames = s_DefaultTypes[1].ToList();
            typeFullNames.InsertRange(typeFullNames.Count - 1,
                domainEnums.Select(e => $"{TypeResolver.DomainsNamespace}.Enums.{e.Name}"));

            var typeProperty = field.FindPropertyRelative("m_Type");
            var typeIndex = (!string.IsNullOrEmpty(typeProperty.stringValue))
                ? typeFullNames.IndexOf(typeProperty.stringValue)
                : 0;

            Type fieldType = null;
            if (typeIndex < 0)
            {
                if (typeProperty.stringValue == " ")
                {
                    typeProperty.stringValue = EditorGUI.TextField(rect, "Type", typeProperty.stringValue);
                    EditorGUI.TextField(rect, " ", "Custom...", EditorStyleHelper.ExampleLabel);
                }
                else
                {
                    fieldType = TypeResolver.GetType(typeProperty.stringValue);
                    typeProperty.stringValue = EditorGUI.TextField(rect, "Type", typeProperty.stringValue, fieldType == null
                        ? EditorStyleHelper.ErrorTextField
                        : EditorStyles.textField).Trim();
                }
            }
            else
            {
                typeIndex = EditorGUI.Popup(rect, "Type", typeIndex, typeNames.ToArray());
                typeProperty.stringValue = typeIndex == typeFullNames.Count - 1 ? " " : typeFullNames[typeIndex];
            }

            rect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            fieldType = TypeResolver.GetType(typeProperty.stringValue);
            if (fieldType != null)
            {
                var valueProperty = FieldValueDrawer.GetSerializedProperty(field.FindPropertyRelative("m_DefaultValue"), fieldType);
                if (valueProperty == null)
                {
                    EditorGUI.LabelField(rect, "Default", "-", EditorStyleHelper.ExampleLabel);
                    return;
                }

                if (fieldType.IsEnum)
                {
                    valueProperty.intValue = EditorGUI.Popup(rect, "Default", valueProperty.intValue,
                        Enum.GetNames(fieldType).Select(e => $"{fieldType.Name}.{e}").ToArray());
                }
                else
                {
                    EditorGUI.PropertyField(rect, valueProperty, new GUIContent("Default"));
                }
            }
            else
            {
                EditorGUI.LabelField(rect, "Default", "-");
            }
        }
    }
}
