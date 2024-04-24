using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BubbleController : MonoBehaviour, IPointerClickHandler
{
    [Header("TEST dont lose")]
    public bool TEST = false;

    [Header("Bubble")]
    [SerializeField] float lifeTime = 4;
    [SerializeField] float time;
    [SerializeField] bool clicked = false;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    float animationTime;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.transform.localScale = Vector3.zero;
        GameobjectScale();
    }

    private void GameobjectScale()
    {
        LeanTween.scale(gameObject, Vector2.one, lifeTime)
                .setEase(LeanTweenType.easeOutBack);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= lifeTime && !clicked)
        {
            if (!TEST)
            {
                GetComponent<GameOverPanel>().OnGameOver();

            }

            Destroy(gameObject);
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!clicked)
        {
            audioSource.Play();
            clicked = true;
            gameObject.GetComponent<Button>().enabled = false;
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            float length = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            Destroy(gameObject, 0.22f);
        }

    }

}
