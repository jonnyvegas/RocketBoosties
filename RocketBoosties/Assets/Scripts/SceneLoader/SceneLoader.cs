using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneLoader : MonoBehaviour, ISceneLoader
{
    [SerializeField] private Scene[] sceneArray;
    [SerializeField] private Scene endScene;
    [SerializeField] private float sceneLoadDelay = 1.0f;
    
    private int currentSceneIdx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        sceneArray = new Scene[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            sceneArray[i] = SceneManager.GetSceneByBuildIndex(i);
        }
        currentSceneIdx = 1;
        DontDestroyOnLoad(this.gameObject);
        
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            EndGame();
        }
    }

    public void LoadDefaultScene()
    {
        currentSceneIdx = 1;
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
        if (currentSceneIdx >= sceneArray.Length - 1)
        {
            currentSceneIdx = 1;
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
        if (currentSceneIdx + 1 < sceneArray.Length - 1)
        {
            return currentSceneIdx + 1;
        }

        return 1;
    }

    public float GetSceneLoadDelay()
    {
        return sceneLoadDelay;
    }

    private void LoadEndScene()
    {
        
        SceneManager.LoadScene(sceneArray.Length - 1);
        
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
