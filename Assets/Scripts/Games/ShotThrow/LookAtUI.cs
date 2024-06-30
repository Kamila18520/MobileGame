using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtUI : MonoBehaviour
{
    public RectTransform target; 

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
