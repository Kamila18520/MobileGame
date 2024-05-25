using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public RaceManager raceManager; // Referencja do RaceManager

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            raceManager.FinishRace();
            Debug.Log("Race Finished!");
        }
    }
}

