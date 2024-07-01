using Microsoft.OpenApi.Models;
using System.Reflection;

namespace IntegraApi.Application.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Onboarding API",
                    Version = "v5",
                    Description = "Simple RESTful API built with ASP.NET Core.",
                    Contact = new OpenApiContact
                    {
                        Name = "Iasmin  Borges",
                        Url = new Uri("https://github.com/iasminsoares.io/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Onboarding API");
                options.DocumentTitle = "Onboarding API";
            });
            return app;
        }
    }
}
