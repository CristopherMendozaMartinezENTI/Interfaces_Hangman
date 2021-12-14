using System.Threading.Tasks;

public class AuthenticateUseCase : Authenticator
{
    private readonly AuthenticationService _authenticationService;
    private readonly IEventDispatcherService _eventDispatcherService;

    public AuthenticateUseCase(AuthenticationService authenticationService, IEventDispatcherService eventDispatcherService)
    {
        _authenticationService = authenticationService;
        _eventDispatcherService = eventDispatcherService;
    }

    public async Task Authenticate()
    {
        var userId = await _authenticationService.AnonymousLogin();
        // _eventDispatcherService.Dispatch(new UserLogged(userId));
    }
}
