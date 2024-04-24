using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] UnityEngine.Object menuScene;
    [Header("Panel scores")]
    [SerializeField] TextMeshProUGUI actualScore;
    [SerializeField] TextMeshProUGUI maxScore;

    [Header("PointsHolder")]

    [SerializeField] TextMeshProUGUI pointsManager;
    [SerializeField] GamePointsHolder gamePointsHolder;


    public UnityEvent stopGame;

    private void Awake()
    {
        //zdobyte pkt podczas gry
        int value = pointsManager.gameObject.GetComponent<PointsController>().points;

        if(NewMaxPoint(value))
        {
            actualScore.text = "New max score!";
            maxScore.text = value.ToString();
            gamePointsHolder.maxScore = value;
        }
        else
        {
            actualScore.text = "score: " + pointsManager.text;
            maxScore.text = "Your max score: " + gamePointsHolder.maxScore.ToString();
        }

        pointsManager.text =actualScore.text;
        stopGame.Invoke();
    }

    private bool NewMaxPoint(int value)
    {
        return value > gamePointsHolder.maxScore;
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
