using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Basket.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Security.Api", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.WithOrigins(new[] { "http://localhost:3000", "http://localhost:8080", "http://localhost:4200" });
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowCredentials();
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
