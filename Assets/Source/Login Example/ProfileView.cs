using UnityEngine;
using UniRx;
using TMPro;
using System.Collections.Generic;

public class ProfileView : View
{
    [SerializeField] private TextMeshProUGUI _userId;
    private ProfileViewModel _model;

    public override void SetViewModel(ViewModel model)
    {
        _model = model as ProfileViewModel;

        _model
            .UserId
            .Subscribe(userId => {
                _userId.SetText(userId);
            })
            .AddTo(_disposables);
    }
}
