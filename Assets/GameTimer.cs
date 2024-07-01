using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{

    public float timeRemaining = 15f;
    public TMP_Text timerText;
    public TMP_Text gameOverText;

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("TimerText nie jest przypisany!");
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); 
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            timeRemaining = 0;
            EndGame();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void EndGame()
    {
      
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over";
        }

        
        Time.timeScale = 0f;

    }
}
