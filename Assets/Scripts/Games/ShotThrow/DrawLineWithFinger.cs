using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineWithFinger : MonoBehaviour
{
    public LineRenderer lineRenderer; // LineRenderer, kt�ry b�dzie rysowa� linie
    public float followDuration = 0.5f; // Czas �ledzenia ruchu palca

    private Coroutine drawingCoroutine;

    void Update()
    {
        // Sprawd�, czy ekran zosta� dotkni�ty
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Button Down");

            Vector3 startPosition = GetWorldPosition(Input.mousePosition);

            // Rozpocznij rysowanie linii
            if (drawingCoroutine != null)
            {
                StopCoroutine(drawingCoroutine);
            }
            drawingCoroutine = StartCoroutine(DrawLine(startPosition));
        }
    }

    private Vector3 GetWorldPosition(Vector3 screenPosition)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z = 0; // Ustawienie pozycji Z na 0, aby linia by�a w tej samej p�aszczy�nie
        return worldPosition;
    }

    private IEnumerator DrawLine(Vector3 startPosition)
    {
        lineRenderer.positionCount = 2; // Ustawienie liczby wierzcho�k�w na 2
        lineRenderer.SetPosition(0, startPosition); // Ustawienie pozycji pocz�tkowej linii

        float elapsedTime = 0f;

        while (elapsedTime < followDuration)
        {
            Vector3 currentPosition = GetWorldPosition(Input.mousePosition);
            lineRenderer.SetPosition(1, currentPosition); // Ustawienie pozycji ko�cowej linii
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lineRenderer.positionCount = 0; // Zresetowanie linii po zako�czeniu rysowania
    }
}
