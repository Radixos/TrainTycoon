﻿using UnityEngine.GameFoundation.DataPersistence;
using UnityEngine.UI;

namespace UnityEngine.GameFoundation.Sample
{
    /// <summary>
    /// This class manages the scene for showcasing the data persistence sample.
    /// </summary>
    public class DataPersistenceSample : MonoBehaviour
    {
        private bool m_WrongDatabase;

        /// <summary>
        /// Reference to the panel to display when the wrong database is in use.
        /// </summary>
        public GameObject wrongDatabasePanel;
        
        /// <summary>
        /// We will need a reference to the main text box in the scene so we can easily modify it.
        /// </summary>
        public Text mainText;
        
        /// <summary>
        /// We will need a reference to show inventory count
        /// </summary>
        public Text inventoryCountText;

        /// <summary>
        /// Standard starting point for Unity scripts.
        /// </summary>
        void Start()
        {
            // The database has been properly setup.
            m_WrongDatabase = !SamplesHelper.VerifyDatabase();
            if (m_WrongDatabase)
            {
                wrongDatabasePanel.SetActive(true);
                return;
            }
            
            // Initialize must always be called before working with any game foundation code.
            // If local persistence is passed in as a parameter, it will automatically load on startup.
            GameFoundation.Initialize(new LocalPersistence(new JsonDataSerializer()));

            // Here we bind our UI refresh method to callbacks on the inventory manager.
            // These callbacks will automatically be invoked anytime an inventory is added, or removed.
            // This prevents us from having to manually invoke RefreshUI every time we perform one of these actions.
            InventoryManager.onInventoryAdded += RefreshUI;
            InventoryManager.onInventoryRemoved += RefreshUI;
            
            RefreshUI();
        }

        /// <summary>
        /// This will fill out the main text box with information about the main inventory.
        /// </summary>
        /// <param name="inventoryParam">This parameter will not be used, but must exist so the signature is compatible with the inventory callbacks so we can bind it.</param>
        private void RefreshUI(Inventory inventoryParam = null)
        {
            var inventories = InventoryManager.GetInventories();
            
            // Show the total count of inventories
            inventoryCountText.text = "Total Inventories: " + inventories.Length;

            mainText.text = string.Empty;

            // Loop through every inventory within the manager.
            foreach (Inventory inventory in inventories)
            {
                // Display an empty line between inventories
                mainText.text += "\n";
                
                // Display the main inventory's display name
                mainText.text += "Inventory - " + inventory.displayName + "\n";

                // Loop through every type of item within the inventory and display its name and quantity.
                foreach (InventoryItem inventoryItem in inventory.GetItems())
                {
                    // All game items have an associated display name, this includes game items.
                    string itemName = inventoryItem.displayName;

                    // Every inventory item has an associated quantity. This represents how many units of this item there are within the inventory.
                    int quantity = inventoryItem.quantity;

                    mainText.text += itemName + ": " + quantity + "\n";
                }
            }
        }

        /// <summary>
        /// Adds a blank inventory to the manager.
        /// This blank inventory needs to be setup manually in the catalog first, see the inventory window for details.
        /// The id can be whatever you want, but if you don't need a particular one, "InventoryManager.GetNewInventoryId()" will generate a new one based off of a guid for you.
        /// </summary>
        public void AddBlankInventory()
        {
            string inventoryDefinition = "blank";
            string id = InventoryManager.GetNewInventoryId();
            string displayName = "Blank";
            
            InventoryManager.CreateInventory(inventoryDefinition, id, displayName);
        }

        /// <summary>
        /// Adds a fruit salad inventory to the inventory manager.
        /// This inventory contains a few of each fruit item.
        /// It also configured as a default inventory so one will show up automatically at the start.
        /// </summary>
        public void AddFruitSalad()
        {
            string inventoryDefinition = "fruitSalad";
            string id = InventoryManager.GetNewInventoryId();
            string displayName = "Fruit Salad";
            
            InventoryManager.CreateInventory(inventoryDefinition, id, displayName);
        }

        /// <summary>
        /// Removes the last inventory in the list.
        /// </summary>
        public void RemoveLast()
        {
            // Grab all inventories and select the last one
            Inventory[] inventories = InventoryManager.GetInventories();
            Inventory toRemove = inventories[inventories.Length - 1];
            
            // Remove it using RemoveInventory
            InventoryManager.RemoveInventory(toRemove);
        }

        /// <summary>
        /// This will invoke the game foundation save method.
        /// It's as simple as a single method call. The parameter passed in will create a local JSON file on your machine.
        /// This data will persist between play sessions.
        /// This sample only showcases inventories, but this method saves their items, and stats too. 
        /// </summary>
        public void Save()
        {
            GameFoundation.Save(new LocalPersistence(new JsonDataSerializer()));
            
            Debug.Log("Saved!");
        }

        /// <summary>
        /// This will invoke the game foundation load method.
        /// Once you have saved, you can load with a method call that is just as simple.
        /// This will set the current state of inventories and stats to be what's within the save file.
        /// </summary>
        public void Load()
        {
            GameFoundation.Load(new LocalPersistence(new JsonDataSerializer()));
            
            Debug.Log("Loaded!");
        }
    }
}
