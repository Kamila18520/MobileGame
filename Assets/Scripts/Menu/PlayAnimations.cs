using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    [Header("BG Race animation")]
    [SerializeField] GameObject[] race;
    [SerializeField] float duration = 0.5f;



    public void Awake()
    {
        foreach (GameObject r in race) 
        {
            r.transform.localScale = new Vector3(0, r.transform.localScale.y, r.transform.localScale.z);

        }
        StartRaceAnimation();
    }

    public void StartRaceAnimation()
    {
        StartCoroutine(RaceAnim(Vector3.one, false));
    }

    public void ExitRaceAnimation()
    {
        StartCoroutine(RaceAnim(Vector3.zero, true));
    }


    IEnumerator RaceAnim(Vector3 target, bool close)
    {
        foreach (GameObject r in race)
        {
            LeanTween.scale(r, new Vector3(target.x, 1,1), duration)
                 .setEase(LeanTweenType.easeInOutCubic);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(duration);
        if (close)
            gameObject.SetActive(false);

    }

}
