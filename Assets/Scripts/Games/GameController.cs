using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject instruction;

    public UnityEvent stopSctipts;
    public UnityEvent startScripts;

    private void Awake()
    {
        instruction.SetActive(true);
    }

    public void InvokeGame()
    {
        startScripts.Invoke();
    }

    public void StopGame()
    {
        startScripts.Invoke();
    }

}
