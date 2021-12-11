using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntry
{
    [SerializeField]
    public int Score;
    public int PlayTime;
    public ScoreEntry(int _score, int _playTime)
    {
        Score = _score;
        PlayTime = _playTime;
    }
}
