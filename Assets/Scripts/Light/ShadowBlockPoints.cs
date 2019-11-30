using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Light
{
    public class ShadowBlockPoints : MonoBehaviour
    {
        [SerializeField] private Tilemap _shadowTilemap;
        private List<Vector2> _blockPoints = new List<Vector2>();

        public Vector2[] GetBlockPoints()
        {
            return _blockPoints.ToArray();
        }
        private void Awake()
        {
            // Find each tile on the tile map.
            var bounds = _shadowTilemap.cellBounds;
            for (var y = 0; y < bounds.size.y; y++)
            {
                for (var x = 0; x < bounds.size.x; x++)
                {
                    var xPosition = x + bounds.position.x;
                    var yPosition = y + bounds.position.y;
                    var tilePosition = new Vector3Int(xPosition, yPosition, 0);
                    var targetTile = _shadowTilemap.GetTile(tilePosition);
                    // Check if the block exists.
                    if (targetTile)
                    {
                        var cellSize = _shadowTilemap.cellSize;
                        var blockPosition = new Vector2(xPosition * cellSize.x + cellSize.x, yPosition * cellSize.y + cellSize.y);
                        _blockPoints.Add(blockPosition);
                    }
                }
            }
        }
    }
}
