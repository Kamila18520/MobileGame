using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateBall : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollRef;
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 20*Time.deltaTime));
        SetBallPosition();
    }

    private void SetBallPosition()
    {
        float newValue;
        if (scrollRef.value < 0)
        {
            newValue = 0;
        }
        else if (scrollRef.value > 1)
        {
            newValue = 1;
        }
        else
        {
            newValue = scrollRef.value;
        }
        GetComponent<RectTransform>().anchoredPosition = new Vector3(newValue * 900 - 450, -210, 0);
    }
}
