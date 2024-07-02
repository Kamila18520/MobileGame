using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChooseLevel : MonoBehaviour
{
    [SerializeField] bool pressedCard = false;
    [SerializeField] float panelAnimDuration=1;

    public List<SceneLoader> levelsHandler = new List<SceneLoader>();

    private void Awake()
    {
        pressedCard = false;
  
        foreach (SceneLoader loader in levelsHandler)
        {
            loader.Button.onClick.AddListener(() => LoadScene(loader.Scene , loader.panelAnim));
            loader.panelAnim = loader.Button.gameObject.GetComponent<PanelAnim>();

            loader.Button.gameObject.GetComponent<PanelAnim>().duration = panelAnimDuration ;
        }
    }


    void LoadScene(string scene, PanelAnim panelAnim)
    {
        if (!pressedCard)
        {
            panelAnim.EntryAnimationPanel();
            pressedCard = true;
            Debug.Log("Load scene: " + scene);
            StartCoroutine(Wait(scene));

        }

    }

    IEnumerator Wait(string scene)
    {
        yield return new WaitForSeconds(panelAnimDuration);
        SceneManager.LoadScene(scene);
    }

}


[System.Serializable]

public class SceneLoader
{
    public PanelAnim panelAnim;
    public string Discipline;
    public string CreatedBy;
    public string Scene;
    public Button Button; 
}
