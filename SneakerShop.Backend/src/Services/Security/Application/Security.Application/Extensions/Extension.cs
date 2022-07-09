using Microsoft.Extensions.DependencyInjection;
using Security.Application.Abstraction;
using Security.Application.Security.TokenGenerators;
using Security.Application.Security.TokenValidator;

namespace Security.Application.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<JwtTokenGenerator>();
            services.AddSingleton<AccessTokenGenerator>();
            services.AddSingleton<RefreshTokenGenerator>();
            services.AddSingleton<RefreshTokenValidator>();

            var applicationAssembly = typeof(ICommandHandler<>).Assembly;

            //services.Scan(s => s.FromAssemblies(applicationAssembly)
            //    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            //    .AsImplementedInterfaces()
            //    .WithScopedLifetime());

            return services;
        }
    }
}
