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

    public List<SceneLoader> levelsHandler = new List<SceneLoader>();

    private void Awake()
    {
        foreach (SceneLoader loader in levelsHandler)
        {
            loader.Button.onClick.AddListener(() => LoadScene(loader.Scene, loader.pressed));
        }
    }

    void OnClick()
    {

    }

    void EnableCard()
    {

    }

    void DisableCard()
    {

    }


    void LoadScene(UnityEngine.Object scene, bool pressed)
    {

                Debug.Log("£adujê scenê: " + scene.name);
                SceneManager.LoadScene(scene.name);

    }

}


[System.Serializable]

public class SceneLoader
{

    public string Discipline;
    public string CreatedBy;
    public bool pressed;
    public UnityEngine.Object Scene;
    public Button Button; 


}
