using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public TimerScript timerRef;
    public JumperController controllerRef;
   

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Guzik jest aktywny");
    }

    public void Guzik(bool test)
    {
        Debug.Log("Guzik zosta³ wciœniêty. " + test);
        if(timerRef.IsIndicatorInRange())
        {
            controllerRef.GoodJump();
        }
        else
        {
            controllerRef.BadJump();
        }
    }

}
