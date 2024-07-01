using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int scoreValue = 10;  // Warto�� punktowa za trafienie
    public AudioSource hitSound; // Referencja do AudioSource
    public ParticleSystem hitEffect; // Referencja do ParticleSystem
    [SerializeField] private PointsController controllerRef;
    void Start()
    {
        // Pobierz AudioSource i ParticleSystem z obiektu
        hitSound = GetComponent<AudioSource>();
        hitEffect = GetComponent<ParticleSystem>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // Obs�uga trafienia
            //Debug.Log("Tarcza trafiona!");


            controllerRef.IncrementPoints(scoreValue);


            // Odtworzenie d�wi�ku trafienia
            if (hitSound != null)
            {
                hitSound.Play();
            }

            // Uruchomienie efektu cz�steczek
            if (hitEffect != null)
            {
                hitEffect.Play();
            }
        }
    }
}
