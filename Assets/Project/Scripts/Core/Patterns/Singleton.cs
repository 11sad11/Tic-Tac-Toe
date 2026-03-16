using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual bool isPersistent => true;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            if (isPersistent) DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }
}