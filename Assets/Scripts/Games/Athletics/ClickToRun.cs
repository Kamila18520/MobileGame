using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToRun : MonoBehaviour
{
    [SerializeField] private float speed;
    private float lastClickTime;
    [SerializeField] private float clickInterval;
    [SerializeField] private Text speedText;

    private Rigidbody2D rb; // Zak�adamy, �e gracz posiada komponent Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pobierz komponent Rigidbody2D
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sprawd� lewy klik myszy
        {
            lastClickTime = Time.time; // Czas ostatniego klikni�cia
            if (Time.time - lastClickTime < clickInterval) // Sprawd� czas od klikni�cia
            {
                speed += 10f; // Zwi�ksz pr�dko�� o 0.1
            }
            speedText.text = "Pr�dko��: " + speed.ToString("0.0");
        }
    }

    void FixedUpdate()
    {
        float movement = speed * Time.deltaTime; // Przesuni�cie w oparciu o pr�dko�� i czas
        transform.Translate(movement * Vector2.right); // Przesu� gracza w prawo

        // Zapobieganie przyspieszeniu bez klikania
        if (!Input.GetMouseButton(0))
        {
            speed = 0f; // Ustaw pr�dko�� na 0
        }
    }
}
