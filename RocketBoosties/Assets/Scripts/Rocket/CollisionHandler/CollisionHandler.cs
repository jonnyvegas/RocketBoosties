using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour, ICollisionHandler
{
    private GameObject _sceneLoader;
    private IEnumerator _crashCoroutine;
    private IEnumerator _successCoroutine;
    public void Start()
    {
        _sceneLoader = GameObject.FindGameObjectWithTag("Scene");
 
        //
    }

    public void SetSceneLoaderRef(GameObject sceneLoader)
    {
        this._sceneLoader = sceneLoader;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (TryGetComponent(out IRocketMovement rocketMovement))
        {
            if (rocketMovement.MovementEnabled())
            {
                switch (other.gameObject.tag)
                {
                    case "Finish":
                        // We finished the game! call something to finish. Not sure which gameObject but can
                        // keep reference in a script in rocket, perhaps?
                        // Debug.Log("CollisionHandler - finished!");
                        Success();
                        break;
                    case "Fuel":
                        // We might not need this, but in future may need fuel which is needed to continue flying.
                        //Debug.Log("CollisionHandler - fuel!");
                        break;
                    case "Friendly":
                        // This is the tag of the beginning object, but also more likely other objects that are
                        // "friendly", aka, those that don't hurt us but don't do anything special. Anything
                        // to make the pretty boy feel special.
                        // Debug.Log("CollisionHandler - friendly!");
                        break;
                    default:
                        // Blow it up! - it is not in the list of things that don't blow us up.
                        // Debug.Log("CollisionHandler - default! blow up!");
                        StartCrashSequence();
                        break;
                }
            }
        }
        
    }

    private void StartCrashSequence()
    {
        // Invoke the scene stuff so that we can have it load later.
        if (_sceneLoader.TryGetComponent(out ISceneLoader loader))
        {
            _crashCoroutine = loader.LoadSceneAfterDelay(loader.GetCurrentSceneIdx(), loader.GetSceneLoadDelay());
            // Don't forget to call StartCoroutine or the function is just waiting to be called. It won't
            // work until you start the coroutine KEKW
            StartCoroutine(_crashCoroutine);
            //loader.LoadCurrentScene();
        }
                
        DisableRocketMovement();

        if (TryGetComponent(out IRocketAudioManager audio))
        {
            audio.PlayCrashSfx();
        }
    }

    private void Success()
    {
        if (_sceneLoader.TryGetComponent(out ISceneLoader sceneLoaderRef))
        {
            _successCoroutine = sceneLoaderRef.LoadSceneAfterDelay(
                sceneLoaderRef.GetNextSceneIdx(),
                sceneLoaderRef.GetSceneLoadDelay());
            StartCoroutine(_successCoroutine);
            //sceneLoaderRef.LoadNextScene();
        }

        if (TryGetComponent(out IRocketAudioManager audio))
        {
            audio.PlaySuccessSfx();
        }
        DisableRocketMovement();
        
    }

    private void DisableRocketMovement()
    {
        if (TryGetComponent(out IRocketMovement movement))
        {
            movement.InvokeDisableMovement();
        }
    }
}
