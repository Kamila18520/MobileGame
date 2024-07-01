using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public GameObject startScreenUI; // Referencja do obiektu ekranu startowego
    public GameObject gameUI; // Referencja do obiektu UI gry

    // Funkcja wywo�ywana na pocz�tku gry lub po wci�ni�ciu przycisku Start
    public void StartGame()
    {
        startScreenUI.SetActive(false); // Dezaktywuj ekran startowy
        gameUI.SetActive(true); // Aktywuj UI gry
    }

    // Funkcja wywo�ywana po wci�ni�ciu przycisku Restart
    public void RestartGame()
    {
        startScreenUI.SetActive(true); // Aktywuj ekran startowy
        gameUI.SetActive(false); // Dezaktywuj UI gry
    }
}


