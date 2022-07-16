using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Extensions
{
    public class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<JwtTokenGenerator>();
            services.AddSingleton<AccessTokenGenerator>();
            services.AddSingleton<RefreshTokenGenerator>();
            services.AddSingleton<RefreshTokenValidator>();
            services.AddScoped<ICommand, SignIn>();
            services.AddScoped<ICommand, SignUp>();
            services.AddScoped<ICommand, Refresh>();
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
