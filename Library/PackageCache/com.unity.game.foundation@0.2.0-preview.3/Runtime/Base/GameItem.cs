using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.GameFoundation
{
    /// <summary>
    /// Common Fields found in BaseItem and BaseCollection. BaseItem and BaseCollection both inherit from this class.
    /// </summary>
    public class GameItem
    {
        // prevent discard of game item multiple times
        private bool m_Discarded = false;

        /// <summary>
        /// Constructor for a GameItem.
        /// </summary>
        /// <param name="definition">The GameItemDefinition this GameItem should use.</param>
        /// <param name="id">The Id this GameItem will use.</param>
        /// <param name="displayName">The display name this GameItem will use.</param>
        public GameItem(GameItemDefinition definition, string id = null, string displayName = null) : this(definition, id, displayName, 0)
        {
        }
        
        internal GameItem(GameItemDefinition definition, string id, string displayName, int gameItemId)
        {
            // assign this gameItem a unique gameItem Id and register it with the GameItem instance lookup class
            m_GameItemId = gameItemId != 0 ? gameItemId : GameItemLookup.GetNextIdForInstance();
            GameItemLookup.RegisterInstance(m_GameItemId, this);

            // determine Id and Hash 
            if (string.IsNullOrEmpty(id))
            {
                m_Id = Guid.NewGuid().ToString();
                m_Hash = Tools.StringToHash(m_Id);
            }
            else
            {
                if (!Tools.IsValidId(id))
                {
                    throw new System.ArgumentException("GameItem can only be alphanumeric with optional dashes or underscores.");
                }
                
                m_Id = id;
                m_Hash = Tools.StringToHash(m_Id);
            }

            // save display name.  note: could be null, in which case we'll always return definition's display name
            m_DisplayName = displayName;

            // save definition, catgories, details, etc.
            if (ReferenceEquals(definition, null))
            {
                m_Definition = null;
                m_Categories = new CategoryDefinition[] { };
            }
            else
            { 
                m_Definition = definition;
                var categories = definition.GetCategories();
                if (ReferenceEquals(categories, null) || categories.Length == 0)
                {
                    m_Categories = new CategoryDefinition[] { };
                }
                else
                {
                    m_Categories = new CategoryDefinition[categories.Length];
                    int counter = 0;
                    foreach (CategoryDefinition category in categories)
                    {
                        m_Categories[counter] = category;
                        counter++;
                    }
                }

                var details = definition.GetDetailDefinitions();
                if (!ReferenceEquals(details, null))
                {
                    foreach (var detailDefinition in details)
                    {
                        AddDetail(detailDefinition);
                    }
                }

                if (!ReferenceEquals(definition.referenceDefinition, null))
                {
                    var referenceDetail = definition.referenceDefinition.GetDetailDefinitions();
                    if (!ReferenceEquals(referenceDetail, null))
                    {
                        foreach (var detailDefinition in referenceDetail)
                        {
                            if (!m_Details.ContainsKey(detailDefinition.GetType()))
                            {
                                AddDetail(detailDefinition);
                            }
                        }
                    }
                }
            }
            
            // if the GameItem is new, it will create its Stats
            if (gameItemId == 0)
            {
                // set all stats for stats detail definitions in gameItem definition and all reference gameItem definitions
                SetDefaultStats();
            }

            NotificationSystem.FireNotification(NotificationType.Created, this);
        }

        private void SetDefaultStats()
        {
            // set all stats for stats detail definitions in gameItem definition and all reference gameItem definitions
            var definitionOn = m_Definition;
            while (definitionOn != null)
            {
                var details = definitionOn.GetDetailDefinitions();
                if (details != null)
                {
                    foreach (var detailDefinition in details)
                    {
                        var statDetailDefinition = detailDefinition as StatDetailDefinition;
                        if (statDetailDefinition != null)
                        {
                            if (statDetailDefinition.statDefaultIntValues != null)
                            {
                                foreach (var kv in statDetailDefinition.statDefaultIntValues)
                                {
                                    if (!StatManager.TryGetIntValue(this, kv.Key, out int dummy))
                                    {
                                        StatManager.SetIntValue(this, kv.Key, kv.Value);
                                    }
                                }
                            }
                            if (statDetailDefinition.statDefaultFloatValues != null)
                            {
                                foreach (var kv in statDetailDefinition.statDefaultFloatValues)
                                {
                                    if (!StatManager.TryGetFloatValue(this, kv.Key, out float dummy))
                                    {
                                        StatManager.SetFloatValue(this, kv.Key, kv.Value);
                                    }
                                }
                            }
                        }
                    }
                }

                definitionOn = definitionOn.referenceDefinition;
            }
        }

        // remove all references to this game item--called when inventories are reset or items removed from them
        // remove all stats and removes it from the GameItemLookup directory.
        protected internal virtual void Discard()
        {
            if (!m_Discarded)
            {
                // remove all stats for specified this game item
                StatManager.OnGameItemDiscarded(this);

                // remove game item lookup for this game item
                GameItemLookup.UnregisterInstance(m_GameItemId);

                // remember the item was discarded so we don't do it again
                m_Discarded = true;
            }
        }

        /// <summary>
        // in finalizer, remove gameItem from gameItem instance lookup
        /// </summary>
        ~GameItem()
        {
            Discard();
        }

        [SerializeField]
        private int m_GameItemId;

        /// <summary>
        /// The GameItem Id (unique thoughout game) for this GameItem.
        /// </summary>
        /// <returns>The GameItem Id (unique thoughout game) for this GameItem.</returns>
        internal int gameItemId
        {
            get { return m_GameItemId; }
        }

        [SerializeField] 
        private string m_DisplayName;

        /// <summary>
        /// The name of this GameItem for the user to display.
        /// </summary>
        /// <returns>The name of this GameItem for the user to display.</returns>
        public string displayName
        {
            get { return m_DisplayName != null ? m_DisplayName : m_Definition?.displayName; }
            internal set { m_DisplayName = value; }
        }

        [SerializeField]
        private string m_Id;

        /// <summary>
        /// The string Id of this GameItem.
        /// </summary>
        /// <returns>The Id string for this GameItem.</returns>
        public string id
        {
            get { return m_Id; }
        }

        [SerializeField] 
        private int m_Hash;

        /// <summary>
        /// The Hash of this GameItem's Id.
        /// </summary>
        /// <returns>The Hash of this GameItem's Id.</returns>
        public int hash
        {
            get { return m_Hash; }
        }

        [SerializeField]
        private GameItemDefinition m_Definition;

        /// <summary>
        /// The GameItemDefinition for this GameItem.
        /// </summary>
        /// <returns>The GameItemDefinition for this GameItem.</returns>
        public GameItemDefinition definition
        {
            get { return m_Definition; }
        }

        [SerializeField]
        private CategoryDefinition[] m_Categories;

        /// <summary>
        /// An array of all CategoryDefinitions assigned to this GameItem.
        /// </summary>
        /// <returns>An array of all CategoryDefinitions assigned to this GameItem.</returns>
        public CategoryDefinition[] categories
        {
            get { return m_Categories; }
        }

        [SerializeField] 
        private Dictionary<Type,BaseDetail> m_Details = new Dictionary<Type, BaseDetail>();

        /// <summary>
        /// Returns an array of all details attached to this game item.
        /// </summary>
        /// <returns>An array of all details attached to this game item.</returns>
        protected BaseDetail[] GetDetails()
        {
            if (m_Details == null)
            {
                return null;
            }

            BaseDetail[] baseDetails = new BaseDetail[m_Details.Count];
            m_Details.Values.CopyTo(baseDetails, 0);
            return baseDetails;
        }

        /// <summary>
        /// Fills the given list with all details attached to this game item.
        /// Note: this returns the current state of all details attached.  To ensure that
        /// there are no invalid or duplicate entries, the 'details' list will always be 
        /// cleared and 'recycled' (i.e. updated) with current data from the game item.
        /// </summary>
        /// <param name="details">The list to clear and fill with this game item's details.</param>
        protected void GetDetails(List<BaseDetail> details)
        {
            if (details == null)
            {
                return;
            }

            details.Clear();

            if (m_Details == null)
            {
                return;
            }
            
            details.AddRange(m_Details.Values);
        }

        /// <summary>
        /// This will add a Detail instance to this GameItem based on the specified DetailDefinition, if needed.
        /// </summary>
        /// <param name="detailDefinition">The DetailDefinition to create a Detail from.</param>
        /// <returns>A reference to the Detail instance that was added or null if no runtime Detail is needed for the specified DetailDefinition.</returns>
        protected BaseDetail AddDetail(BaseDetailDefinition detailDefinition)
        {
            if (ReferenceEquals(detailDefinition, null))
            {
                Debug.LogWarning("Null detail definition given, this will not be added.");
                return null;
            }

            var createdDetail = detailDefinition.CreateDetail(this);

            // above method only creates runtime details when they're needed--null signals runtime details not required
            if (createdDetail != null)
            {
                AddDetail(createdDetail);
            }
            return createdDetail;
        }

        /// <summary>
        /// This will add the given Detail to the Details list for this GameItem.
        /// </summary>
        /// <param name="detail">The Detail to add to this GameItem.</param>
        /// <returns>A reference to the Detail that was added.</returns>
        /// <exception cref="ArgumentException">Thrown if the given detail is a duplicate.</exception>
        protected BaseDetail AddDetail(BaseDetail detail)
        {
            if (detail == null)
            {
                Debug.LogWarning("Null detail given, this will not be added.");
                return null;
            }
            
            var detailType = detail.GetType();

            BaseDetail oldDetail;
            if (m_Details.TryGetValue(detailType, out oldDetail))
            {
                if (oldDetail.GetType() == detailType)
                {
                   throw new ArgumentException("Cannot add a duplicate detail.");
                }
            }

            // add specified detail by detail's type to the dictionary
            // note: this MAY overwrite a detail with a more derived type which is correct since this IS the item of exactly the specified type
            m_Details[detailType] = detail;

            // also search base class types for the detail and add this detail for all base classes
            // note: this allows polymorphic behavior so, if base class is looked up, it will find the derived class 
            var typeOn = detailType;
            while (true)
            {
                typeOn = typeOn.BaseType;
                if (typeOn == null || typeOn == typeof(BaseDetail))
                {
                    break;
                }
                BaseDetail testDetail;
                if (m_Details.TryGetValue(typeOn, out testDetail))
                {
                    if (testDetail != null && testDetail != oldDetail)
                    {
                        break;
                    }
                }

                m_Details[typeOn] = detail;
            }

            return detail;
        }

        /// <summary>
        /// This will add a Detail of the specified type to this GameItem.
        /// </summary>
        /// <typeparam name="T">Type of detail to add.</typeparam>
        /// <returns>A reference to the newly-created Detail that was added.</returns>
        protected T AddDetail<T>() where T : BaseDetail, new()
        {
            var newDetail = new T();
            newDetail.owner = this;
            return AddDetail(newDetail) as T;
        }

        /// <summary> 
        /// This will return a reference to the requested Detail by type.
        /// </summary>
        /// <typeparam name="T">The type of Detail to return.</typeparam>
        /// <returns>A reference to the Detail or null if not found.</returns>
        internal protected T GetDetail<T>() where T : BaseDetail
        {
            var type = typeof(T);
            BaseDetail detail;
            if (m_Details.TryGetValue(type, out detail))
            {
                return (T)detail;
            }

            return null;
        }

        /// <summary> 
        /// This will remove the requested Detail (by Detail type) from this GameItem.
        /// </summary>
        /// <typeparam name="T">The type of Detail to remove.</typeparam>
        /// <returns>True if Detail was successfully removed, else false.</returns>
        protected bool RemoveDetail<T>() where T : BaseDetail
        {
            // remove the reference to the detail by specified type
            var type = typeof(T);

            BaseDetail baseDetailToRemove;
            if (!m_Details.TryGetValue(type, out baseDetailToRemove))
            {
                return false;
            }

            if (!m_Details.Remove(type))
            {
                return false;
            }

            // remove all details linked from base classes to this same detail (they were used to allow polymorphism)
            while (true)
            {
                type = type.BaseType;
                if (type == null || type == typeof(BaseDetail))
                {
                    break;
                }

                BaseDetail baseDetail;
                if (!m_Details.TryGetValue(type, out baseDetail))
                {
                    break;
                }

                if (baseDetail != baseDetailToRemove)
                {
                    break;
                }

                m_Details.Remove(type);
            }

            return true;
        }

        #region StatsHelpers

        /// <summary>
        /// Gets the Int Stat for the input statDefinitionId
        /// </summary>
        /// <param name="statDefinitionId">statDefinitionId for stat to get</param>
        /// <returns>Stat with parameter Id</returns>
        /// <exception cref="KeyNotFoundException">Thrown if an Int Stat with parameter Id is not found.</exception>
        /// <exception cref="ArgumentNullException">The parameter is null or empty</exception>
        public int GetStatInt(string statDefinitionId)
        {
            if (string.IsNullOrEmpty(statDefinitionId))
                throw new ArgumentNullException(statDefinitionId, "The statDefinitionId is null or empty");
            
            return GetStatInt(Tools.StringToHash(statDefinitionId));
        }
        
        /// <summary>
        /// Gets the Int Stat for the input statDefinitionHash
        /// </summary>
        /// <param name="statDefinitionHash">statDefinitionHash for stat to get</param>
        /// <returns>Stat with parameter hash</returns>
        /// <exception cref="KeyNotFoundException">Thrown if an Int Stat with parameter hash is not found.</exception>
        public int GetStatInt(int statDefinitionHash)
        {
            return StatManager.GetIntValue(this, statDefinitionHash);
        }

        /// <summary>
        /// Gets the Float Stat for the input statDefinitionId
        /// </summary>
        /// <param name="statDefinitionId">statDefinitionId for stat to get</param>
        /// <returns>Stat with parameter Id</returns>
        /// <exception cref="KeyNotFoundException">Thrown if an Float Stat with parameter Id is not found.</exception>
        /// <exception cref="ArgumentNullException">The parameter is null or empty</exception>
        public float GetStatFloat(string statDefinitionId)
        {
            if (string.IsNullOrEmpty(statDefinitionId))
                throw new ArgumentNullException(statDefinitionId, "The statDefinitionId is null or empty");
            
            return GetStatFloat(Tools.StringToHash(statDefinitionId));
        }
        
        /// <summary>
        /// Gets the Float Stat for the input statDefinitionHash
        /// </summary>
        /// <param name="statDefinitionHash">statDefinitionHash for stat to get</param>
        /// <returns>Stat with parameter hash</returns>
        /// <exception cref="KeyNotFoundException">Thrown if an Float Stat with parameter hash is not found.</exception>
        public float GetStatFloat(int statDefinitionHash)
        {
            return StatManager.GetFloatValue(this, statDefinitionHash);;
        }
        
        /// <summary>
        /// Sets the Int Stat with corresponding stateDefinitionId to value.
        /// </summary>
        /// <param name="statDefinitionId">Int Stat statDefinitionId to set</param>
        /// <param name="value">value to set stat to</param>
        /// <exception cref="NullReferenceException">The parameter doesn't exist in the stats catalog</exception>
        /// <exception cref="InvalidOperationException">The parameter refers to a stat of a different type</exception>
        /// <exception cref="ArgumentNullException">The parameter is null or empty</exception>
        public void SetStatInt(string statDefinitionId, int value)
        {
            if (string.IsNullOrEmpty(statDefinitionId))
                throw new ArgumentNullException(statDefinitionId, "The statDefinitionId is null or empty");
            
            SetStatInt(Tools.StringToHash(statDefinitionId), value);
        }
        
        /// <summary>
        /// Sets the Int Stat with corresponding statDefinitionHash to value.
        /// </summary>
        /// <param name="statDefinitionHash">Int Stat statDefinitionHash to set</param>
        /// <param name="value">value to set stat to</param>
        /// <exception cref="NullReferenceException">The parameter doesn't exist in the stats catalog</exception>
        /// <exception cref="InvalidOperationException">The parameter refers to a stat of a different type</exception>
        public void SetStatInt(int statDefinitionHash, int value)
        {
            StatManager.SetIntValue(this, statDefinitionHash, value);
        }
        
        /// <summary>
        /// Sets the Float Stat with corresponding stateDefinitionId to value.
        /// </summary>
        /// <param name="statDefinitionId">Float Stat statDefinitionId to set</param>
        /// <param name="value">value to set stat to</param>
        /// <exception cref="NullReferenceException">The parameter doesn't exist in the stats catalog</exception>
        /// <exception cref="InvalidOperationException">The parameter refers to a stat of a different type</exception>
        /// <exception cref="ArgumentNullException">The stat parameter is null or empty</exception>
        public void SetStatFloat(string statDefinitionId, float value)
        {
            if (string.IsNullOrEmpty(statDefinitionId))
                throw new ArgumentNullException(statDefinitionId, "The statDefinitionId is null or empty");
            
            SetStatFloat(Tools.StringToHash(statDefinitionId), value);
        }
        
        /// <summary>
        /// Sets the Float Stat with corresponding statDefinitionHash to value.
        /// </summary>
        /// <param name="statDefinitionHash">Float Stat statDefinitionHash to set</param>
        /// <param name="value">value to set stat to</param>
        /// <exception cref="NullReferenceException">The parameter doesn't exist in the stats catalog</exception>
        /// <exception cref="InvalidOperationException">The parameter refers to a stat of a different type</exception>
        public void SetStatFloat(int statDefinitionHash, float value)
        {
            StatManager.SetFloatValue(this, statDefinitionHash, value);
        }
        #endregion
    }
}
