using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BubblesSpawner : MonoBehaviour
{
    [Header("TEST dont lose")]
    [SerializeField] bool TEST;

    [Header("Time")]
    [SerializeField] PointsController pointsController;
    [Range(0f, 1f)]
    [SerializeField] float percent;

    [Header("Speed")]
    [SerializeField] float actualSpeed;
    [SerializeField] float minSpeed = 2f;
    [SerializeField] float maxSpeed = 0.5f;

    [Header("Bubble")]
    [SerializeField] GameObject bubblePrefab;

    [Header("Area Size")]
    [SerializeField] float spawnPanelHeight;
    [SerializeField] float spawnPanelWidth;

    [Header("Test")]

    [SerializeField] private Vector2 spawnPosition;

    private void OnEnable()
    {
        actualSpeed = minSpeed;
        spawnPanelHeight = gameObject.GetComponent<RectTransform>().rect.height;
        spawnPanelWidth = gameObject.GetComponent<RectTransform>().rect.width;
        StartCoroutine(Spawner());
    }

    

    private void Update()
    {
        percent = pointsController.percent;


        if (actualSpeed > maxSpeed)
            actualSpeed = maxSpeed + ((minSpeed - maxSpeed) * (1 - percent));
        else actualSpeed = maxSpeed;

    }

    IEnumerator Spawner()
    {
        SpawnBubble();
        yield return new WaitForSeconds(actualSpeed);
        StartCoroutine(Spawner());
    }

    private void SpawnBubble()
    {
        GameObject bubble = Instantiate(bubblePrefab, transform);
        bubble.GetComponent<BubbleController>().TEST = TEST;
        bubble.GetComponent<GameOverPanel>().gameOverPanel = gameObject.GetComponent<GameOverPanel>().gameOverPanel;

        RandomPosition(bubble);
    }

    private void RandomPosition(GameObject bubbleCopy)
    {
        float randomX = UnityEngine.Random.Range(-spawnPanelWidth/2, spawnPanelWidth / 2);
        float randomY = UnityEngine.Random.Range(-spawnPanelHeight/2, spawnPanelHeight /2);

        spawnPosition = new Vector2(randomX, randomY);

        bubbleCopy.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
    }


}


