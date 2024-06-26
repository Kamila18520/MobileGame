using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AngleAndDistanceBetweenPoints : MonoBehaviour
{
    [Header("Transform")]

    public Transform filledCircle;
    public Transform ball;
    private Image circleImage;

    [Header("Angle")]
    public float Angle;

    [Header("Full Circles")]
    public AudioSource ballSound;
    public TextMeshProUGUI text;
    public int fullCircles;

    [HideInInspector]
    public float TargetDistance = 25.0f;
    private float normalizedAngle;
    private float previousNormalizedAngle;

    private void Start()
    {
        fullCircles = 0;
        text.text = fullCircles.ToString();

        circleImage = filledCircle.GetComponent<Image>();
        previousNormalizedAngle = 0f;
    }

    private void Update()
    {
        if (filledCircle != null && ball != null)
        {
            Angle = CalculateAngle(filledCircle.position, ball.position);

            SetObjectAtDistance(filledCircle, ball, TargetDistance);

            UpdateFillAmount(Angle);
        }
    }

    public float CalculateAngle(Vector3 point1, Vector3 point2)
    {
        Vector3 direction = point2 - point1;
        float angleInRadians = Mathf.Atan2(direction.y, direction.x);
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;
        return angleInDegrees;
    }

    private void SetObjectAtDistance(Transform obj1, Transform obj2, float distance)
    {
        Vector3 direction = (obj2.position - obj1.position).normalized;
        obj2.position = obj1.position + direction * distance;
    }

    private void UpdateFillAmount(float angle)
    {
        normalizedAngle = (angle - 90f) / 360f;

        if (normalizedAngle < 0)
        {
            normalizedAngle += 1;
        }

        if ((previousNormalizedAngle > 0.75f && normalizedAngle < 0.25f) ||
            (previousNormalizedAngle < 0.25f && normalizedAngle > 0.75f))
        {
            fullCircles++;
            text.text = fullCircles.ToString();
            ballSound.Play();
        }

        previousNormalizedAngle = normalizedAngle;
        circleImage.fillAmount = normalizedAngle;
    }

    private void OnDrawGizmos()
    {
        if (filledCircle != null && ball != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(filledCircle.position, ball.position);
            Gizmos.DrawSphere(filledCircle.position, 1f);
            Gizmos.DrawSphere(ball.position, 1.5f);
        }
    }
}
