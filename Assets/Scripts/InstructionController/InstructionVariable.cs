using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InstructionPlayerPrefsVariable", menuName = "InstructionVariable/NewVariable")]
public class InstructionVariable : ScriptableObject
{
    //Do testów, nie wy³acza panelu instrukcji po ponownym wejœciu
    public bool TEST_donotdisable;
    public bool FirstGame = true;

    public void SetBool(bool value)
    {
        if(TEST_donotdisable) 
        {
            FirstGame = true ;
        }
        else
        {
        FirstGame = value;
    
        }
    }
}
