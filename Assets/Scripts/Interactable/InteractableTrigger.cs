using System;
using Ui;
using UnityEngine;

namespace Interactable
{
    public class InteractableTrigger : MonoBehaviour
    {
        [SerializeField] private string _interactionText;
        [SerializeField] private InteractableObject _interactable;
        [SerializeField] private KeyCode _interactKey = KeyCode.E;
        private GameObject _playerInside;
        private InteractionDisplay _interactionDisplay;

        private void Awake()
        {
            _interactionDisplay = FindObjectOfType<InteractionDisplay>();
        }

        private void Update()
        {
            if (!_playerInside) return;
            _interactionDisplay.SetText(_interactionText);
            if (Input.GetKeyDown(_interactKey))
            {
                _interactable.Interact(_playerInside);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            // Check if player is inside 
            if (other.CompareTag("Player"))
            {
                _playerInside = other.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _interactionDisplay.ClearText();
                _playerInside = null;
            }
        }
    }
}
