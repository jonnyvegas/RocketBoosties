using UnityEngine;

public interface IRocketAudio
{
    public void PlayOrStopThrustSfx(bool bPlay);
    public bool GetIsPlaying();
}
public class RocketAudio : MonoBehaviour, IRocketAudio
{
    private AudioSource _thrustAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _thrustAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOrStopThrustSfx(bool bPlay)
    {
        if (_thrustAudioSource)
        {
            if (bPlay)
            {
                if (!GetIsPlaying())
                {
                    _thrustAudioSource.Play();
                }
            }
            if(!bPlay && GetIsPlaying())
            {
                _thrustAudioSource.Stop();
            }
        }
    }

    public bool GetIsPlaying()
    {
        return _thrustAudioSource.isPlaying;
    }
    
}
