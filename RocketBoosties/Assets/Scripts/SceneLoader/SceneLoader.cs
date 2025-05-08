using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneLoader : MonoBehaviour, ISceneLoader
{
    [SerializeField] private SceneAsset[] sceneArray;
    private int currentSceneIdx;
    
    [SerializeField] private float sceneLoadDelay = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSceneIdx = 0;
        DontDestroyOnLoad(this.gameObject);
        
    }

    public void LoadDefaultScene()
    {
        currentSceneIdx = 0;
        LoadScene(currentSceneIdx);
        
    }

    public void LoadScene(string sceneName)
    {
        
    }

    public void LoadNextScene()
    {
        //Debug.Log("current index" + currentSceneIdx);
        currentSceneIdx++;
        //Debug.Log("current index after increment " + currentSceneIdx);
        if (currentSceneIdx >= sceneArray.Length)
        {
            currentSceneIdx = 0;
            //Debug.Log("resetting index to 0");
        }
        LoadCurrentScene();
    }

    public void LoadCurrentScene()
    {
        LoadScene(currentSceneIdx);
    }

    public IEnumerator LoadSceneAfterDelay(int sceneIdx, float delay)
    {
        //Debug.Log("Begin load scene after delay");
        yield return new WaitForSeconds(delay);
        //Debug.Log("ready to load scene after delay");
        LoadScene(sceneIdx);
        
    }

    public void LoadScene(int sceneIdx)
    {
        SceneManager.LoadScene(sceneIdx);
    }

    public int GetCurrentSceneIdx()
    {
        return currentSceneIdx;
    }

    public float GetSceneLoadDelay()
    {
        return sceneLoadDelay;
    }
}
