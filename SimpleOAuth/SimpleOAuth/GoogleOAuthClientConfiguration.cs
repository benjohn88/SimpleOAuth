namespace SimpleOAuth
{
    public class GoogleOAuthClientConfiguration : OAuthClientConfiguration
    {
        public GoogleOAuthClientConfiguration(string clientId) : base(clientId)
        {
        }

        public string RedirectUrl { get; set; }
        public string ResponseType { get; set; }
    }
}
