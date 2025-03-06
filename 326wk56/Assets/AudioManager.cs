using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // 单例模式

    public AudioMixerGroup sfxGroup; // 连接 Audio Mixer SFX 组
    public AudioSource sfxSource; // 用于播放音效

    public AudioClip shootSound;
    public AudioClip scoreSound;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayShootSound()
    {
        sfxSource.PlayOneShot(shootSound);
    }

    public void PlayScoreSound()
    {
        sfxSource.PlayOneShot(scoreSound);
    }
}
