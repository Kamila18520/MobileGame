using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [Header("Time")]
    public float timeToMaxSpeed = 180f;
    public float actualTime;
    [Range(0f, 1f)]
    public float percent;

    [Header("Points")]
    [SerializeField] int points;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] float pointsMultiplier = 5f;


    // Update is called once per frame
    public void Update()
    {
        PercentOfTimeToMaxSpeed();
        float floatValue = percent * 100f;
        points = Mathf.RoundToInt(actualTime + (pointsMultiplier * floatValue));
        pointsText.text = points.ToString();

    }

    public void PercentOfTimeToMaxSpeed()
    {
        actualTime += Time.deltaTime;
        percent = (actualTime / timeToMaxSpeed);
    }
}
