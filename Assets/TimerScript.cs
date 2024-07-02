using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Transform indicatorRef;
    public Transform hitZoneRef;
    public TMP_Text outputRef;
    public GameObject gameOverPanel;
    public Button buttonRef;

    [SerializeField] private Timer timerRef;
    [SerializeField] private JumperController controllerRef;
    [SerializeField] private PointsController pointsRef;

    private Collider2D indicatorCollider;
    private Collider2D hitZoneColider;
    private float speedModifier = 0.7f;
    private bool hasJumped = false;
    private bool pressed = false;

    private string winText = "Wskoczy³:)";
    private string loseText = "Nie uda³o siê :(";
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
            pointsRef.IncrementPoints((int)timerRef.GetCurrentTime());
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

    public void ButtonPressed()
    {
        pressed = true;
        timerRef.FreezeTimer();
    }

    public void TimedOut()
    {
        if (pressed)
        {
            return;
        }
        outputRef.text = loseText;
        controllerRef.BadJump();
        indicatorRef.gameObject.SetActive(false);
        buttonRef.gameObject.SetActive(false);
        StartCoroutine(ShowGameOverPanel(loseText));
    }

    public IEnumerator ShowGameOverPanel(string text)
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
