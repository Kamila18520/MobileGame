using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencja do obiektu, kt�rym chcemy pod��a�, czyli posta�
    public float followSpeed = 0f; // Pr�dko�� pod��ania kamery za postaci�

    void Update()
    {
        if (target != null) // Sprawd�, czy mamy referencj� do postaci
        {
            // Oblicz pozycj�, do kt�rej ma pod��a� kamera
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);

            // Interpoluj pozycj� kamery, aby p�ynnie pod��a�a za postaci�
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}


