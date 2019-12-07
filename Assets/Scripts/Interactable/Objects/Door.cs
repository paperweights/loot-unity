using UnityEngine;

namespace Interactable.Objects
{
    public class Door : InteractableObject
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private InteractableTrigger _interactableTrigger;
        private static readonly int Open = Animator.StringToHash("Open");

        public override void Interact(GameObject owner)
        {
            base.Interact(owner);
            
            _animator.SetTrigger(Open);
            // Single time interaction.
            _interactableTrigger.gameObject.SetActive(false);
        }
    }
}