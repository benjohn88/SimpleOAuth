# SimpleOAuth

SimpleOAuth Aims to abstract all the complexities of Authentication using external providers.

 - Google (Work- In Progress) 
 - Microsoft (Future) 
 - Facebook (Future)
 - Twitter (Future)

# How To Use
Simply Register the SimpleOAuth along with the respective external provider that you wish to use.
![image](https://user-images.githubusercontent.com/37509414/189523834-db1ed2b4-d0be-43c0-9fe9-695606ef3524.png)

In your controller inject the IAuthenticationServiceProvider which would help you to get the correct Authentication Service
(google/facebook/microsoft/twitter)

    public class AccountController : Controller
    {
        private readonly IAuthenticationServiceProvider _authenticationService;

        public AccountController(IAuthenticationServiceProvider authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Task<IActionResult> Login(string authProvider)
        {
            Enum.TryParse(authProvider, out var provider);
            var authService = _authenticationService.GetAuthenticationService(provider);

            return Redirect(authService.AuthUri("openid", "email").ToString());

        }
    }
The AuthUri Methods takes the Scope with which you are tying to perform the authentication.
NOTE: Your redirect URL MUST also be configured as part of the AddSimpleOAuthGoogle()
