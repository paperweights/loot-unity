using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Inventory Object", menuName = "ScriptableObject/InventoryObject", order = 0)]
    public class InventoryObject : ScriptableObject
    {
        [SerializeField] private int _coins;
        [SerializeField] private int _diamonds;
        [SerializeField] private List<Item> _items;

        public int GetCoins()
        {
            return _coins;
        }
        public void SetCoins(int newAmount)
        {
            _coins = newAmount;
        }
        public int GetDiamonds()
        {
            return _diamonds;
        }
        public void SetDiamonds(int newAmount)
        {
            _diamonds = newAmount;
        }
        public List<Item> GetItems()
        {
            return _items;
        }

        public void SetItems(List<Item> newItems)
        {
            _items = newItems;
        }
    }
}
