using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skateboarder : MonoBehaviour
{
    [SerializeField] private Slider sliderRef;
    [SerializeField] private PointsController controllerRef;
    [SerializeField] private MyButton leftButton;
    [SerializeField] private MyButton rightButton;
    [SerializeField] private GamePointsHolder gamePointsHolder;

    public int flips = 0;
    private Animator animatorRef;
    private SpriteRenderer rendererRef;
    private float currentSpeed = 0f;
    private const float maxSpeed = 5f; // Adjust this value
    private const float acceleration = 1.5f; // Adjust this value
    private const float deceleration = 0.4f; // Adjust this value

    void Start()
    {
        animatorRef = transform.GetComponent<Animator>();
        rendererRef = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (leftButton.buttonPressed)
        {
            rendererRef.flipX = true;
            animatorRef.SetBool("IsRidingRight", false);
            animatorRef.SetBool("IsRidingLeft", true); 
            Accelerate();
        }
        else if (rightButton.buttonPressed)
        {
            rendererRef.flipX = false;
            animatorRef.SetBool("IsRidingRight", true);
            animatorRef.SetBool("IsRidingLeft", false);
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
        controllerRef.IncrementPoints(flips);

        if(flips > gamePointsHolder.maxScore)
        {
            gamePointsHolder.UpdateMaxScore(flips);
        }
    }
}
