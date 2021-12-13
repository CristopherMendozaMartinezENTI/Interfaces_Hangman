using System.Threading.Tasks;

public interface AuthenticationService
{
    public string UserId { get; }

    Task<string> AnonymousLogin();
}
