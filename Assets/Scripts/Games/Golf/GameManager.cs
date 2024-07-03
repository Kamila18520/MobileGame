using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Dodajemy using dla TextMeshPro
using UnityEngine.SceneManagement; // Dodajemy using dla zarz�dzania scenami
using UnityEngine.UI; // Dodajemy using dla UI

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText; // Zmieniamy na TMP_Text
    public TMP_Text timerText; // Zmieniamy na TMP_Text
    public TMP_Text endGameText; // Dodajemy TMP_Text dla ko�ca gry
    public Button restartButton; // Dodajemy przycisk restartu
    public Button menuButton; // Dodajemy przycisk powrotu do menu
    public GameObject endGamePanel; // Dodajemy panel t�a
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

        endGameText.gameObject.SetActive(false); // Ukryj tekst ko�ca gry na pocz�tku
        restartButton.gameObject.SetActive(false); // Ukryj przycisk restartu na pocz�tku
        menuButton.gameObject.SetActive(false); // Ukryj przycisk menu na pocz�tku
        endGamePanel.SetActive(false); // Ukryj panel t�a na pocz�tku

        restartButton.onClick.AddListener(RestartGame); // Dodaj listener do przycisku restartu
        menuButton.onClick.AddListener(ReturnToMenu); // Dodaj listener do przycisku menu
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
            EndGame(); // Wywo�aj koniec gry
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
        Debug.Log("Score increased to: " + score); // Dodanie logu debugowania
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void EndGame()
    {
        endGameText.gameObject.SetActive(true); // Poka� tekst ko�ca gry
        endGameText.text = "Koniec gry\nWynik: " + score; // Wy�wietl wynik

        restartButton.gameObject.SetActive(true); // Poka� przycisk restartu
        menuButton.gameObject.SetActive(true); // Poka� przycisk menu
        endGamePanel.SetActive(true); // Poka� panel t�a
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restartuj bie��c� scen�
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu"); // Za�aduj scen� menu, upewnij si�, �e taka scena istnieje
    }
}




