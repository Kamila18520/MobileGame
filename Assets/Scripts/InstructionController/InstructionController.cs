using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstructionController : MonoBehaviour
{
    [SerializeField] InstructionVariable instructionVariable;

    [Header("Events")]
    [SerializeField] UnityEvent stopSctipts;
    [SerializeField] UnityEvent startScripts;

    private void Awake()
    {
        
        bool isFirstTime = instructionVariable.FirstGame;
      
        if (isFirstTime)
        {
            stopSctipts.Invoke();
            instructionVariable.SetBool(false);
        }
        else 
        {
            Destroy(gameObject);
        
        }


    }
    public void GotItButton()
    {
        startScripts.Invoke();
        Destroy(gameObject);
    }

}
