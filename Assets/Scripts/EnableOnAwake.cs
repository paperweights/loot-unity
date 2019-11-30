using UnityEngine;

public class EnableOnAwake : MonoBehaviour
{
    [SerializeField] private Behaviour[] _behavioursToEnable;

    private void Awake()
    {
        foreach (var behaviour in _behavioursToEnable)
        {
            behaviour.enabled = true;
        }
    }
}
