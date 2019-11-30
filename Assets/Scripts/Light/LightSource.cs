using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Light
{
    public class LightSource : MonoBehaviour
    {
        [SerializeField] private float[] _lightLengths;
        [SerializeField] private string _sortingLayer = "Darkness";
        [SerializeField] private float _flicker = 0.4f;
        [SerializeField] private float _lifetime;
        [SerializeField] private Sprite _maskSprite;
        private List<SpriteMask> _spriteMasks;
        private int _sortingLayerId;

        public float GetMaxLightRadius()
        {
            return 1;
        }

        private void Awake()
        {
            _sortingLayerId = SortingLayer.NameToID(_sortingLayer);
        }

        private void Start()
        {
            _spriteMasks = new List<SpriteMask>();
            // Create the sprite masks.
            for (var i = 0; i < _lightLengths.Length; i++)
            {
                // Create a new object with a sprite mask.
                var spriteObject = new GameObject($"Sprite Mask {i}", typeof(SpriteMask));
                // Configure the transform of the new object.
                spriteObject.transform.SetParent(transform);
                spriteObject.transform.localPosition = Vector3.zero;
                // Configure the sprite mask component of the new object.
                var spriteMask = spriteObject.GetComponent<SpriteMask>();
                _spriteMasks.Add(spriteMask);
                spriteMask.sprite = _maskSprite;
                spriteMask.isCustomRangeActive = true;
                // Configure the sorting order of the sprite mask.
                spriteMask.frontSortingOrder = 11 + i;
                spriteMask.frontSortingLayerID = _sortingLayerId;
                spriteMask.backSortingLayerID = _sortingLayerId;
                spriteMask.backSortingOrder = 10 + i;
            }
        }

        private void Update()
        {
            // Update the lifetime of the light.
            if (_lifetime > 0)
            {
                _lifetime -= Time.deltaTime;
            }
            else if (_lifetime < 0)
            {
                Destroy(gameObject, 2f);
            }
            // Update the scale.
            for (var i = 0; i < _lightLengths.Length; i++)
            {
                var flickerLength = Random.Range(_lightLengths[i], _lightLengths[i] + _flicker);
                var finalScale = flickerLength;
                _spriteMasks[i].transform.localScale = new Vector3(finalScale, finalScale, 0);
            }
        }
    }
}
