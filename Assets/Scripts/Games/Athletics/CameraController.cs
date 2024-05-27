using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Referencja do obiektu, kt�ry kamera ma �ledzi�
    public float offsetX = 5f; // Przesuni�cie kamery wzgl�dem pozycji postaci na osi X
    public float smoothSpeed = 0.125f; // Pr�dko�� wyg�adzania ruchu kamery

    void LateUpdate()
    {
        // Utrzymuj sta�� pozycj� Y kamery
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}



