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
    int value;

    private void Start()
    {
        // zdobyte punkty podczas gry
        if (pointsManager.gameObject.GetComponent<PointsController>() != null)
        {
            value = pointsManager.gameObject.GetComponent<PointsController>().GetPoints();
        }
        else
        {
            if (float.TryParse(pointsManager.text, out float result))
            {
                value = Mathf.RoundToInt(result);
                Debug.Log("Conversion successful: " + value);
            }
            else
            {
                Debug.LogError("Failed to convert string to float.");
            }
        }

        if (NewMaxPoint(value))
        {
            actualScore.text = "New max score!";
            maxScore.text = value.ToString();
            gamePointsHolder.UpdateMaxScore(value);
            Debug.Log("Workin?");
        }
        else
        {
            actualScore.text = "score: " + pointsManager.text;
            maxScore.text = "Your max score: " + gamePointsHolder.maxScore.ToString();
        }

        pointsManager.text = actualScore.text;
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
