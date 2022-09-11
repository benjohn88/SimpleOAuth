using Microsoft.Extensions.DependencyInjection;

namespace SimpleOAuth.Register
{
    public static class SimpleOAuthRegisteration
    {
        public static IServiceCollection AddSimpleOAuth(this IServiceCollection services)
        {
            services.AddSingleton<IAuthenticationService, GoogleAuthenticationService>();
            services.AddSingleton<IAuthenticationServiceProvider, AuthenticationServiceProvider>();

            return services;
        }

        public static IServiceCollection AddSimpleOAuthGoogle(this IServiceCollection services, Action<GoogleOAuthClientConfiguration> configure)
        {
            services.Configure(configure);
            return services;
        }
    }
}
