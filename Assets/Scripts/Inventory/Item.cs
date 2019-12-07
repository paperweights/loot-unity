using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item", order = 0)]
    public class Item : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField, TextArea(3, 10)] private string _description;
        [SerializeField] private int _value;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Color _colour = Color.yellow;

        public Sprite GetSprite()
        {
            return _sprite;
        }

        public Color GetColour()
        {
            return _colour;
        }
    }
}