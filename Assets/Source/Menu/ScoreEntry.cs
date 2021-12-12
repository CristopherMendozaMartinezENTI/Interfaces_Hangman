using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntry
{
    [SerializeField]
    public string username;
    public int score;
    public ScoreEntry(string _username, int _score)
    {
        score = _score;
        username = _username;
    }
}
