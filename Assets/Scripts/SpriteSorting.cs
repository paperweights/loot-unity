using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSorting : MonoBehaviour
{
    [SerializeField] private int _pixelsPerUnit = 100;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Work out the target sorting order.
        var targetSortingOrder = -Mathf.RoundToInt(transform.position.y * _pixelsPerUnit);
        // Apply the target sorting order.
        _spriteRenderer.sortingOrder = targetSortingOrder;
    }
}