using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardTopPoint : MonoBehaviour
{
    [SerializeField] private GamePointsHolder GamePointsHolder;
    [SerializeField] private string value;
    [SerializeField] private float maxScore;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        if(GamePointsHolder != null)
        {
        maxScore = GamePointsHolder.maxScore;
        textMeshProUGUI.text = maxScore.ToString() + value;

        }
        else
        {
            textMeshProUGUI.text = "Wartosc nie dodana";

        }
    }


}
