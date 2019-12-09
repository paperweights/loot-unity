using System;
using Player;
using UnityEngine;

namespace Interactable.Traps
{
    public class SpikeTrap : InteractableObject
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _closeDelay = 1;
        private Animator _animator;
        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().Hurt(_damage);
            }
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public override void Interact(GameObject owner)
        {
            base.Interact(owner);
            _animator.SetTrigger(Open);
            Invoke(nameof(CloseAnimator), _closeDelay);
        }

        private void CloseAnimator()
        {
            _animator.SetTrigger(Close);
        }
    }
}
