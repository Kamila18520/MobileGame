/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_controller : MonoBehaviour

{
    public GameObject arrowPrefab;
    private GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {

     FireArrow();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        arrow.GetComponent<Rigidbody2D>().velocity = (arrow.transform.up * 5f);
    }

    private void FireArrow()
    {
        arrow = Instantiate(arrowPrefab);


        arrow.transform.position = transform.position + new Vector3(0f, 1f);


        float angle = 15f;


        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);


       



    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour

{
    public Transform bow;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(MousePos);
        Vector2 bowPos = bow.position;

        direction = MousePos - bowPos;

        FaceMouse();
    }

    void FaceMouse()
    {
        bow.right = direction;
    }
}
