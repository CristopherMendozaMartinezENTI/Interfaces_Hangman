using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using TMPro;

public class EditUsernamePanelView : View
{
    private EditUsernamePanelViewModel _viewModel;

    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _backgroundButton;
    [SerializeField] private TMP_InputField _newUsernameInputField;

    public override void SetViewModel(ViewModel viewModel)
    {
        _viewModel = viewModel as EditUsernamePanelViewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
            })
            .AddTo(_disposables);
        
        _saveButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.SaveButtonPressed.Execute(_newUsernameInputField.text);
            })
            .AddTo(_disposables);

        _backgroundButton
            .OnClickAsObservable()
            .Subscribe((_) => {
                _viewModel.BackgroundButtonPressed.Execute();
            })
            .AddTo(_disposables);

        _newUsernameInputField
            .onSubmit.AsObservable()
            .Subscribe((_) => {
                _viewModel.InputFieldSubmitted.Execute(_newUsernameInputField.text);
            })
            .AddTo(_disposables);
    }
}
