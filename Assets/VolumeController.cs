using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixerRef;
    public void ToggleSFX()
    {
        mixerRef.GetFloat("SFX", out float currentValue);
        Debug.Log(currentValue);
        if (currentValue != 0f) 
        {
            mixerRef.SetFloat("SFX", 0f);
        }
        else
        {
            mixerRef.SetFloat("SFX", -80f);
        }   
    }

    public void ToggleOST()
    {
        mixerRef.GetFloat("Music", out float currentValue);
        Debug.Log(currentValue);
        if (currentValue != 0f)
        {
            mixerRef.SetFloat("Music", 0f);
        }
        else
        {
            mixerRef.SetFloat("Music", -80f);
        }
    }
}
