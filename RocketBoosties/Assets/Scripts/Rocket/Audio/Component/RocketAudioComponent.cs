using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RocketAudioComponent : MonoBehaviour, IRocketAudio
{
    [SerializeField] private AudioClip audioClip;
    private AudioSource _audioSource;

    protected virtual void Start()
    {
        //Debug.Log("Calling start");
        _audioSource = this.gameObject.AddComponent<AudioSource>();
        _audioSource.clip = audioClip;
        //Debug.Log("Setting audio source clip to " + audioClip.name);
        _audioSource.loop = false;
    }

    public void PlaySfx()
    {
        if (_audioSource)
        {
            _audioSource.Play();
        }
    }

    public void StopSfx()
    {
        if (GetIsSfxPlaying() && _audioSource)
        {
            _audioSource.Stop();
        }
    }

    public bool GetIsSfxPlaying()
    {
        if (_audioSource)
        {
            return _audioSource.isPlaying;
        }

        return false;
    }
}
