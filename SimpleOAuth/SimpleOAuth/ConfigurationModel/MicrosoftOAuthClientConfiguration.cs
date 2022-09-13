namespace SimpleOAuth.ConfigurationModel
{
    /// <summary>
    /// based on https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow#first-case-access-token-request-with-a-shared-secret
    /// </summary>
    public class MicrosoftOAuthClientConfiguration : OAuthClientConfiguration
    {
        public MicrosoftOAuthClientConfiguration(string clientId, string clientSecret, string tenant, string scope) : base(clientId, clientSecret)
        {
            Tenant = tenant;
            Scope = scope;
        }

        public string Tenant { get; } // TODO : Guid or domain-name format! -> Validation
        public string Scope { get; } // more about the scope here : https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent#the-default-scope
        public string GrantType { get; } = "client_credentials"; // Must be set to client_credentials | https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow#first-case-access-token-request-with-a-shared-secret
    }
}
