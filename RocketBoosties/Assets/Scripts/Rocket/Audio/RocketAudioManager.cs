using UnityEngine;
using UnityEngine.Serialization;

public class RocketAudioManager : MonoBehaviour, IRocketAudio
{
    private AudioSource thrustAudioSource;
    private AudioSource crashAudioSource;
    private AudioSource successAudioSource;

    private AudioSource[] _audioSources;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSources = gameObject.GetComponents<AudioSource>();
        if (_audioSources.Length == 3)
        {
            thrustAudioSource = _audioSources[0];
            crashAudioSource = _audioSources[1];
            successAudioSource = _audioSources[2];
            Debug.Log("success in rocket audio manager");
        }
        else
        {
            Debug.Log("Did not get 3 audio sources");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOrStopThrustSfx(bool bPlay)
    {
        if (thrustAudioSource)
        {
            if (bPlay)
            {
                if (!GetIsThrustPlaying())
                {
                    thrustAudioSource.Play();
                }
            }
            if(!bPlay && GetIsThrustPlaying())
            {
                thrustAudioSource.Stop();
            }
        }
    }

    public bool GetIsThrustPlaying()
    {
        return thrustAudioSource.isPlaying;
    }

    public void PlayCrashSfx()
    {
        Debug.Log("Play crash sfx");
        if (crashAudioSource && !crashAudioSource.isPlaying)
        {
            crashAudioSource.Play();
        }
    }

    public void PlaySuccessSfx()
    {
        Debug.Log("Play success sfx");

        if (successAudioSource && !successAudioSource.isPlaying)
        {
            successAudioSource.Play();
        }
    }
}
