using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public RaceManager raceManager; // Referencja do RaceManager

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Logowanie nazwy obiektu, kt�ry wszed� w kolizj�
        if (other.CompareTag("Player"))
        {
            raceManager.FinishRace();
            Debug.Log("Race Finished!");
        }
    }


}


