using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Installer : MonoBehaviour
{
    [SerializeField] private RectTransform _CanvasParent;

    [SerializeField] private MenuPanelView _menuPanelPrefab;
    [SerializeField] private HomePanelView _homePanelPrefab;
    [SerializeField] private ScorePanelView _scorePanelPrefab;
    [SerializeField] private SettingsPanelView _settingsPanelPrefab;

    void Awake()
    {
        var homePanelView = Instantiate(_homePanelPrefab, _CanvasParent);
        var scorePanelView = Instantiate(_scorePanelPrefab, _CanvasParent);
        var settingPanelView = Instantiate(_settingsPanelPrefab, _CanvasParent);
        var menuPanel = Instantiate(_menuPanelPrefab, _CanvasParent);

        var menuPanelViewModel = new MenuPanelViewModel();
        var homePanelViewModel = new HomePanelViewModel();
        var scorePanelViewModel = new ScorePanelViewModel();
        var settingsPanelViewModel = new SettingsPanelViewModel();

        menuPanel.SetViewModel(menuPanelViewModel);
        homePanelView.SetViewModel(homePanelViewModel);
        scorePanelView.SetViewModel(scorePanelViewModel);
        settingPanelView.SetViewModel(settingsPanelViewModel);

        new MenuPanelController(menuPanelViewModel, homePanelViewModel, scorePanelViewModel, settingsPanelViewModel);
    }
}
