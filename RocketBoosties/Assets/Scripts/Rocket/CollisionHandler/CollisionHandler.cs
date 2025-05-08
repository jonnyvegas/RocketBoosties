using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour, ICollisionHandler
{
    public GameObject sceneLoader;
    private IEnumerator coroutine;
    public void Start()
    {
        sceneLoader = GameObject.FindGameObjectWithTag("Scene");
 
        //
    }

    public void SetSceneLoaderRef(GameObject sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                // We finished the game! call something to finish. Not sure which gameObject but can
                // keep reference in a script in rocket, perhaps?
               // Debug.Log("CollisionHandler - finished!");
                if (sceneLoader.TryGetComponent(out ISceneLoader sceneLoaderRef))
                {
                    sceneLoaderRef.LoadNextScene();
                }
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

    private void StartCrashSequence()
    {
        // Invoke the scene stuff so that we can have it load later.
        if (sceneLoader.TryGetComponent(out ISceneLoader loader))
        {
            coroutine = loader.LoadSceneAfterDelay(loader.GetCurrentSceneIdx(), loader.GetSceneLoadDelay());
            // Don't forget to call StartCoroutine or the function is just waiting to be called. It won't
            // work until you start the coroutine KEKW
            StartCoroutine(coroutine);
            //loader.LoadCurrentScene();
        }
                
        // All you need to know is there's an interface that we call to disable movement.
        if (TryGetComponent(out IRocketMovement movement))
        {
            //Debug.Log("we got IRocketMovement");
            movement.InvokeDisableMovement();
        }
    }
}
