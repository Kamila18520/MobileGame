using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System;

public class FunfactController : MonoBehaviour
{
    [SerializeField] TextAsset funfactLines;
    [SerializeField] TextMeshProUGUI funfactTextUGUI;
    List<string> lines = new List<string>();

    private void Awake()
    {
        StringReader reader = new StringReader(funfactLines.text);
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            lines.Add(line);
        }

        RandomFactGenerate();
    }

    string randomLine;
    public void RandomFactGenerate()
    {
        int randomIndex = UnityEngine.Random.Range(0, lines.Count);
        randomLine = lines[randomIndex];

        funfactTextUGUI.text = randomLine;

    }
}
