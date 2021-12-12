using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSortedScoreEntry
{
    public readonly int orderNumber;
    public readonly string username;
    public readonly int score;

    public NewSortedScoreEntry(int _orderNumber, string _username, int _score) 
    {
        orderNumber = _orderNumber;
        username = _username;
        score = _score;
    }
}
