using UnityEngine;

namespace Interactable
{
    public class InteractableObject : MonoBehaviour
    {
        public virtual void Interact(GameObject owner) {}
    }
}