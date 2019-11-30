using System;
using UnityEngine;

namespace Light
{
    public class LightableObject : MonoBehaviour
    {
        [SerializeField] private GameObject _lightPrefab;
        [SerializeField] private float _lightTime;
        private float _timeSinceLit;
        private Animator _animator;
        private GameObject _activeLight;
        private static readonly int Light = Animator.StringToHash("Light");
        private static readonly int Unlight = Animator.StringToHash("Unlight");

        private void Awake()
        {
            _timeSinceLit = _lightTime;
            _animator =GetComponent<Animator>();
        }

        public void LightUp()
        {
            // Destroy an existing light.
            if (_activeLight)
            {
                Destroy(_activeLight);
            }
            // Create a new light.
            _activeLight = Instantiate(_lightPrefab, transform);
            _timeSinceLit = 0;
        }

        private void Update()
        {
            _timeSinceLit += Time.deltaTime;
            _timeSinceLit = Mathf.Clamp(_timeSinceLit, 0, _lightTime);
            _animator.SetTrigger(_timeSinceLit < _lightTime ? Light : Unlight);
        }
    }
}
