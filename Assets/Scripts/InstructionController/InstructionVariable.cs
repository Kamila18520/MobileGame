using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InstructionPlayerPrefsVariable", menuName = "InstructionVariable/NewVariable")]
public class InstructionVariable : ScriptableObject
{
    //Do test�w, nie wy�acza panelu instrukcji po ponownym wej�ciu
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
