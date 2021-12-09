using System;
using System.Collections.Generic;

public class MainMenuPresenter : Presenter
{
    private readonly MainMenuViewModel _model;

    public MainMenuPresenter(MainMenuViewModel model)
    {
        _model = model;
            
        EventDispatcherService.Instance.Subscribe<UserData>(OnUserDateUpdated);
    }

    private void OnUserDateUpdated(UserData data)
    {
        _model.IsVisible.Value = false;
    }

    public new void Dispose()
    {
        EventDispatcherService.Instance.Unsubscribe<UserData>(OnUserDateUpdated);
    }
}
