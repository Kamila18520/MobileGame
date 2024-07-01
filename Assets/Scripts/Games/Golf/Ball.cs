using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private GameObject goalFx;

    private GameManager gameManager; // Referencja do GameManager

    [Header("Attributes")]
    [SerializeField] private float maxPower = 10f;
    [SerializeField] private float power = 2f;
    [SerializeField] private float maxGoalSpeed = 4f;

    private bool isDragging;
    private bool inHole;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position; // Zapami�taj pocz�tkow� pozycj� pi�ki
        gameManager = FindObjectOfType<GameManager>(); // Znajd� GameManager w scenie
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        Vector2 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(transform.position, inputPos);

        if (Input.GetMouseButtonDown(0) && distance <= 0.5f) DragStart();
        if (Input.GetMouseButton(0) && isDragging) DragChange(inputPos);
        if (Input.GetMouseButtonUp(0) && isDragging) DragRelease(inputPos);
    }

    private void DragStart()
    {
        isDragging = true;
        lr.positionCount = 2;
    }

    private void DragChange(Vector2 pos)
    {
        Vector2 dir = (Vector2)transform.position - pos;

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, (Vector2)transform.position + Vector2.ClampMagnitude((dir * power) / 2, maxPower / 2));
    }

    private void DragRelease(Vector2 pos)
    {
        float distance = Vector2.Distance((Vector2)transform.position, pos);
        isDragging = false;
        lr.positionCount = 0;

        if (distance < 1f)
        {
            return;
        }

        Vector2 dir = (Vector2)transform.position - pos;
        rb.velocity = Vector2.ClampMagnitude(dir * power, maxPower);
    }

    private void CheckWinState()
    {
        if (inHole) return;

        if (rb.velocity.magnitude <= maxGoalSpeed)
        {
            inHole = true;

            rb.velocity = Vector2.zero;
            gameObject.SetActive(false); // Deaktywuj pi�k� po trafieniu do dziurki

            if (gameManager != null)
            {
                gameManager.IncreaseScore(); // Zwi�ksz score w GameManagerze
                Debug.Log("Ball hit the goal. Score should increase."); // Dodanie logu debugowania
            }
            else
            {
                Debug.LogError("GameManager not found!"); // Dodanie logu debugowania b��du
            }

            GameObject fx = Instantiate(goalFx, transform.position, Quaternion.identity);
            Destroy(fx, 2f);

            // Resetowanie pi�ki po pewnym czasie (np. po 2 sekundach)
            Invoke("ResetBall", 2f);
        }
    }

    private void ResetBall()
    {
        transform.position = initialPosition; // Ustawienie pi�ki na pocz�tkow� pozycj�
        gameObject.SetActive(true); // Aktywuj pi�k� ponownie
        inHole = false; // Ustaw flag� inHole na false
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            CheckWinState();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            CheckWinState();
        }
    }
}



