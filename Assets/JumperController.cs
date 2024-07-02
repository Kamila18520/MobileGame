using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    public Animator animatorRef;
    public Animator splashRef;

    public void GoodJump()
    {
        animatorRef.SetTrigger("GoodJump");
        splashRef.SetTrigger("Splash");
    }

    public void BadJump() 
    {
        animatorRef.SetTrigger("BadJump");
    }
}
