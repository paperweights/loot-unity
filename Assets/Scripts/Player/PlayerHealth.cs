using Ui;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 2;
        [SerializeField] private int _currentHealth;
        [SerializeField] private float _invincibilityTime;
        private float _timeSinceHit;
        private HealthDisplay _healthDisplay;

        private void Awake()
        {
            _timeSinceHit = _invincibilityTime;
            _healthDisplay = FindObjectOfType<HealthDisplay>();
        }

        private void Start()
        {
            _currentHealth = _maxHealth;
            _healthDisplay.UpdateMaxHealth(_maxHealth);
            ChangeHealth(0);
        }

        private void Update()
        {
            _timeSinceHit += Time.deltaTime;
        }

        public void ChangeHealth(int amount)
        {
            // Change health.
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
            _healthDisplay.UpdateCurrentHealth(_currentHealth);
            // Die if health is less than zero.
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        public void Hurt(int amount)
        {
            // Only hurt if invincibility time has passed.
            if (_timeSinceHit < _invincibilityTime) return;
            _timeSinceHit = 0;
            ChangeHealth(-amount);
        }

        public void Die()
        {
            print("Died");
        }
    }
}