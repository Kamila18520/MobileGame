using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LineRenderer lr;

    [Header("Attributes")]
    [SerializeField] private float maxPower = 10f;
    [SerializeField] private float power = 2f;
    [SerializeField] private float maxGoalSpeed = 4f;

    private bool isDraging;
    private bool inHole;

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        Vector2 inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(transform.position, inputPos);

        if (Input.GetMouseButtonDown(0) && distance <= 0.5f) DragStart();
        if (Input.GetMouseButton(0) && isDraging) DragChange();
        if (Input.GetMouseButtonUp(0) && isDraging) DragRelease(inputPos);
    }

    private void DragStart()
    {
        isDraging = true;
    }

    private void DragChange() {}

    private void DragRelease(Vector2 pos)
    {
        float distance = Vector2.Distance((Vector2)transform.position,pos);
        isDraging = false;

        if (distance < 1f) {
            return;
        }

        Vector2 dir = (Vector2)transform.position - pos;
        rb.velocity= Vector2.ClampMagnitude (dir * power, maxPower);

    }
}
