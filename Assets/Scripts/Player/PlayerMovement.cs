using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rb2D;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        private void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            // Get input.
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            // Animate.
            _animator.SetTrigger(Mathf.Abs(h) + Mathf.Abs(v) > 0 ? Walk : Idle);
            if (Math.Abs(h) > 0)
            {
                _spriteRenderer.flipX = h < 0;
            }
            // Move the player.
            var moveVector = new Vector3(h, v).normalized * _speed;
            _rb2D.MovePosition(transform.position + moveVector);
        }
    }
}