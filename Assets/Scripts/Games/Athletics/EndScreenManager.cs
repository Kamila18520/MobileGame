using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public TMP_Text resultText;
    public RaceManager raceManager;

    void Start()
    {
        gameObject.SetActive(false); // Ukryj ekran wynik�w na pocz�tku
    }

    public void ShowResults(float finalTime)
    {
        resultText.text = "Your Time: " + finalTime.ToString("F2") + "s";
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restartuje bie��c� scen�
    }
}


