using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour, ICollisionHandler
{
    public GameObject sceneLoader;
    public void Start()
    {
        sceneLoader = GameObject.Find("SceneLoadObject");
 
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
                Debug.Log("CollisionHandler - finished!");
                if (sceneLoader.TryGetComponent(out ISceneLoader sceneLoaderRef))
                {
                    sceneLoaderRef.LoadNextScene();
                }
                break;
            case "Fuel":
                // We might not need this, but in future may need fuel which is needed to continue flying.
                Debug.Log("CollisionHandler - fuel!");
                break;
            case "Friendly":
                // This is the tag of the beginning object, but also more likely other objects that are
                // "friendly", aka, those that don't hurt us but don't do anything special. Anything
                // to make the pretty boy feel special.
                Debug.Log("CollisionHandler - friendly!");
                break;
            default:
                // Blow it up! - it is not in the list of things that don't blow us up.
                Debug.Log("CollisionHandler - default! blow up!");
                if (sceneLoader.TryGetComponent(out ISceneLoader loader))
                {
                    loader.LoadDefaultScene();
                }
                break;
        }
    }
}
