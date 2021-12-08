using UnityEngine;
using UniRx;
using TMPro;
using System.Collections.Generic;

public class ProfileView : View
{
    [SerializeField] private TextMeshProUGUI _userId;
    private ProfileViewModel _model;

    public void Configure(ProfileViewModel model)
    {
        _model = model;

        _model
            .UserId
            .Subscribe(userId => _userId.SetText(userId));
    }
}
