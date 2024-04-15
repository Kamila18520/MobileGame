using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnim : MonoBehaviour
{
    [SerializeField] GameObject animatedPanel;
    [Header("Parameters")]
    [SerializeField] float duration = 0.5f;
    private float minScale = 0.9f;

    public void EntryAnimationPanel()
    {
        //ustaw poczatkowa wartoœæ panelu jako 0.9
        animatedPanel.transform.localScale = Vector3.one* minScale;
        //animacja
        LeanTween.scale(animatedPanel, Vector3.one, duration)
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
