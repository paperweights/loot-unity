using UnityEngine;

namespace Cam
{
    public class RoomCamera : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _speed = .1f;
        [SerializeField] private Vector2 _roomSize;
        [SerializeField] private Transform _followTransform;
        private Vector3 _offset;

        private void Awake()
        {
            _offset = transform.position;
        }

        private void Update()
        {
            var position = _followTransform.position;
            var targetX = Mathf.Round((position.x - _offset.x) / _roomSize.x) * _roomSize.x;
            var targetY = Mathf.Round((position.y - _offset.y) / _roomSize.y) * _roomSize.y;
            var offsetPosition = new Vector3(targetX, targetY, 0) + _offset;
            var targetPosition = Vector3.Lerp(transform.position, offsetPosition, _speed);
            transform.position = targetPosition;
        }
    }
}
