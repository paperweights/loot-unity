using UnityEngine;

public class WindowScale : MonoBehaviour
{
    [SerializeField] private int _scale = 2;
    private Vector2Int _baseDimensions;
    private void OnEnable()
    {
        _baseDimensions = new Vector2Int(288, 288);
        UpdateScreenSize();
    }

    public void UpdateScreenSize()
    {
        var scaledSize = _baseDimensions * _scale;
        
        #if UNITY_STANDALONE
        Screen.SetResolution(scaledSize.x, scaledSize.y, FullScreenMode.Windowed);
        #endif
    }
}
