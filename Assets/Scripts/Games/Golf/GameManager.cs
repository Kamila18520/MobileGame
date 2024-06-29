using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText; // Zmieniamy na TMP_Text
    public TMP_Text timerText; // Zmieniamy na TMP_Text
    public float gameTime = 60f; // czas gry w sekundach

    private float timer;
    private int score;
    private bool isGameActive;

    private void Start()
    {
        timer = gameTime;
        UpdateTimerText();
        score = 0;
        UpdateScoreText();
        isGameActive = true;
    }

    private void Update()
    {
        if (isGameActive)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            isGameActive = false;
            // Tutaj mo¿esz dodaæ logikê koñca gry lub inn¹ odpowiedni¹ akcjê
        }
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timer).ToString();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

