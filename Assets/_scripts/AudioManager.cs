using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource soundSource;
    public AudioSource soundSourceBG;
    public AudioClip bgSound;
    public AudioClip[] soundClips;
    public AudioMixer soundMixer;


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
        SetVolumeToPlayerPrefs();
    }

    private void Start()
    {
        // Attach the soundSource to the Mixer's exposed volume parameter
        soundSourceBG.outputAudioMixerGroup = soundMixer.FindMatchingGroups("Music")[0]; // Change "SFX" to your group name
        soundSource.outputAudioMixerGroup = soundMixer.FindMatchingGroups("SFX")[0]; // Change "SFX" to your group name
        soundSourceBG.PlayOneShot(bgSound);
    }
    public void PlaySound(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < soundClips.Length)
        {
            soundSource.PlayOneShot(soundClips[soundIndex]);
        }
        else
        {
            Debug.LogWarning("Sound index out of range");
        }
    }

    public void SetVolumeToPlayerPrefs()
    {
        soundSource.volume = PlayerPrefs.GetFloat(GameConstants.SFX_SPEED);
        soundSourceBG.volume = PlayerPrefs.GetFloat(GameConstants.MUSIC_SPEED);
    }
}
