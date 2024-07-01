using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Referencja do obiektu, który kamera ma œledziæ
    public float offsetX = 5f; // Przesuniêcie kamery wzglêdem pozycji postaci na osi X
    public float smoothSpeed = 0.125f; // Prêdkoœæ wyg³adzania ruchu kamery

    void LateUpdate()
    {
        // Utrzymuj sta³¹ pozycjê Y kamery
        Vector3 desiredPosition = new Vector3(target.position.x + offsetX, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}



