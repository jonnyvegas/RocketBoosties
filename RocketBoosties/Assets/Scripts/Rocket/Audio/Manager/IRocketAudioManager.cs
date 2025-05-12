using UnityEngine;

public interface IRocketAudioManager
{
    public void PlayOrStopThrustSfx(bool bPlay);
    public bool GetIsThrustPlaying();

    public void PlayCrashSfx();

    public void PlaySuccessSfx();
}
