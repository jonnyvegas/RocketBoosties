using System.Collections;
using UnityEngine;

public interface ISceneLoader
{
    void LoadDefaultScene();
    void LoadScene(string sceneName);
    void LoadNextScene();
    void LoadCurrentScene();
    IEnumerator LoadSceneAfterDelay(int sceneIdx, float delay);
    int GetCurrentSceneIdx();
    float GetSceneLoadDelay();
}