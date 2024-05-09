using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Na obiekcie kamery
public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ustaw posta� jako cel

    void Update()
    {
        if (target != null)
        {
            // Wy�rodkowanie kamery na postaci
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}

