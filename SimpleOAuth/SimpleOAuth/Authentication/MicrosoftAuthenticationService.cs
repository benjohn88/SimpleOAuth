
using SimpleOAuth;
using SimpleOAuth.ConfigurationModel;

public class MicrosoftAuthenticationService : IAuthenticationService
{
    public Provider Provider => Provider.Microsoft;

    public MicrosoftAuthenticationService(MicrosoftOAuthClientConfiguration microsoftOAuthClientConfiguration)
    {

    }
    public Uri AuthUri(params string[] scope)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, string> GetUserInfo()
    {
        throw new NotImplementedException();
    }
}