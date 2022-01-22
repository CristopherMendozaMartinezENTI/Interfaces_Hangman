using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Web;

public class InitInstaller : MonoBehaviour
{
    void Awake()
    {
        var firebaseAuthenticationService = new FirebaseAuthenticationService();
        var firestoreDatabaseService = new FirestoreService();
        var eventDispatcherService = new EventDispatcherService();
        var realtimeFirebaseService = new RealtimeFirebaseService();
        var sceneHandlerService = new UnitySceneHandler();
        var hangmanClientService = new HangmanClient();

        ServiceLocator.Instance.RegisterService<AuthenticationService>(firebaseAuthenticationService);
        ServiceLocator.Instance.RegisterService<DatabaseService>(firestoreDatabaseService);
        ServiceLocator.Instance.RegisterService<IEventDispatcherService>(eventDispatcherService);
        ServiceLocator.Instance.RegisterService<SceneHandlerService>(sceneHandlerService);
        ServiceLocator.Instance.RegisterService<RealtimeDatabaseService>(realtimeFirebaseService);
        ServiceLocator.Instance.RegisterService<HangmanClient>(hangmanClientService);
    }

    void Start()
    {
        ServiceLocator.Instance.GetService<SceneHandlerService>().LoadScene("Menu");
    }
}
