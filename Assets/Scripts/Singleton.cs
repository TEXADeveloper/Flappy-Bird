using UnityEngine;

public class Singleton : MonoBehaviour
{
    static Singleton singleton;

    void Awake()
    {
        if (singleton != null)
            Destroy(this.gameObject);
        singleton = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
