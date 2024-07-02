using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LungController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] PointsController pointsController;
    [Range(0f, 1f)]
    [SerializeField] float percent;


    [Header("Lungs")]
    [SerializeField] GameObject[] lungs = new GameObject[2];
    [SerializeField] TextMeshProUGUI lungPercentTMP;
    [Header("Lung size")]
    [SerializeField] float maxLungSize = 1.0f;
    [SerializeField] float minLungSize = 0.85f;

    [Header("Lungs Values")]
    [SerializeField] float actualSpeed;
    [SerializeField] float minSpeed = 10f;
    [SerializeField] float maxSpeed = 3.75f;
    [SerializeField] float airValue = 10f;

    float lungsValue;
    bool exhaust;

    private void Awake()
    {
        
        actualSpeed = minSpeed;
        exhaust = true;
    }

    private void Update()
    {
        percent = pointsController.percent;

        lungsValue = lungs[0].GetComponent<Slider>().value;

        float tmpValue = lungsValue * 100;
        int intValue = (int)tmpValue;
        lungPercentTMP.text = intValue.ToString()+"%";

        if (exhaust) 
        {
            LugnsSize(0);

        }

    }


    private void LugnsSize(int number)
    {


        if(actualSpeed > maxSpeed)
        actualSpeed = maxSpeed + ((minSpeed - maxSpeed) * (1 - percent));
        else actualSpeed = maxSpeed;


        lungs[number].GetComponent<Slider>().value -= Time.deltaTime / actualSpeed;
        GameOverCheck(lungs[number].GetComponent<Slider>().value);
        lungs[number].transform.localScale = Vector3.one * (minLungSize + (lungsValue * (maxLungSize - minLungSize)));




    }
    private void GameOverCheck(float value)
    {
        if(value ==0)
        {
            gameObject.GetComponent<GameOverPanel>().OnGameOver();
        }
    }

    public void AddAirValue()
    {
        StartCoroutine(AddAir());
    }

    IEnumerator AddAir()
    {
        exhaust = false;


            LugnsSize(0);
            Breath(0);

        


        yield return new WaitForSeconds(0.2f);
        exhaust = true;
    }

    private void Breath(int number)
    {
        lungs[number].GetComponent<Slider>().value += Time.deltaTime * airValue;

    }

}
