using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public interface IDatabaseService
{
    public void InitializeDatabase();
    public Task AddData(string collection, string document, Dictionary<string, object> data);
    public Task<Dictionary<string, object>> GetDocument(string collection, string document);
    public Task<Dictionary<string, Dictionary<string, object>>> GetCollection(string collection);
}
