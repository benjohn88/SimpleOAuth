namespace SimpleOAuth
{
    public interface IAuthenticationServiceProvider
    {
        IAuthenticationService GetAuthenticationService(Provider provider);
    }
}
