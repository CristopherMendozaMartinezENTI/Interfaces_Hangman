public class ProfilePresenter
{
    private readonly ProfileViewModel _model;

    public ProfilePresenter(ProfileViewModel model)
    {
        _model = model; 
        EventDispatcherService.Instance.Subscribe<UserData>(OnUserDateUpdated);
    }
        
    private void OnUserDateUpdated(UserData data)
    {
        _model.UserId.Value = data.Id;
    }
}
