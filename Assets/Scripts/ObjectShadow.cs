using UnityEngine;

public class ObjectShadow : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _scale = Vector2.one;
    [SerializeField] private GameObject _shadowPrefab;
    private GameObject _shadow;

    private void Start()
    {
        _shadow = Instantiate(_shadowPrefab, transform);
        _shadow.transform.localScale = _scale;
        _shadow.transform.position = _offset;
    }

    private void Update()
    {
        _shadow.transform.position = _offset;
    }
}
