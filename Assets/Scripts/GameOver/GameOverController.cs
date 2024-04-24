using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] UnityEngine.Object menuScene;

    public UnityEvent stopGame;

    private void Awake()
    {
        stopGame.Invoke();
    }

    public void BackToMenu()
    {
        Debug.Log("Back to menu");
        SceneManager.LoadScene(menuScene.name);

    }

    public void Replay()
    {
        Debug.Log("Replay actual game");

        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }

}
