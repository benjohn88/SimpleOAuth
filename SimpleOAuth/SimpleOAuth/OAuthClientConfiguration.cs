namespace SimpleOAuth
{
    public abstract class OAuthClientConfiguration
    {
        public OAuthClientConfiguration(string clientId)
        {
            ClientId = clientId;
        }

        public string ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
