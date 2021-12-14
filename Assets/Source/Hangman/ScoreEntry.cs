using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntry
{
    [SerializeField]
    public int score;
    public int playtime;

    public ScoreEntry(int _score, int _playtime)
    {
        score = _score;
        playtime = _playtime;
    }
}
