using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplyAndDisplay : MonoBehaviour
{
    [SerializeField] AngleAndDistanceBetweenPoints script;
    public List<Range> m_Range = new List<Range>();
    public float multipler;
    public float number2 = 5f;  // Druga liczba do pomno�enia
    public string text;
    public TextMeshProUGUI resultText; // Komponent TMP, gdzie wy�wietlany b�dzie wynik
    public TextMeshProUGUI comentText;

    private float result; // Wynik mno�enia
    private float targetResult; // Docelowy wynik do wy�wietlenia
    public float duration = 2f; // Czas, w kt�rym ma by� wy�wietlany wynik (w sekundach)
    public AnimationCurve easingCurve; // Krzywa liniowa do kontrolowania pr�dko�ci

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

        result = multipler * number2; // Obliczenie wyniku mno�enia
        targetResult = result; // Przypisanie wyniku jako docelowego wyniku
        StartCoroutine(DisplayResult());
    }

    IEnumerator DisplayResult()
    {
        float timer = 0f;
        float initialResult = 0f; // Pocz�tkowy wynik (0)
        float decimalThreshold = 1000f; // Pr�g, poni�ej kt�rego u�ywamy liczby dziesi�tnej (w tym przypadku 3 miejsca po przecinku)

        while (timer < duration)
        {
            float progress = timer / duration;
            float easedProgress = easingCurve.Evaluate(progress); // U�ycie krzywej liniowej do obliczenia spowolnienia

            float currentResult = Mathf.Lerp(initialResult, targetResult, easedProgress);

            if (targetResult < decimalThreshold)
            {
                resultText.text = currentResult.ToString("F2")+"m"; // Dwa miejsca po przecinku
            }
            else
            {
                resultText.text = Mathf.RoundToInt(currentResult).ToString() + "m";
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Upewnienie si�, �e ostateczny wynik jest wy�wietlany dok�adnie
        if (targetResult < decimalThreshold)
        {
            resultText.text = targetResult.ToString("F2") + "m"; // Dwa miejsca po przecinku
        }
        else
        {
            resultText.text = Mathf.RoundToInt(targetResult).ToString() + "m";
        }

        comentText.text = text;
    }

    [System.Serializable]
    public class Range
    {
        public int range;
        public float multipler;
        public string text;
    }
}
