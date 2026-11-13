using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource sfxSource;


    void Awake()
    {
        if(Instance != null&& Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }

    }



    public void PlaySfx(AudioClip clip)
    {
        if(clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
