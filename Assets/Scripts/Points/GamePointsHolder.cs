using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "[Game]MaxScore", menuName = "MaxScore/NewMaxScore")]

public class GamePointsHolder : ScriptableObject
{
    public int maxScore;
}
