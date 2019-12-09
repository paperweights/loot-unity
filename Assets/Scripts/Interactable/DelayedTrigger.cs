using UnityEngine;

namespace Interactable
{
    public class DelayedTrigger : MonoBehaviour
    {
        [SerializeField] private InteractableObject _interactable;
        [SerializeField] private float _waitTime;
        private GameObject _triggerObject;
        private float _timePassed;

        private void Update()
        {
            // Skip if not triggered.
            if (!_triggerObject) return;
            _timePassed += Time.deltaTime;
            if (_timePassed >= _waitTime)
            {
                _triggerObject = null;
                _interactable.Interact(_triggerObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _timePassed = 0;
                _triggerObject = other.gameObject;
            }
        }
    }
}
