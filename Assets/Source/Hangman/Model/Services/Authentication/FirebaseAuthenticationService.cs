using System;
using System.Threading.Tasks;

namespace Code.Model.Services.Authentication
{
    public class FirebaseAuthenticationService : AuthenticationService
    {
        public string UserId { get; private set; }

        public async Task<string> AnonymousLogin()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            UserId = "UserId";
            return UserId;
        }

    }
}