using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimations : MonoBehaviour
{
    [Header("BG Race animation")]
    [SerializeField] GameObject[] race;
    [SerializeField] float duration = 0.5f;

    [Header("Games")]
    [SerializeField] GameObject gamesParent;
    GameObject[] games;


    public void Awake()
    {
        foreach (GameObject r in race)
        {
            r.transform.localScale = new Vector3(0, r.transform.localScale.y, r.transform.localScale.z);
        }

        games = new GameObject[gamesParent.transform.childCount];
        for (int i = 0; i < gamesParent.transform.childCount; i++)
        {
            games[i] = gamesParent.transform.GetChild(i).gameObject;

            games[i].transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            games[i].transform.localScale = new Vector3(0, 1, 1);

        }

        StartRaceAnimation();
    }
    bool entry;
    public void StartRaceAnimation()
    {
        entry = true;
        StartCoroutine(RaceAnim(Vector3.one, entry));
        StartCoroutine(GamesAnim(Vector3.one, 0, duration));
    }

    public void ExitRaceAnimation()
    {
        entry = false;
        StartCoroutine(GamesAnim(Vector3.one, -90f, duration));
        StartCoroutine(RaceAnim(Vector3.zero, entry));
    }

    IEnumerator GamesAnim(Vector3 target, float rotate, float rotateDuration)
    {
        foreach (GameObject t in games)
        {
            if(entry)
            LeanTween.rotateY(t, rotate, rotateDuration)
                 .setEase(LeanTweenType.easeInOutQuint);
            else
                LeanTween.rotateY(t, rotate, rotateDuration)
                 .setEase(LeanTweenType.easeOutCirc);


            LeanTween.scale(t, target, duration)
                 .setEase(LeanTweenType.easeOutBack);

            yield return new WaitForSeconds(0.1f); // zmienione opóŸnienie
        }
    }

    IEnumerator RaceAnim(Vector3 target, bool close)
    {
        foreach (GameObject r in race)
        {
            LeanTween.scale(r, new Vector3(target.x, 1, 1), duration)
                .setEase(LeanTweenType.easeInOutBack);
            yield return new WaitForSeconds(0.1f); // zmienione opóŸnienie
        }
        yield return new WaitForSeconds(duration);
        if (!close)
            gameObject.SetActive(false);
    }
}
