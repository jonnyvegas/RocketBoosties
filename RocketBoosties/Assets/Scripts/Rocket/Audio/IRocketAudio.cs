using UnityEngine;

public interface IRocketAudio
{
    public void PlayOrStopThrustSfx(bool bPlay);
    public bool GetIsThrustPlaying();

    public void PlayCrashSfx();

    public void PlaySuccessSfx();
}
