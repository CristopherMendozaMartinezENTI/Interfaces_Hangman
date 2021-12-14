using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading.Tasks;

public interface RealtimeDatabaseService
{
    public Task<List<KeyValuePair<string, ScoreEntry>>> GetData();
}
