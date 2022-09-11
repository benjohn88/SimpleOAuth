namespace SimpleOAuth
{
    public abstract class OAuthClientConfiguration
    {
        public OAuthClientConfiguration(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
