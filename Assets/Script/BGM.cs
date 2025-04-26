using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    public AudioSource bgmSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }
}
