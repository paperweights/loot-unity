using Player;
using UnityEngine;

namespace Interactable.Objects
{
    public class Chest : InteractableObject
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private InteractableTrigger _interactableTrigger;
        [SerializeField] private int _minCoins, _maxCoins;
        private static readonly int Open = Animator.StringToHash("Open");

        public override void Interact(GameObject owner)
        {
            base.Interact(owner);
            _interactableTrigger.gameObject.SetActive(false);
            // Give coins.
            var coinAmount = Random.Range(_minCoins, _maxCoins);
            owner.GetComponent<PlayerInventory>().ChangeCoins(coinAmount);
            
            _particleSystem.Play();
            _animator.SetTrigger(Open);
        }
    }
}