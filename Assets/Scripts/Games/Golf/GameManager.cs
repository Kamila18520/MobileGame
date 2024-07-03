using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Dodajemy using dla TextMeshPro
using UnityEngine.SceneManagement; // Dodajemy using dla zarz¹dzania scenami
using UnityEngine.UI; // Dodajemy using dla UI

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText; // Zmieniamy na TMP_Text
    public TMP_Text timerText; // Zmieniamy na TMP_Text
    public TMP_Text endGameText; // Dodajemy TMP_Text dla koñca gry
    public Button restartButton; // Dodajemy przycisk restartu
    public Button menuButton; // Dodajemy przycisk powrotu do menu
    public GameObject endGamePanel; // Dodajemy panel t³a
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

        endGameText.gameObject.SetActive(false); // Ukryj tekst koñca gry na pocz¹tku
        restartButton.gameObject.SetActive(false); // Ukryj przycisk restartu na pocz¹tku
        menuButton.gameObject.SetActive(false); // Ukryj przycisk menu na pocz¹tku
        endGamePanel.SetActive(false); // Ukryj panel t³a na pocz¹tku

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
            EndGame(); // Wywo³aj koniec gry
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
        endGameText.gameObject.SetActive(true); // Poka¿ tekst koñca gry
        endGameText.text = "Koniec gry\nWynik: " + score; // Wyœwietl wynik

        restartButton.gameObject.SetActive(true); // Poka¿ przycisk restartu
        menuButton.gameObject.SetActive(true); // Poka¿ przycisk menu
        endGamePanel.SetActive(true); // Poka¿ panel t³a
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restartuj bie¿¹c¹ scenê
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu"); // Za³aduj scenê menu, upewnij siê, ¿e taka scena istnieje
    }
}




