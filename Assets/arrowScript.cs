using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{

    Rigidbody2D rb;
    bool hasHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        trackMovement();


    }
    void trackMovement()
    {
        if (rb.velocity == Vector2.zero)
        {
            return;
        }

        //Vector2 direction = rb.velocity;
        //if (hasHit == false)
        //{
        //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
    }
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
    }
*/
    void OnCollisionEnter2D(Collision2D collision)
    {

        
        // SprawdŸ, czy strza³a trafi³a w tarczê
        if (collision.gameObject.CompareTag("Target"))
        {
            // Zatrzymaj ruch strza³y
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            // Upewnij siê, ¿e strza³a nie bêdzie dalej reagowaæ na fizykê
            rb.isKinematic = true;

            // Opcjonalnie: Przypnij strza³ê do tarczy, aby porusza³a siê z ni¹
            transform.parent = collision.transform;

            // Dodatkowe efekty wizualne lub dŸwiêkowe
            Debug.Log("Strza³a trafi³a w tarczê!");
        }
    }
}