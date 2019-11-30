using UnityEngine;

namespace Palette
{
    [ExecuteInEditMode]
    public class PaletteSwap : MonoBehaviour
    {
        [SerializeField] private Material _material;

        private void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            Graphics.Blit(src, dst, _material);
        }
    }
}
