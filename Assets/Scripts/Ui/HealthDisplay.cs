using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject _heartIconPrefab;
        [SerializeField] private Color _normalColour;
        [SerializeField] private Color _emptyColour;
        private readonly List<GameObject> _heartIcons = new List<GameObject>();

        public void UpdateMaxHealth(int newMaxHealth)
        {
            // Clear old icons.
            for (var i = 0; i < _heartIcons.Count; i++)
            {
                Destroy(_heartIcons[i]);
            }
            _heartIcons.Clear();
            for (var i = 0; i < newMaxHealth; i++)
            {
                var newHeartIcon = Instantiate(_heartIconPrefab, transform);
                _heartIcons.Add(newHeartIcon);
            }
        }

        public void UpdateCurrentHealth(int newCurrentHealth)
        {
            for (var i = 0; i < _heartIcons.Count; i++)
            {
                var heartImage = _heartIcons[i].GetComponent<Image>();
                heartImage.color = i < newCurrentHealth ? _normalColour : _emptyColour;
            }
        }
    }
}