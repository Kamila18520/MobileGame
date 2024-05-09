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

    private Rigidbody2D rb; // Zak³adamy, ¿e gracz posiada komponent Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Pobierz komponent Rigidbody2D
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // SprawdŸ lewy klik myszy
        {
            lastClickTime = Time.time; // Czas ostatniego klikniêcia
            if (Time.time - lastClickTime < clickInterval) // SprawdŸ czas od klikniêcia
            {
                speed += 10f; // Zwiêksz prêdkoœæ o 0.1
            }
            speedText.text = "Prêdkoœæ: " + speed.ToString("0.0");
        }
    }

    void FixedUpdate()
    {
        float movement = speed * Time.deltaTime; // Przesuniêcie w oparciu o prêdkoœæ i czas
        transform.Translate(movement * Vector2.right); // Przesuñ gracza w prawo

        // Zapobieganie przyspieszeniu bez klikania
        if (!Input.GetMouseButton(0))
        {
            speed = 0f; // Ustaw prêdkoœæ na 0
        }
    }
}
