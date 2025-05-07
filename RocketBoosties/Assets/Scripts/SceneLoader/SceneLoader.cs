using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, ISceneLoader
{
    private string defaultSceneName;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultSceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDefaultScene()
    {
        SceneManager.LoadScene(defaultSceneName);
    }

    public void LoadScene(string sceneName)
    {
        
    }
}
