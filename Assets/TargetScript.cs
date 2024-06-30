using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int scoreValue = 10;  // Wartoœæ punktowa za trafienie

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // Obs³uga trafienia
            Debug.Log("Tarcza trafiona!");

            // Dodanie punktów do ScoreManager
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            // Dodatkowe efekty wizualne lub dŸwiêkowe
            // Mo¿esz dodaæ tutaj kod do zarz¹dzania efektami
        }
    }
}
