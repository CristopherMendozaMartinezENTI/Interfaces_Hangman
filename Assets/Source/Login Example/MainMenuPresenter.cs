using System;
using System.Collections.Generic;

public class MainMenuPresenter : IDisposable
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

    public void Dispose()
    {
        EventDispatcherService.Instance.Unsubscribe<UserData>(OnUserDateUpdated); 
    }
}
