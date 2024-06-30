using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int scoreValue = 10;  // Warto�� punktowa za trafienie

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // Obs�uga trafienia
            Debug.Log("Tarcza trafiona!");

            // Dodanie punkt�w do ScoreManager
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(scoreValue);
            }

            // Dodatkowe efekty wizualne lub d�wi�kowe
            // Mo�esz doda� tutaj kod do zarz�dzania efektami
        }
    }
}
