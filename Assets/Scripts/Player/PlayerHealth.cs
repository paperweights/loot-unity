using Ui;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 2;
        [SerializeField] private int _currentHealth;
        [SerializeField] private HealthDisplay _healthDisplay;

        private void Start()
        {
            _currentHealth = _maxHealth;
            _healthDisplay.UpdateMaxHealth(_maxHealth);
            _healthDisplay.UpdateCurrentHealth(_currentHealth);
        }
    }
}