using System.Threading.Tasks;
using System.Collections;

using Firebase.Firestore;
using Firebase.Extensions;

using UnityEngine;

public class FirestoreService : DatabaseService
{
    public async Task<bool> ExistKey(string collection, string document)
    {
        bool result = false;
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        DocumentReference docRef = db.Collection(collection).Document(document);
        await docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            result = snapshot.Exists;
        });
        return result;
    }

    public async Task Save<T>(T userDto, string collection, string document) where T : Dto
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        Debug.Log("Firestore Service - Saving - Col: " + collection + " Doc: " + document + "\n" + userDto);

        DocumentReference docRef = db.Collection(collection).Document(document);
        await docRef.SetAsync(userDto);
    }

    public async Task<T> Load<T>(string collection, string document)
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentSnapshot snapshot = null;
        DocumentReference docRef = db.Collection(collection).Document(document);
        await docRef.GetSnapshotAsync().ContinueWithOnMainThread(task => 
        {
            snapshot = task.Result;
        });

        if (snapshot != null) return snapshot.ConvertTo<T>();
        throw new System.Exception("Firestore Service - Load - Couldn't return a document.");
    }
}