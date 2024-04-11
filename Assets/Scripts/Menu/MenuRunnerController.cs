using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuRunnerController : MonoBehaviour, IPointerClickHandler
{
    [Header("Runner")]
    [SerializeField] Transform runner;
    [SerializeField] Animator runnerAnim;

    [Header("Tour points")]
    [SerializeField] Transform Points;
    [SerializeField] Vector3[] tourPoints;

    [Header("Runner Variables")]
    [SerializeField] private float speed = 5f;
    private int currentPointIndex = 1;
    private bool fall = false;
    [SerializeField] float fallTime = 2;

    void Start()
    {
        tourPoints = new Vector3[Points.childCount];

        for (int i = 0; i < Points.childCount; i++)
        {
            tourPoints[i] = new Vector3(Points.GetChild(i).position.x, Points.GetChild(i).position.y, 0);

        }

        runner.position = tourPoints[0];

    }


    void Update()
    {
        if (!fall)
        {
            if (Vector3.Distance(runner.position, tourPoints[currentPointIndex]) < 0.1f)
            {
                currentPointIndex = (currentPointIndex + 1) % tourPoints.Length;
                MoveToNextPoint();
            }
            else
            {
                MoveToNextPoint();
            }

        }
        
    }

    void MoveToNextPoint()
    {
        Vector3 targetPosition = tourPoints[currentPointIndex];
        runner.position = Vector3.MoveTowards(runner.position, targetPosition, speed * Time.deltaTime);
        SetAnimation();

    }

    private string currentTrigger;
    private void SetAnimation()
    {
        if (currentPointIndex >= 1 && currentPointIndex <= 3)
        {
            runnerAnim.SetTrigger("RunUp");
            currentTrigger = "RunUp";
        }
        else if (currentPointIndex == 4 || currentPointIndex == 5)
        {
            runnerAnim.SetTrigger("RunLeft");
            currentTrigger = "RunLeft";

        }
        else if (currentPointIndex >= 6 && currentPointIndex <= 8)
        {
            runnerAnim.SetTrigger("RunDown");
            currentTrigger = "RunDown";

        }
        else
        {
            runnerAnim.SetTrigger("RunRight");
            currentTrigger = "RunRight";

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Fall());
    }

    public IEnumerator Fall()
    {
        runnerAnim.SetBool("Fall", true);
        Debug.Log("Menu runner has fallen");
        fall = true;
        yield return new WaitForSeconds(fallTime);
        runnerAnim.SetBool("Fall", false);

        fall = false;
        MoveToNextPoint();
    }

}
