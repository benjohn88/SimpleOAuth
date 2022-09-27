namespace SimpleOAuth
{
    public class GoogleOAuthClientConfiguration : OAuthClientBaseConfiguration
    {
        public GoogleOAuthClientConfiguration(
            string clientId,
            string clientSecret) : base(clientId, clientSecret)
        { }

        public string? RedirectUrl { get; set; }
        internal string? ResponseType { get; set; } = "code";
    }
}
