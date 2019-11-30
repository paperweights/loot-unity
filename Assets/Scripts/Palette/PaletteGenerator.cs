using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Palette
{
    public class PaletteGenerator : MonoBehaviour
    {
        [SerializeField] private float _offset;
        [SerializeField] private Vector2Int _textureDimensions;
       private const string FilePath = "Assets/BaseTexture.png";

        private void Awake()
        {
            CreateTexture();
        }

        private void CreateTexture()
        {
            // Create the texture and pixel array.
            var texture2D = new Texture2D(_textureDimensions.x, _textureDimensions.y, GraphicsFormat.R8G8B8A8_SRGB, TextureCreationFlags.None);
            var pixels = new Color[_textureDimensions.x * _textureDimensions.y];
            // Generate the colours of each pixel.
            for (var y = 0; y < _textureDimensions.y; y++)
            {
                for (var x = 0; x < _textureDimensions.x; x++)
                {
                    var i = y * _textureDimensions.x + x;
                    var r = (x + _offset) / _textureDimensions.x;
                    var g = (y + _offset) / _textureDimensions.y;
                    pixels[i] = new Color(r, g, 0);
                }
            }
            // Apply the pixel array.
            texture2D.SetPixels(pixels);
            texture2D.Apply();
            // Save the texture to a file.
            File.WriteAllBytes(FilePath, texture2D.EncodeToPNG());
        }
    }
}
