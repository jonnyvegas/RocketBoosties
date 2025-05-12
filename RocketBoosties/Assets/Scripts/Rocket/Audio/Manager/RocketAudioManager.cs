using UnityEngine;
using UnityEngine.Serialization;

public class RocketAudioManager : MonoBehaviour, IRocketAudioManager
{
    [SerializeField] public GameObject thrustAudioComp;
    [SerializeField] private GameObject crashAudioComp;
    [SerializeField] private GameObject successAudioComp;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOrStopThrustSfx(bool bPlay)
    {
        if (thrustAudioComp && thrustAudioComp.TryGetComponent(out IRocketAudio thrustAudio))
        {
            if (bPlay)
            {
                if (!thrustAudio.GetIsSfxPlaying())
                {
                    thrustAudio.PlaySfx();
                }
            }
            if(!bPlay && thrustAudio.GetIsSfxPlaying())
            {
                thrustAudio.StopSfx();
            }
        }
    }

    public bool GetIsThrustPlaying()
    {
        if (thrustAudioComp && thrustAudioComp.TryGetComponent(out IRocketAudio thrustAudio))
        {
            return thrustAudio.GetIsSfxPlaying();
        }

        return false;
    }

    public void PlayCrashSfx()
    {
        Debug.Log("Play crash sfx");
        if (crashAudioComp && crashAudioComp.TryGetComponent(out IRocketAudio crashAudio))
        {
            if (!crashAudio.GetIsSfxPlaying())
            {
                crashAudio.PlaySfx();
            }
        }
    }

    public void PlaySuccessSfx()
    {
        Debug.Log("Play success sfx");

        if (successAudioComp && successAudioComp.TryGetComponent(out IRocketAudio successAudio))
        {
            if (!successAudio.GetIsSfxPlaying())
            {
                successAudio.PlaySfx();
            }
        }
    }
}
