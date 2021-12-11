using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

using Firebase.Firestore;
using Firebase.Extensions;

public class FirestoreService : MonoBehaviour
{
    private Firebase.FirebaseApp app;
    private FirebaseFirestore db;

    private void Awake() {
        db = FirebaseFirestore.DefaultInstance;
    }

    public async Task AddData(string collection, string document, Dictionary<string, object> data)
    {
        DocumentReference docRef = db.Collection(collection).Document(document);

        string debugLog = "Trying to add data to the " + document + " document in the " + collection + " collection.\n";
        foreach (KeyValuePair<string, object> pair in data)
        {
            debugLog += "    " + pair.Key + ": " + pair.Value + "\n";
        }
        Debug.Log(debugLog);

        await docRef.SetAsync(data).ContinueWithOnMainThread(task => {
            Debug.Log("Added data to the " + document + " document in the " + collection + " collection.");
        });
    }

    public async Task<Dictionary<string, object>> GetDocument(string collection, string document)
    {
        Debug.Log("Trying to get data from the " + document + " document in the " + collection + " collection.\n");
        DocumentReference docRef = db.Collection(collection).Document(document);
        Dictionary<string, object> data = new Dictionary<string, object>();
        await docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists) {
                data = snapshot.ToDictionary();
            }
        });
        return data;
    }
}
