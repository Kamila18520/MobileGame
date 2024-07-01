using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public Transform indicatorRef;
    public Transform hitZoneRef;
    public TMP_Text outputRef;
    public GameObject gameOverPanel;

    private Collider2D indicatorCollider;
    private Collider2D hitZoneColider;
    private float speedModifier = 0.7f;
    private bool hasJumped = false;

    private string winText = "Wskoczy�:)";
    private string loseText = "Nie uda�o si� :(";
    private float time = 2.5f;

    private void Start()
    {
        gameOverPanel.SetActive(false);
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
            outputRef.text = winText;
            StartCoroutine(ShowGameOverPanel(winText));
            return true;
        }
        else
        {
            outputRef.text = loseText;
            StartCoroutine(ShowGameOverPanel(loseText));
        }
        return false;
    }

    IEnumerator ShowGameOverPanel(string text)
    {
        yield return new WaitForSeconds(time);
        gameOverPanel.SetActive(true);
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
