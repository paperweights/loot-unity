using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Light
{
    public class LineGenerator : MonoBehaviour
    {
        [SerializeField] private List<LightSource> _lights;
        [SerializeField] private float _shadowLength = 1;
        [SerializeField] private float _distanceOffset;
        [SerializeField] private float _halfTile = 0.8f;
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private GameObject _shadowPrefab;
        private readonly List<Vector2> _blocks = new List<Vector2>();
        private readonly List<Mesh> _meshes = new List<Mesh>();
        private readonly Vector3[] _emptyVertices = new []{Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero};
        private readonly Vector2[][] _points = new[]
        {
            // Stores the min and max points for each point.
            // top
            new[] {new Vector2(float.NegativeInfinity, float.PositiveInfinity), new Vector2(float.PositiveInfinity, float.PositiveInfinity)},
            // down.
            new[] {new Vector2(float.NegativeInfinity, float.NegativeInfinity), new Vector2(float.PositiveInfinity, float.NegativeInfinity)},
            // left.
            new[] {new Vector2(float.NegativeInfinity, float.NegativeInfinity), new Vector2(float.NegativeInfinity, float.PositiveInfinity)},
            // right.
            new[] {new Vector2(float.PositiveInfinity, float.NegativeInfinity), new Vector2(float.PositiveInfinity, float.PositiveInfinity)},
        };
        private void Awake()
        {
            // Find each tile on the tile map.
            var bounds = _tileMap.cellBounds;
            for (var y = 0; y < bounds.size.y; y++)
            {
                for (var x = 0; x < bounds.size.x; x++)
                {
                    var xPosition = x + bounds.position.x;
                    var yPosition = y + bounds.position.y;
                    var tilePosition = new Vector3Int(xPosition, yPosition, 0);
                    var targetTile = _tileMap.GetTile(tilePosition);
                    // Check if the block exists.
                    if (targetTile)
                    {
                        var cellSize = _tileMap.cellSize;
                        var blockPosition = new Vector2(xPosition * cellSize.x + cellSize.x / 2, yPosition * cellSize.y + cellSize.y / 2);
                        _blocks.Add(blockPosition);
                        for (var i = 0; i < 4; i++)
                        {
                            // Create a mew shadow object.
                            var shadowObject = Instantiate(_shadowPrefab, transform);
                            string direction= "a";
                            switch (i)
                            {
                                case 0:
                                    direction = "top";
                                    break;
                                case 1:
                                    direction = "bottom";
                                    break;
                                case 2:
                                    direction = "right";
                                    break;
                                case 3:
                                    direction = "left";
                                    break;
                            }
                            shadowObject.name = $"{x} {y} {direction}";
                            // Create a new mesh for the shadow object.
                            var shadowMesh = new Mesh {vertices = _emptyVertices, triangles = new[] {0, 1, 2, 0, 2, 3}};
                            shadowObject.GetComponent<MeshFilter>().mesh = shadowMesh;
                            _meshes.Add(shadowMesh);
                        }
                    }
                }
            }
        }

        private void Update()
        {
            // Update the shadows of each block.
            for (var i = 0; i < _blocks.Count; i++)
            {
                // Per light shadows.
                var block = _blocks[i];
                // Work out the positions of the shadow object vertices.
                var top = block.y + _halfTile;
                var bottom = block.y - _halfTile;
                var right = block.x + _halfTile;
                var left = block.x - _halfTile;
                        
                var topLeft = new Vector3(left, top);
                var topRight = new Vector3(right, top);
                var bottomLeft = new Vector3(left, bottom);
                var bottomRight = new Vector3(right, bottom);
                // Store the max and min positions for each quad.
                var points = _points;
                for (var j = 0; j < _lights.Count; j++)
                {
                    var index = i * 4;
                    var lightPos = _lights[j].transform.position - new Vector3(.8f, .8f, 0);
                    var distance = Vector3.Distance(lightPos, block);
                    
                    if (distance < _lights[j].GetMaxLightRadius() + _distanceOffset)
                    {
                        
                        
                        // Change the 4 meshes.
                        // Top.
                        if (top < lightPos.y)
                        {
                            var bl = bottomLeft + (topLeft - lightPos) * _shadowLength;
                            var br = bottomRight + (topRight - lightPos) * _shadowLength;
                            _meshes[index].vertices = new[] {bl, topLeft, topRight, br};
                        }
                        else
                        {
                            _meshes[index].vertices = _emptyVertices;
                        }
                        // Bottom.
                        if (bottom > lightPos.y)
                        {
                            var tl = topLeft + (bottomLeft - lightPos) * _shadowLength;
                            var tr = topRight + (bottomRight - lightPos) * _shadowLength;
                            _meshes[index + 1].vertices = new[] {bottomLeft, tl, tr, bottomRight};
                        }
                        else
                        {
                            _meshes[index + 1].vertices = _emptyVertices;
                        }
                        // Right.
                        if (lightPos.x > right)
                        {
                            var tl = topLeft + (topRight - lightPos) * _shadowLength;
                            var bl = bottomLeft + (bottomRight - lightPos) * _shadowLength;
                            _meshes[index + 2].vertices = new[] {bl, tl, topRight, bottomRight};
                        }
                        else
                        {
                            _meshes[index + 2].vertices = _emptyVertices;
                        }
                        // Left.
                        if (lightPos.x < left)
                        {
                            var tr = topRight + (topLeft - lightPos) * _shadowLength;
                            var br = bottomRight + (bottomLeft - lightPos) * _shadowLength;
                            _meshes[index + 3].vertices = new[] {bottomLeft, topLeft, tr, br};
                        }
                        else
                        {
                            _meshes[index + 3].vertices = _emptyVertices;
                        }
                    }
                    else
                    {
                        for (var k = 0; k < 4; k++)
                        {
                            _meshes[index + k].vertices = _emptyVertices;
                        }
                    }
                }
            }
        }
    }
}