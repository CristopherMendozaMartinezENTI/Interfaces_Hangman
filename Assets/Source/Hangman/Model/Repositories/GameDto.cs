using Firebase.Firestore;

[FirestoreData]
public class GameDto : Dto
{
    [FirestoreProperty]
    public string userId {get; set;}
    [FirestoreProperty]
    public string username {get; set;}
    [FirestoreProperty]
    public int score {get; set;}
    [FirestoreProperty]
    public int gametime {get; set;} //Seconds

    public GameDto() {}
    public GameDto(string _userId, string _username, int _score, int _gametime) 
    {
        userId = _userId;
        username = _username;
        score = _score;
        gametime = _gametime;
    }
}
