namespace SimpleOAuth.ConfigurationModel
{
    /// <summary>
    /// based on https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow#first-case-access-token-request-with-a-shared-secret
    /// </summary>
    public class MicrosoftOAuthClientConfiguration : OAuthClientBaseConfiguration
    {
        public MicrosoftOAuthClientConfiguration(string clientId, string clientSecret, string tenant, string scope, string redirectUrl) : base(clientId, clientSecret)
        {
            Tenant = tenant;
            Scope = scope;
            RedirectUrl = redirectUrl;
        }

        public string Tenant { get; } // TODO : Guid or domain-name format! -> Validation
        public string RedirectUrl { get; }
        public string? State { get; set; } //optional, kind of a tag that you get also in return
        public string Scope { get; } // more about the scope here : https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent#the-default-scope
        public string GrantType { get; } = "client_credentials"; // Must be set to client_credentials | https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow#first-case-access-token-request-with-a-shared-secret
    }
}
