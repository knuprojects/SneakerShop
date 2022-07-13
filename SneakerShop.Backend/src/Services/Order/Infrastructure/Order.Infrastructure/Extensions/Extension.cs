using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Order.Application.MiddleTier.Contracts;
using Order.Infrastructure.Dal;
using Order.Infrastructure.Exceptions.Middleware;
using Order.Infrastructure.MiddleTier.Services;
using Security.Application.Security.Options;
using System;
using System.Text;

namespace Order.Infrastructure.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<OrderContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Order.Api"));
            });

            services.AddSingleton<ExceptionMiddleware>();

            JwtOptions jwtOptions = new JwtOptions();
            configuration.Bind("JwtOptions", jwtOptions);

            services.AddSingleton(jwtOptions);

            services.AddScoped<IOrderView, OrderView>();
            services.AddScoped<IOrderProccesing, OrderProccesing>();

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
