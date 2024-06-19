using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public Transform indicatorRef;
    public Transform hitZoneRef;
    public TMP_Text outputRef;
    private Collider2D indicatorCollider;
    private Collider2D hitZoneColider;
    private float speedModifier = 0.7f;
    private bool hasJumped = false;

    private void Start()
    {
        indicatorCollider = indicatorRef.gameObject.GetComponent<Collider2D>();
        hitZoneColider = hitZoneRef.gameObject.GetComponent<Collider2D>();
        hitZoneRef.localPosition = new Vector3(Random.Range(-450, 450), 0, 0);
    }
    void Update()
    {
        TimerLogic();
    }

    public bool IsIndicatorInRange()
    {
        hasJumped = true;
        speedModifier = 0f;
        if (indicatorCollider.IsTouching(hitZoneColider))
        {
            outputRef.text = "Skoczek Status: Wskoczyl:)";
            return true;
        }
        else
        {
            outputRef.text = "Skoczek Status: Umarl:(";
        }
        return false;
    }

    private void TimerLogic()
    {
        if (!hasJumped)
        {
            float time = speedModifier * Time.time;
            float pingPong = Mathf.PingPong(time, 1);
            indicatorRef.localPosition = new Vector3(pingPong * 1000 - 500, 0, 0);
        }
    }
}
