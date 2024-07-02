using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private static PointsController _instance;

    public static PointsController Instance { get { return _instance; } }

    [Header("Time")]
    public float timeToMaxSpeed = 0f;
    public float actualTime;
    
    [Range(0f, 1f)]
    public float percent;

    [Header("Points")]
    [SerializeField] private int points;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] float pointsMultiplier = 5f;


    // Update is called once per frame
    public void Update()
    {
        UpdateSwimmingPoints();
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void UpdateSwimmingPoints()
    {
        if (timeToMaxSpeed == 0)
        {
            return;
        }
        PercentOfTimeToMaxSpeed();
        float floatValue = percent * 100f;
        points = Mathf.RoundToInt(actualTime + (pointsMultiplier * floatValue));
        IncrementPoints(points);
    }
    public void PercentOfTimeToMaxSpeed()
    {
        actualTime += Time.deltaTime;
        percent = (actualTime / timeToMaxSpeed);
    }

    public void IncrementPoints(int value)
    {
        points += value;
        pointsText.text = points.ToString();
    }

    public void DeductPoints(int value)
    {
        points -= value;
        pointsText.text = points.ToString();
    }

    public int GetPoints()
    {
        return points;
    }
}
