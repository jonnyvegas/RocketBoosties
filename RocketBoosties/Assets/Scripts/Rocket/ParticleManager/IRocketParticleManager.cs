using UnityEngine;

public interface IRocketParticleManager
{
    public void SpawnExplosionAtLocation(Vector3 location);
    public void SpawnSuccessParticlesAtLoc(Vector3 location);

    public void PlayOrStopThrustParticles(bool bPlay);
}
