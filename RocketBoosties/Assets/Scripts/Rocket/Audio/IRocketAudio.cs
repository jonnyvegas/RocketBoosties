using UnityEngine;

public interface IRocketAudio
{
    public void PlayOrStopThrustSfx(bool bPlay);
    public bool GetIsPlaying();
}
