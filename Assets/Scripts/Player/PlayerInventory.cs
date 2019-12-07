using System;
using Interactable.Objects;
using Inventory;
using Ui;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int _selectedItem;
        [SerializeField] private float _dropTime = 2;
        [SerializeField] private InventoryObject _inventoryObject;
        [SerializeField] private KeyCode _switchLeft = KeyCode.Q;
        [SerializeField] private KeyCode _switchRight = KeyCode.E;
        [SerializeField] private KeyCode _dropKey = KeyCode.F;
        [SerializeField] private ItemDisplay _itemDisplay;
        [SerializeField] private CoinDisplay _coinDisplay;
        [SerializeField] private GameObject _droppedItemPrefab;
        private float _timeHeld;

        public int GetSelectedItem()
        {
            return _selectedItem;
        }
        public InventoryObject GetInventoryObject()
        {
            return _inventoryObject;
        }

        private void Start()
        {
            _itemDisplay.UpdateContainers(_inventoryObject.GetItems().Count);
            _itemDisplay.UpdateSelectedItem(_selectedItem);
            _itemDisplay.UpdateItems(_inventoryObject.GetItems());
            _coinDisplay.UpdateCoins(_inventoryObject.GetCoins());
        }

        private void Update()
        {
            if (Input.GetKeyDown(_switchLeft))
            {
                _selectedItem--;
                if (_selectedItem < 0)
                {
                    _selectedItem = _inventoryObject.GetItems().Count - 1;
                }
                _itemDisplay.UpdateSelectedItem(_selectedItem);
            }
            else if (Input.GetKeyDown(_switchRight))
            {
                _selectedItem++;
                if (_selectedItem > _inventoryObject.GetItems().Count - 1)
                {
                    _selectedItem = 0;
                }
                _itemDisplay.UpdateSelectedItem(_selectedItem);
            }
            
            // Drop item.
            if (Input.GetKey(_dropKey))
            {
                // Drop the currently held item.
                if (_timeHeld >= _dropTime)
                {
                    DropItem();
                    _timeHeld = 0;
                }
                else
                {
                    _timeHeld += Time.deltaTime;
                }
            }
            else
            {
                _timeHeld = 0;
            }
        }

        public void ChangeCoins(int amount)
        {
            _inventoryObject.SetCoins(_inventoryObject.GetCoins() + amount);
            _coinDisplay.UpdateCoins(_inventoryObject.GetCoins());
        }

        public void DropItem()
        {
            var currentItems = _inventoryObject.GetItems();
            var itemToDrop = currentItems[_selectedItem];
            if (!itemToDrop) return;
            currentItems[_selectedItem] = null;
            _inventoryObject.SetItems(currentItems);
            var droppedItem = Instantiate(_droppedItemPrefab, transform.position, Quaternion.identity);
            droppedItem.GetComponent<DroppedItem>().SetItem(itemToDrop);
            _itemDisplay.UpdateItems(_inventoryObject.GetItems());
        }

        public bool AddItem(Item itemToAdd)
        {
            var items = _inventoryObject.GetItems();
            for (var i = 0; i < items.Count; i++)
            {
                // Find an empty slot in the inventory.
                if (items[i] != null) continue;
                // Fill the slot with the new item.
                items[i] = itemToAdd;
                _itemDisplay.UpdateItems(items);
                return true;
            }

            return false;
        }
    }
}