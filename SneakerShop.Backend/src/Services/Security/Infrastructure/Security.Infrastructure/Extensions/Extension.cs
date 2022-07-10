using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Security.Application.Security;
using Security.Application.Security.Options;
using Security.Domain.Abstraction;
using Security.Infrastructure.Dal;
using Security.Infrastructure.Exceptions;
using Security.Infrastructure.Security;
using Security.Infrastructure.Time;
using System;
using System.Text;

namespace Security.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<SecurityContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Security.Api"));
            });

            services.AddSingleton<ExceptionMiddleware>();
            services.AddHttpContextAccessor();

            JwtOptions jwtOptions = new JwtOptions();
            configuration.Bind("JwtOptions", jwtOptions);

            services.AddSingleton(jwtOptions);

            services.AddScoped<IPasswordManager, PasswordManager>();
            services.AddScoped<ITokenStorage, HttpContextTokenStorage>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClock, Clock>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.AccessTokenSecret)),
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
