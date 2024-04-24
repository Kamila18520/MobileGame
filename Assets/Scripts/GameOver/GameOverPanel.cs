using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{

    public GameObject gameOverPanel;
    public TextMeshProUGUI textMeshProUGUI;
    public float points;


    public void OnGameOver()
    {
        Debug.Log("GameOver");
        textMeshProUGUI.text = points.ToString();
        gameOverPanel.SetActive(true);
    }


}
