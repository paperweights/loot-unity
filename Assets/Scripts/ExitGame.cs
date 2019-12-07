using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private KeyCode _exitKey = KeyCode.Escape;

    private void Update()
    {
        if (Input.GetKeyDown(_exitKey))
        {
            Exit();
        }
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
    }
}
