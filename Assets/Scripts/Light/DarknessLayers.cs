using System;
using System.Collections.Generic;
using UnityEngine;

namespace Light
{
    public class DarknessLayers : MonoBehaviour
    {
        [SerializeField] private Color[] _layerColours;
        [SerializeField] private string _sortingLayer = "Darkness";
        [SerializeField] private int _layerOffset = 10;
        [SerializeField] private Material _layerMaterial;
        [SerializeField] private Vector3 _layerScale;
        [SerializeField] private Sprite _layerSprite;
        private int _sortingLayerId;

        private void Awake()
        {
            // Get the soring layer ID.
            _sortingLayerId = SortingLayer.NameToID(_sortingLayer);
            // Create the layers of darkness.
            for (var i = 0; i < _layerColours.Length; i++)
            {
                SpawnLayer(i);
            }
        }

        private SpriteRenderer SpawnLayer(int order)
        {
            // Create the new layer game object.
            var newLayer = new GameObject($"Darkness Layer {order}", typeof(SpriteRenderer));
            // Parent the layer over the object with this script.
            var t = newLayer.transform;
            t.parent = transform;
            t.localScale = _layerScale;
            t.localPosition = Vector3.zero;
            // Change the properties of the sprite renderer.
            var spriteRender = newLayer.GetComponent<SpriteRenderer>();
            spriteRender.sortingLayerID = _sortingLayerId;
            spriteRender.sharedMaterial = _layerMaterial;
            spriteRender.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            spriteRender.sprite = _layerSprite;
            spriteRender.color = _layerColours[order];
            spriteRender.sortingOrder = _layerOffset + order;
            return spriteRender;
        }
    }
}
