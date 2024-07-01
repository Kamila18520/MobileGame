using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{

    Rigidbody2D rb;
    //Collider2D col;
    bool hasHit;

    public float lifetime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //col = GetComponent<Collider2D>();

        Destroy(gameObject, lifetime);
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


        
        if (collision.gameObject.CompareTag("Target") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;

            /* // Wy³¹cz komponent kolizji
             col.enabled = false;*/


            if (collision.gameObject.CompareTag("Target"))
            {
                transform.parent = collision.transform;
                Debug.Log("Strza³a trafi³a w tarczê!");

                // Dodaj punkty za trafienie w tarczê
                if (ScoreManager.instance != null)
                {
                    ScoreManager.instance.AddScore(10); // Dodaj 10 punktów za trafienie w tarczê
                }
            }

            if (collision.gameObject.CompareTag("Ground"))
            {
                transform.parent = collision.transform;
                Debug.Log("Strza³a trafi³a w pod³ogê!");

                // Odejmij punkty za nietrafienie w tarczê
                if (ScoreManager.instance != null)
                {
                    ScoreManager.instance.SubtractScore(10); // Odejmij 10 punktów za nietrafienie w tarczê
                }
            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                transform.parent = collision.transform;
                Debug.Log("Strza³a przelecia³a");

                if (ScoreManager.instance != null)
                {
                    ScoreManager.instance.SubtractScore(10); // Odejmij 10 punktów za nietrafienie w tarczê
                }
            }
        }
    }
}