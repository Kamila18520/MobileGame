using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MultiplyAndDisplay : MonoBehaviour
{
    [SerializeField] AngleAndDistanceBetweenPoints script;
    public List<Range> m_Range = new List<Range>();
    public float multipler;
    public float number2 = 5f;  
    public string text;
    public TextMeshProUGUI resultText; 
    public TextMeshProUGUI comentText;
    public TextMeshProUGUI maxScoreText;

    private float result; 
    private float targetResult; 
    public float duration = 2f; 
    public AnimationCurve easingCurve; 
    public GamePointsHolder gamePointsHolder;

    public UnityEvent ShowButtons;

    void Start()
    {
        comentText.text = null;
        int point = script.fullCircles;
        number2 = script.fullCircles;

        for (int i = 0; i < m_Range.Count; i++)
        {
            if (point <= m_Range[i].range)
            {
                multipler = m_Range[i].multipler;
                text = m_Range[i].text;
                break;
            }
        }

        result = multipler * number2; 
        targetResult = result; 
        StartCoroutine(DisplayResult());
    }

    IEnumerator DisplayResult()
    {
        float timer = 0f;
        float initialResult = 0f; 
        float decimalThreshold = 1000f; 

        while (timer < duration)
        {
            float progress = timer / duration;
            float easedProgress = easingCurve.Evaluate(progress); 

            float currentResult = Mathf.Lerp(initialResult, targetResult, easedProgress);

            if (targetResult < decimalThreshold)
            {
                resultText.text = currentResult.ToString("F2")+"m"; 
            }
            else
            {
                resultText.text = Mathf.RoundToInt(currentResult).ToString() + "m";
            }

            timer += Time.deltaTime;
            yield return null;
        }

      
        if (targetResult < decimalThreshold)
        {
            resultText.text = targetResult.ToString("F2") + "m"; 
        }
        else
        {
            resultText.text = Mathf.RoundToInt(targetResult).ToString() + "m";
        }

        comentText.text = text;
        ShowButtons.Invoke();
        if (result > gamePointsHolder.maxScore)
        {
            maxScoreText.text = "New max score!";
            gamePointsHolder.UpdateMaxScore(result);
        }
        else
        {
            maxScoreText.text = "Your max score: " + result + "m";

        }
    }

    [System.Serializable]
    public class Range
    {
        public int range;
        public float multipler;
        public string text;
    }
}
