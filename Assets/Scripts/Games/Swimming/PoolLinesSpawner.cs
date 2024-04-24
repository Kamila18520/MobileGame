using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PoolLinesSpawner : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float speed = 2f;
    private int lineHeight = 115;
    [SerializeField] Color[] colors = new Color[3];
    int colorsCount;
    float parentHeight;
    [Header("Prefab")]
    [SerializeField] GameObject Line;
    [SerializeField] GameObject container;
    int lineCount;

    private void Awake()
    {
        colorsCount = 0;
        parentHeight = gameObject.GetComponent<RectTransform>().rect.height;
        lineCount = (int)(parentHeight / lineHeight) +2;


        for (int i = 0; i < lineCount; i++)
        {
            SpawnLine(i);
        }

        //MoveLines();
    }
    private void MoveLines()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject line = gameObject.transform.GetChild(i).gameObject;

            LeanTween.moveY(line, -lineHeight, speed);

        }
    }

    private void Update()
    {
        GameObject lineToDelete = gameObject.transform.GetChild(0).gameObject;

        if (lineToDelete.GetComponent<RectTransform>().anchoredPosition.y <= -100f)
        {
            SpawnLine(lineCount - 1);
            Destroy(lineToDelete);
           // MoveLines();
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject line = gameObject.transform.GetChild(i).gameObject;

            Vector3 target = new Vector3(line.transform.position.x, line.transform.position.y -lineHeight, line.transform.position.z);

            line.transform.position = Vector3.MoveTowards(line.transform.position, target, speed * Time.deltaTime);

            //LeanTween.moveY(line, -lineHeight, speed);

        }

    }

    private void SpawnLine(int value)
    {
        GameObject copyLine = Instantiate(Line, transform);

        copyLine.GetComponent<RectTransform>().anchoredPosition = new Vector2(copyLine.GetComponent<RectTransform>().anchoredPosition.x, lineHeight * value);
        copyLine.GetComponent<Image>().color = colors[colorsCount % 3];
        colorsCount++;
    }


}
