using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skateboarder : MonoBehaviour
{
    [SerializeField] private Slider sliderRef;
    [SerializeField] private MyButton leftButton;
    [SerializeField] private MyButton rightButton;

    public int flips = 0;
    private Animator animatorRef;
    private SpriteRenderer rendererRef;
    private float currentSpeed = 0f;
    private const float maxSpeed = 5f; // Adjust this value
    private const float acceleration = 0.5f; // Adjust this value
    private const float deceleration = 0.2f; // Adjust this value

    void Start()
    {
        animatorRef = transform.GetComponent<Animator>();
        rendererRef = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (leftButton.buttonPressed)
        {
            animatorRef.SetBool("IsRidingRight", false);
            animatorRef.SetBool("IsRidingLeft", true);
            rendererRef.flipX = true;
            Accelerate();
        }
        else if (rightButton.buttonPressed)
        {
            animatorRef.SetBool("IsRidingRight", true);
            animatorRef.SetBool("IsRidingLeft", false);
            rendererRef.flipX = false;
            Accelerate();
        }
        else
        {
            animatorRef.SetBool("IsRidingRight", false);
            animatorRef.SetBool("IsRidingLeft", false);
            Decelerate();
        }

        animatorRef.SetFloat("Speed", currentSpeed);
        sliderRef.value = currentSpeed/maxSpeed;
    }

    void Accelerate()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
    }

    void Decelerate()
    {
        if (currentSpeed > 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed = 0;
        }
    }

    public void ResetSpeedAfterJump()
    {
        currentSpeed = 0f;
        flips++;
    }
}
