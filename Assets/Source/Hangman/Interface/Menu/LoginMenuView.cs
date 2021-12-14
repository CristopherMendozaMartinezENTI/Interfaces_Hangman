using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class LoginMenuView : View
{
    private LoginMenuViewModel _viewModel;

    [SerializeField] private Button _loginButton;
    [SerializeField] private Button _backgroundButton;
    [SerializeField] private TMP_InputField _emailInputField;
    [SerializeField] private TMP_InputField _passwordInputField;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as LoginMenuViewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
            })
            .AddTo(_disposables);

        _loginButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.LoginButtonPressed.Execute(new LoginData(_emailInputField.text, _passwordInputField.text));
            })
            .AddTo(_disposables);

        _backgroundButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.BackgroundButtonPressed.Execute();
            })
            .AddTo(_disposables);

        _emailInputField
            .onSubmit.AsObservable()
            .Subscribe((_) => {
                _viewModel.InputFieldSubmitted.Execute(new LoginData(_emailInputField.text, _passwordInputField.text));
            })
            .AddTo(_disposables);

        _passwordInputField
            .onSubmit.AsObservable()
            .Subscribe((_) => {
                _viewModel.InputFieldSubmitted.Execute(new LoginData(_emailInputField.text, _passwordInputField.text));
            })
            .AddTo(_disposables);
    }
}
