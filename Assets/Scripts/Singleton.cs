using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton _singleton;

    private void Awake()
    {
        if (this != _singleton && _singleton)
        {
            Destroy(gameObject);
        }
        else
        {
            _singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
