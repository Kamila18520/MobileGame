using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{

    public GameObject gameOverPanel;



    public void OnGameOver()
    {
        Debug.Log("GameOver");
        gameOverPanel.SetActive(true);
    }


}
