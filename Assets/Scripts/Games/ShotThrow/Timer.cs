using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    public Scrollbar timerScrollbar; 
    public TextMeshProUGUI timerText; 
    public float startTime = 60f; 

    private float currentTime; 

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
    }
}
