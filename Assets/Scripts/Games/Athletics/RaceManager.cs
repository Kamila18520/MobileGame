using UnityEngine;
using TMPro;

public class RaceManager : MonoBehaviour
{
    public TMP_Text timerText; // Referencja do TMP_Text do wyœwietlania czasu
    private float startTime;
    private bool raceFinished = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!raceFinished)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }

    public void FinishRace()
    {
        raceFinished = true;
    }
}


