using System.Threading.Tasks;

public interface AuthenticationService
{
    public string UserId { get; }

    Task<string> AnonymousLogin();
    Task<string> RegisterWithEmailAndPassword(LoginData loginData);
    Task<string> LoginWithEmailAndPassword(LoginData loginData);
}
