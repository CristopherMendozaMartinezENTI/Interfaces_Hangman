using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HomePanelPresenter : Presenter
{
    private readonly HomePanelViewModel _homePanelViewModel;

    public HomePanelPresenter(HomePanelViewModel homePanelViewModel)
    {
        _homePanelViewModel = homePanelViewModel;

        ServiceLocator.Instance.GetService<IEventDispatcherService>().Subscribe<UserData>(OnUserDataUpdated);
    }

    private void OnUserDataUpdated(UserData userdata)
    {
        _homePanelViewModel.Username.Value = userdata.Username;
    }

    public new void Dispose()
    {
        ServiceLocator.Instance.GetService<IEventDispatcherService>().Unsubscribe<UserData>(OnUserDataUpdated);
    }
}
