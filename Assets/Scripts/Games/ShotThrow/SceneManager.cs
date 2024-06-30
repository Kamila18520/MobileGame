using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public string menuScene;
    public string currentScene;

    public void Replay()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
