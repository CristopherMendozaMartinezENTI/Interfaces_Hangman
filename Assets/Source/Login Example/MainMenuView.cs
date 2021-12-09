using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button _loginButton;
    private MainMenuViewModel _model;

    public override void SetViewModel(ViewModel model)
    {
        _model = model as MainMenuViewModel;

        _model
            .IsVisible
            .Subscribe(isVisible => gameObject.SetActive(isVisible))
            .AddTo(_disposables);

        _loginButton
            .OnClickAsObservable()
            .Subscribe((_) => { 
                _model.LoginButtonPressed.Execute(); 
            })
            .AddTo(_disposables);
    }
}
