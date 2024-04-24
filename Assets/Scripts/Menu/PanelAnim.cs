using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnim : MonoBehaviour
{
    [SerializeField] bool PlayOnAwake = false;
    [SerializeField] GameObject animatedPanel;
    [Header("Parameters")]
    public float duration = 0.5f;
    [SerializeField] private float minScale = 0.9f;
    [SerializeField] private float maxScale = 1.0f;


    private void Awake()
    {
        if(animatedPanel == null)
        {
            animatedPanel = gameObject;
        }

        if(PlayOnAwake)
        {
            EntryAnimationPanel();
        }
    }

    public void EntryAnimationPanel()
    {
        //ustaw poczatkowa wartoœæ panelu jako 0.9
        animatedPanel.transform.localScale = Vector3.one* minScale;
        //animacja
        LeanTween.scale(animatedPanel, Vector3.one * maxScale, duration)
            .setEase(LeanTweenType.easeOutBack);

    }

    public void ExitAnimationPanel()
    {
        LeanTween.scale(animatedPanel, Vector3.one * minScale, duration)
            .setEase(LeanTweenType.easeInBack);

        StartCoroutine(ExitPanel());
    }


    IEnumerator ExitPanel()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

    
}
