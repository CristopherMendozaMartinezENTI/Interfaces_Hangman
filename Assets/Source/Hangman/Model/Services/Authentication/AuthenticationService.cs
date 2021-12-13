using System.Threading.Tasks;

namespace Code.Model.Services.Authentication
{
    public interface AuthenticationService
    {
        public string UserId { get; }

        Task<string> AnonymousLogin();
    }
}