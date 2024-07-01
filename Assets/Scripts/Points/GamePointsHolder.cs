using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "[Game]MaxScore", menuName = "MaxScore/NewMaxScore")]
public class GamePointsHolder : ScriptableObject
{
    public string identifier; // Unique identifier for each ScriptableObject
    public float maxScore;

    private void OnEnable()
    {
        LoadMaxScore();
    }

    private void OnDisable()
    {
        SaveMaxScore();
    }

    public void SaveMaxScore()
    {
        string key = GetMaxScoreKey();
        PlayerPrefs.SetFloat(key, maxScore);
        PlayerPrefs.Save();
    }

    public void LoadMaxScore()
    {
        string key = GetMaxScoreKey();
        if (PlayerPrefs.HasKey(key))
        {
            maxScore = PlayerPrefs.GetFloat(key);
        }
        else
        {
            maxScore = 0f; // Default value if no score is saved
        }
    }

    private string GetMaxScoreKey()
    {
        return "MaxScore_" + identifier;
    }

    // This method can be called to update the score and save it immediately
    public void UpdateMaxScore(float newScore)
    {
        maxScore = newScore;
        SaveMaxScore();
    }
}
