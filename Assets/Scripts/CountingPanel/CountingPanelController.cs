using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CountingPanelController : MonoBehaviour
{
    [Header("Scripts to start")]
    [SerializeField] UnityEvent stopSctipts;
    [SerializeField] UnityEvent startScripts;

    [Header("Values")]
    [SerializeField] string[] counting = new string[4] { "3", "2", "1", "START" };
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Image circle;
    [SerializeField] float duration = 1.0f;
    [SerializeField] float time;

    [Header("Audio")]
    [SerializeField] AudioSource count;

    [SerializeField] int countIndex = 0;

    private void Awake()
    {
        stopSctipts.Invoke();
        count.Play();
        Counter();
    }
    private void Update()
    {
        if (countIndex < counting.Length+1)
        {
            if (time < 1)
            {
                time += Time.deltaTime;
            }
            else if (time >= 1)
            {
                time = 0;
                Counter();
            }
        }
        else
        {
            startScripts.Invoke();
            Destroy(gameObject);
        }



        circle.fillAmount = time;



    }

    private void Counter()
    {
        if(countIndex < counting.Length) 
        { 
            textMeshProUGUI.text = counting[countIndex];
        }

        countIndex++;
    }

}
