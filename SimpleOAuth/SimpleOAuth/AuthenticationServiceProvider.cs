namespace SimpleOAuth
{
    internal class AuthenticationServiceProvider : IAuthenticationServiceProvider
    {
        private readonly IEnumerable<IAuthenticationService> _authenticationService;

        public AuthenticationServiceProvider(IEnumerable<IAuthenticationService> authenticationServices)
        {
            _authenticationService = authenticationServices;
        }

        public IAuthenticationService GetAuthenticationService(Provider provider)
        {
            return _authenticationService.First(x => x.Provider == provider);
        }
    }
}
