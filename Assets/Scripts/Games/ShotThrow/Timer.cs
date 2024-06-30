using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    public Scrollbar timerScrollbar; // Referencja do UI Scrollbar
    public TextMeshProUGUI timerText; // Opcjonalne: Referencja do UI Text, który wyœwietla pozosta³y czas
    public float startTime = 60f; // Czas pocz¹tkowy w sekundach

    private float currentTime; // Aktualny czas

    public UnityEvent OnTimeEnd;

    private void Start()
    {
        currentTime = startTime;
        timerScrollbar.size = 1f; 

        if (timerText != null)
        {
            timerText.text = currentTime.ToString("F1"); 
        }

        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            // Odliczanie czasu
            currentTime -= Time.deltaTime;
            timerScrollbar.size = currentTime / startTime;

            if (timerText != null)
            {
                timerText.text = currentTime.ToString("F1"); 
            }

            yield return null;
        }

        currentTime = 0;
        timerScrollbar.size = 0f;

        if (timerText != null)
        {
            timerText.text = currentTime.ToString("F1");
        }

        OnTimerEnd();
    }

    private void OnTimerEnd()
    {
        OnTimeEnd.Invoke();
        Debug.Log("Timer skoñczy³ odliczanie.");
    }
}
