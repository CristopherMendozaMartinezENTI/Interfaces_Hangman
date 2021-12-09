using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
using TMPro;

public class EditUsernamePanelView : MonoBehaviour
{
    private EditUsernamePanelViewModel _viewModel;

    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _backgroundButton;
    [SerializeField] private TMP_InputField _newUsernameInputField;

    public void SetViewModel(EditUsernamePanelViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .IsVisible
            .Subscribe((isVisible) => {
                gameObject.SetActive(isVisible);
            });
        
        _saveButton.onClick.AddListener(() => {
            _viewModel.SaveButtonPressed.Execute(_newUsernameInputField.text);
        }
        );

        _newUsernameInputField.onSubmit.AddListener((_) => {
            _viewModel.InputFieldSubmitted.Execute(_newUsernameInputField.text);
        }
        );

        _backgroundButton.onClick.AddListener(() => {
            _viewModel.BackgroundButtonPressed.Execute();
        }
        );
    }
}
