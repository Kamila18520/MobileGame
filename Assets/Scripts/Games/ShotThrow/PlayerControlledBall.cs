using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControlledBall : MonoBehaviour
{
    public bool mouseOn;

   public void mouseOverBall()
    {
        mouseOn = true;
    }

    public void mouseNotOverBall()
    {
        mouseOn = false;
    }

}