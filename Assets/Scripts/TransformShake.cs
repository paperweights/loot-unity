using UnityEngine;
using Random = UnityEngine.Random;

public class TransformShake : MonoBehaviour
{
    [SerializeField] private Vector2 _shakeBounds;
    [SerializeField] private float _shakeTime;
    private Vector3 _originalPosition;

    private void Awake()
    {
        _originalPosition = transform.position;
    }

    public void SetShakeTime(float newAmount)
    {
        _shakeTime = newAmount;
        _originalPosition = transform.position;
    }

    private void Update()
    {
        if (_shakeTime > 0)
        {
            _shakeTime -= Time.deltaTime;
            
            var randomX = Random.Range(-_shakeBounds.x, _shakeBounds.x) + _originalPosition.x;
            var randomY = Random.Range(-_shakeBounds.y, _shakeBounds.y) + _originalPosition.y;
            var t = transform;
            var randomPosition = new Vector3(randomX, randomY, _originalPosition.z);
            t.position = randomPosition;
        }
        else
        {
            transform.position = _originalPosition;
        }
    }
}
