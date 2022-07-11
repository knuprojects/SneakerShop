using Microsoft.Extensions.DependencyInjection;
using Security.Application.Abstraction;
using Security.Application.Commands.AuthenticateCommand;
using Security.Application.Commands.RefreshCommand;
using Security.Application.Commands.RegisterCommand;
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
            services.AddScoped<ICommand, SignIn>();
            services.AddScoped<ICommand, SignUp>();
            services.AddScoped<ICommandHandler<SignIn>, SignInHandler>();
            services.AddScoped<ICommandHandler<SignUp>, SignUpHandler>();
            services.AddScoped<ICommandHandler<Refresh>, RefreshHandler>();

            //var applicationAssembly = typeof(ICommandHandler<>).Assembly;

            //services.Scan(s => s.FromAssemblies(applicationAssembly)
            //    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            //    .AsImplementedInterfaces()
            //    .WithScopedLifetime());

            return services;
        }
    }
}
