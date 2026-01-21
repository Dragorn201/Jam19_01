using UnityEngine;

public class audioManager : MonoBehaviour
{
    private static audioManager _instance;

    public static audioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("audioManager not found");
            }
            return _instance;
        }
    }
    
    
    [Header("AudioClips")]
    [SerializeField] private AudioClip[] _sfxClip;
    [SerializeField] private AudioClip[] _musicClip;
    
    [Header("AudioSources")]
    [SerializeField] private AudioSource _sfxAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySfxClip(int value)
    {
        if (value < 0 || value > _sfxClip.Length)
        {
            _sfxAudioSource.Pause();
            return;
        }
        _sfxAudioSource.clip = _sfxClip[value];
        _sfxAudioSource.Play();
    }

    public void PlayMusicClip(int value)
    {
        if (value < 0 || value > _musicClip.Length)
        {
            _musicAudioSource.Pause();
            return;
        }
        _musicAudioSource.clip = _musicClip[value];
        _musicAudioSource.Play();
    }
    
    
}
