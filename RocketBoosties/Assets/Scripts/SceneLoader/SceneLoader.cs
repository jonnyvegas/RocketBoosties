using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneLoader : MonoBehaviour, ISceneLoader
{
    [SerializeField] private SceneAsset[] sceneArray;
    [SerializeField] private SceneAsset endScene;
    [SerializeField] private float sceneLoadDelay = 1.0f;
    
    private int currentSceneIdx;
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
            LoadEndScene();
            return;
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

    public IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadNextScene();
    }

    public void LoadScene(int sceneIdx)
    {
        currentSceneIdx = sceneIdx;
        SceneManager.LoadScene(sceneIdx);
    }

    public int GetCurrentSceneIdx()
    {
        return currentSceneIdx;
    }

    public int GetNextSceneIdx()
    {
        if (currentSceneIdx + 1 < sceneArray.Length)
        {
            return currentSceneIdx + 1;
        }

        return 0;
    }

    public float GetSceneLoadDelay()
    {
        return sceneLoadDelay;
    }

    private void LoadEndScene()
    {
        if (endScene)
        {
            SceneManager.LoadScene(endScene.name);
        }
    }

    public void EndGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
