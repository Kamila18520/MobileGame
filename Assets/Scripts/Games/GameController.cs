using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject instruction;


    private void Awake()
    {
        instruction.SetActive(true);
    }

}
