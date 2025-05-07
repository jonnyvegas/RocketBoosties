using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SceneLoader : MonoBehaviour, ISceneLoader
{
    [SerializeField] private SceneAsset[] sceneArray;
    private int currentSceneIdx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSceneIdx = 0;
        DontDestroyOnLoad(this.gameObject);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDefaultScene()
    {
        currentSceneIdx = 0;
        SceneManager.LoadScene(currentSceneIdx);
        
    }

    public void LoadScene(string sceneName)
    {
        
    }

    public void LoadNextScene()
    {
        Debug.Log("current index" + currentSceneIdx);
        currentSceneIdx++;
        Debug.Log("current index after increment " + currentSceneIdx);
        if (currentSceneIdx >= sceneArray.Length)
        {
            currentSceneIdx = 0;
            Debug.Log("resetting index to 0");
        }
        SceneManager.LoadScene(currentSceneIdx);
    }
}
