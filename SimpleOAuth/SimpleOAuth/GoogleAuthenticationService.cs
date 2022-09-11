namespace SimpleOAuth
{
    internal class GoogleAuthenticationService : IAuthenticationService
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
            var uriBuilder = new UriBuilder
            {
                Scheme = "https",
                Host = _basePath,
                Path = "o/oauth2/v2/auth"
            };
            foreach (var item in BaseConfigurationSets)
            {
                uriBuilder.Query += $"{item.Key}={item.Value}";
            }
            return uriBuilder;
        }

        public Uri AuthUri(params string[] scope)
        {
            var scopes = string.Join(" ", scope.ToArray());
            _uriBuilder.Query += "scope=" + scopes;

            return _uriBuilder.Uri;
        }

        public override string ToString()
        {
            return _uriBuilder.Uri.AbsolutePath;
        }

        private Dictionary<string, string> BaseConfigurationSets => new Dictionary<string, string>
        {
            {"client_id", _googleOAuthClientConfiguration.ClientId},
            {"response_type", _googleOAuthClientConfiguration.ResponseType},
            {"redirect_uri",_googleOAuthClientConfiguration.RedirectUrl  }
        };
    }
}
