using UnityEngine;
using UnityEngine.Serialization;

public class RocketParticleManager : MonoBehaviour, IRocketParticleManager
{
    [SerializeField] private GameObject explosionParticleGameObject;
    [SerializeField] private GameObject successParticleGameObject;
    [SerializeField] private GameObject thrustParticleGameObject;

    private ParticleSystem _explosionParticleSystem;
    private ParticleSystem _successParticleSystem;
    private ParticleSystem _thrustParticleSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _explosionParticleSystem = explosionParticleGameObject.GetComponent<ParticleSystem>();
        _successParticleSystem = successParticleGameObject.GetComponent<ParticleSystem>();
        _thrustParticleSystem = thrustParticleGameObject.GetComponent<ParticleSystem>();
        _thrustParticleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnExplosionAtLocation(Vector3 location)
    {
        if (explosionParticleGameObject && _explosionParticleSystem)
        {
            explosionParticleGameObject.transform.position = location;
            _explosionParticleSystem.Play();
        }
    }

    public void SpawnSuccessParticlesAtLoc(Vector3 location)
    {
        if (successParticleGameObject && _successParticleSystem)
        {
            successParticleGameObject.transform.position = location;
            _successParticleSystem.Play();
        }
    }

    public void PlayOrStopThrustParticles(bool bPlay)
    {
        if (thrustParticleGameObject && _thrustParticleSystem)
        {
            if (!_thrustParticleSystem.isEmitting && bPlay)
            {
                _thrustParticleSystem.Play();
            }
            else
            {
                _thrustParticleSystem.Stop();
            }
        }
    }
}
