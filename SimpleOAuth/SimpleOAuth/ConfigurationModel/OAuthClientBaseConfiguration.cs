namespace SimpleOAuth
{
    /// <summary>
    /// A base class that is used for all the configurations that are going to be used
    /// </summary>
    public abstract class OAuthClientBaseConfiguration
    {
        public OAuthClientBaseConfiguration(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
