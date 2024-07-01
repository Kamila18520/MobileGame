using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    public Animator animatorRef;

    public void GoodJump()
    {
        animatorRef.SetTrigger("GoodJump");
    }

    public void BadJump() 
    {
        animatorRef.SetTrigger("BadJump");
    }
}
