using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class ItemDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject _itemContainerPrefab;
        [SerializeField] private Color _activeColour;
        [SerializeField] private Color _inactiveColour;
        private List<GameObject> _itemContainers = new List<GameObject>();

        public void UpdateContainers(int containerCount)
        {
            // Draw the item containers.
            // Destroy existing containers.
            foreach (var itemContainer in _itemContainers)
            {
                Destroy(itemContainer);
            }
            _itemContainers.Clear();
            // Create new containers.
            for (var i = 0; i < containerCount; i++)
            {
                var newContainer = Instantiate(_itemContainerPrefab, transform);
                _itemContainers.Add(newContainer);
            }
        }

        public void UpdateSelectedItem(int selectedItem)
        {
            for (var i = 0; i < _itemContainers.Count; i++)
            {
                var containerImage = _itemContainers[i].GetComponent<Image>();
                containerImage.color = i == selectedItem ? _activeColour : _inactiveColour;
            }
        }

        public void UpdateItems(List<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                var itemImage = _itemContainers[i].GetComponentsInChildren<Image>()[1];
                // Disable image for null items.
                if (!items[i])
                {
                    itemImage.enabled = false;
                    continue;
                }

                itemImage.enabled = true;
                itemImage.sprite = items[i].GetSprite();
                itemImage.color = items[i].GetColour();
            }
        }
    }
}