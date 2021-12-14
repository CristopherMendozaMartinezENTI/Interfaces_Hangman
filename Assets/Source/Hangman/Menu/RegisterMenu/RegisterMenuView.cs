using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class RegisterMenuView : View
{
    private RegisterMenuViewModel _viewModel;

    [SerializeField] private Button _registerButton;
    [SerializeField] private Button _backgroundButton;
    [SerializeField] private TMP_InputField _emailInputField;
    [SerializeField] private TMP_InputField _passwordInputField;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as RegisterMenuViewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
            })
            .AddTo(_disposables);

        _registerButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.RegisterButtonPressed.Execute(new LoginData(_emailInputField.text, _passwordInputField.text));
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
