using UnityEngine;

public interface ISceneLoader
{
    void LoadDefaultScene();
    void LoadScene(string sceneName);
}