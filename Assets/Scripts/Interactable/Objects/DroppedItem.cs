using Inventory;
using Player;
using UnityEngine;

namespace Interactable.Objects
{
    public class DroppedItem : InteractableObject
    {
        private Item _item;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public override void Interact(GameObject owner)
        {
            // Skip if no item is registered.
            if (!_item) return;
            base.Interact(owner);
            var hasAdded = owner.GetComponent<PlayerInventory>().AddItem(_item);
            if (hasAdded)
            {
                Destroy(gameObject);
            }
        }

        public void SetItem(Item newItem)
        {
            _item = newItem;
            _spriteRenderer.sprite = _item.GetSprite();
            _spriteRenderer.color = _item.GetColour();
        }
    }
}