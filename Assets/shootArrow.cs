using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrow : MonoBehaviour
{

    public float LaunchForce;

    public GameObject arrow;

    public Transform arrowSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Pobierz pierwszy dotyk

            if (touch.phase == TouchPhase.Began) // Jeœli dotyk rozpoczyna siê
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject ArrowIns = Instantiate(arrow, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().velocity = ArrowIns.transform.up * LaunchForce;
    }
}
