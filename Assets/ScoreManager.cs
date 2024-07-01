using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PointsController controllerRef;
    [SerializeField] private GamePointsHolder holderRef;
    public static ScoreManager instance;
    public TMP_Text scoreText;  
    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        //UpdateScoreText();

        controllerRef.IncrementPoints(points);

        if (score > holderRef.maxScore)
        {
            holderRef.UpdateMaxScore(score);
        }
    }

    public void SubtractScore(int points)
    {
        score -= points;
        //UpdateScoreText();

        controllerRef.DeductPoints(points);

        if (score > holderRef.maxScore)
        {
            holderRef.UpdateMaxScore(score);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            //scoreText.text = "Score: " + score.ToString();
            scoreText.text = score.ToString();
        }
    }
}
