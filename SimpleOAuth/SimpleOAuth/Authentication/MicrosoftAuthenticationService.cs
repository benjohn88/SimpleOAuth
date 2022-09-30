
using SimpleOAuth;
using SimpleOAuth.ConfigurationModel;

public class MicrosoftAuthenticationService : IAuthenticationService
{
    // Based on https://learn.microsoft.com/de-de/azure/active-directory/develop/id-tokens
    // v1.0 => Azure AD endpoint NOT USED HERE
    // v2.0 => MS Identity Platform (used)
    // v2.0 => permissions and consent https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent 
    private const string _basePath = "login.microsoftonline.com";
    private readonly MicrosoftOAuthClientConfiguration _microsoftOAuthClientConfiguration;
    private readonly UriBuilder _uriBuilder;

    // allowed scopes openid, email, profile, offline_access
    public string[] AllowedScoped { get; private set; }

    public Provider Provider => Provider.Microsoft;

    public MicrosoftAuthenticationService(MicrosoftOAuthClientConfiguration microsoftOAuthClientConfiguration)
    {
        AllowedScoped = new string[] { "openid", "email" };
        _microsoftOAuthClientConfiguration = microsoftOAuthClientConfiguration;
        _uriBuilder = SetUri();
    }
    public Uri AuthUri(params string[] scope)
    {
        var scopes = string.Join(" ", scope.ToArray());

        return _uriBuilder.Uri.AddParamerteCollection(BaseConfigurationSets).AddParameter("scope", scopes);
    }

    public override string ToString()
    {
        return _uriBuilder.Uri.AbsolutePath;
    }

    public Dictionary<string, string> GetUserInfo()
    {
        throw new NotImplementedException();
    }

    private Dictionary<string, string> BaseConfigurationSets => new Dictionary<string, string>
        {
            {"client_id", _microsoftOAuthClientConfiguration.ClientId},
            {"tenant", _microsoftOAuthClientConfiguration.Tenant!},
            {"redirect_uri",_microsoftOAuthClientConfiguration!.RedirectUrl!}
        };

    private UriBuilder SetUri()
    {
        return new UriBuilder
        {
            Scheme = "https",
            Host = _basePath,
            Path = "common/oauth2/v2.0/authorize"
        };
    }
}