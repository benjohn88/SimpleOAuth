using Microsoft.Extensions.DependencyInjection;
using SimpleOAuth.ConfigurationModel;

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

        public static IServiceCollection AddSimpleOAuthGoogle(this IServiceCollection services, Action<SimpleOAuthConfiguration> configure)
        {
            services.Configure(configure);
            return services;
        }
    }
}
