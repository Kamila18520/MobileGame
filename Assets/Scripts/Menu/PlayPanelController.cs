using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPanelController : MonoBehaviour
{
    [SerializeField] private GameObject[] uiObjects = new GameObject[2];


    private void OnEnable()
    {
        EnableDisableObjects(true);
    }



    public void EnableDisableObjects(bool active)
    {
        for (int i = 0; i < uiObjects.Length; i++)
        {
            uiObjects[i].SetActive(active);
        }
    }
}
