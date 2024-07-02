using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private RawImage imageRef;
    [SerializeField] private float x;
    [SerializeField] private float y;
    void Update()
    {
        imageRef.uvRect = new Rect(imageRef.uvRect.position + new Vector2(x, y) * Time.deltaTime, imageRef.uvRect.size);
    }
}
