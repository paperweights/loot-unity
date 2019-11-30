using UnityEngine;

namespace Cam
{
    public class CamFollow : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _speed;
        [SerializeField] private Transform _targetTransform;
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * 10;
            var targetPosition = Vector3.Lerp(_targetTransform.position, mousePosition, _speed);
            transform.position = targetPosition;
        }
    }
}
