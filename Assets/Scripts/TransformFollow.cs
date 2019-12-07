using UnityEngine;

public class TransformFollow : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _speed = 0.1f;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _targetTransform;

    private void Update()
    {
        var targetPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset, _speed);
        transform.position = targetPosition;
    }
}
