using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencja do obiektu, którym chcemy pod¹¿aæ, czyli postaæ
    public float followSpeed = 0f; // Prêdkoœæ pod¹¿ania kamery za postaci¹

    void Update()
    {
        if (target != null) // SprawdŸ, czy mamy referencjê do postaci
        {
            // Oblicz pozycjê, do której ma pod¹¿aæ kamera
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);

            // Interpoluj pozycjê kamery, aby p³ynnie pod¹¿a³a za postaci¹
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}


