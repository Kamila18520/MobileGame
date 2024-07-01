using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControlledBall : MonoBehaviour
{
    public Transform filledCircle; 
    private Transform ball; 
    public AngleAndDistanceBetweenPoints angleAndDistanceBetweenPoints;
    private float targetDistance = 25.0f; 
    private bool isDragging = false; 

    private void Start()
    {
        ball = gameObject.transform;
        targetDistance = angleAndDistanceBetweenPoints.TargetDistance;
    }


    private void Update()
    {
        // Sprawdzenie, czy gracz dotyka ekran lub klikn¹³ myszk¹
        if (Input.GetMouseButtonDown(0) && IsPointerOverUIElement())
        {
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Aktualizacja pozycji kuli, gdy jest przeci¹gana
        if (isDragging)
        {
            UpdateBallPosition();
        }
    }

    private bool IsPointerOverUIElement()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    private void UpdateBallPosition()
    {
        Vector3 screenPos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane));

        Vector3 direction = worldPos - filledCircle.position;
        direction.z = 0; // Ignorowanie osi Z
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Sprawdzenie, czy ruch jest zgodny z ruchem wskazówek zegara
        float currentAngle = Mathf.Atan2(ball.position.y - filledCircle.position.y, ball.position.x - filledCircle.position.x) * Mathf.Rad2Deg;
        float deltaAngle = Mathf.DeltaAngle(currentAngle, angle);

        if (deltaAngle < 0)
        {
            // Ruch przeciwny do ruchu wskazówek zegara, zatrzymujemy go
            return;
        }

        // Ustawienie nowej pozycji kuli
        direction.Normalize();
        ball.position = filledCircle.position + direction * targetDistance;
    }
}
