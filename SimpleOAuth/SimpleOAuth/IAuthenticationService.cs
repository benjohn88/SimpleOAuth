namespace SimpleOAuth
{
    public interface IAuthenticationService
    {
        Provider Provider { get; }
        Uri AuthUri(params string[] scope);
    }
}
