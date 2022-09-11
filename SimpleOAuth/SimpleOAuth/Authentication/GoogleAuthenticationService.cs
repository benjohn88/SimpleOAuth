namespace SimpleOAuth
{
    public class GoogleAuthenticationService : IAuthenticationService
    {
        private const string _basePath = "accounts.google.com";

        private readonly GoogleOAuthClientConfiguration _googleOAuthClientConfiguration;
        private readonly UriBuilder _uriBuilder;

        public Provider Provider => Provider.Google;
        public string[] AllowedScoped { get; private set; }

        public GoogleAuthenticationService(GoogleOAuthClientConfiguration googleOAuthClientConfiguration)
        {
            AllowedScoped = new string[] { "openid", "email" };
            _googleOAuthClientConfiguration = googleOAuthClientConfiguration;
            _uriBuilder = SetUri();
        }

        private UriBuilder SetUri()
        {
            return new UriBuilder
            {
                Scheme = "https",
                Host = _basePath,
                Path = "o/oauth2/v2/auth"
            };
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
            {"client_id", _googleOAuthClientConfiguration.ClientId},
            {"response_type", _googleOAuthClientConfiguration.ResponseType!},
            {"redirect_uri",_googleOAuthClientConfiguration!.RedirectUrl!  }
        };
    }
}
