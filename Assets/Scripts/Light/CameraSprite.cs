using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace Light
{
    public class CameraSprite : MonoBehaviour
    {
        [SerializeField] private Camera _shadowCamera;
        [SerializeField] private RawImage _rawImage;

        private void Update()
        {
            var renderTexture = _shadowCamera.targetTexture;
            var newTexture = new Texture2D(renderTexture.width, renderTexture.height, GraphicsFormat.R8G8B8A8_UNorm, TextureCreationFlags.None);
            newTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height),0 ,0 );
            newTexture.Apply();
            _rawImage.texture = newTexture;
        }
    }
}
