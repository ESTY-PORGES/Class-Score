using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Class Data", menuName = "Class Data", order = 52)]

public class ClassData : ScriptableObject
{
    [SerializeField] private string className;

    private int score;

    [SerializeField] private int index;

    public string ClassName => className;
    public int Index => index;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;

        }
    }
}
