using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;

namespace Project.identityserver.Api.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerDocument(config =>
            {
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));

                config.AddSecurity("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                config.DocumentName = "swagger";
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Project identityserver API";
                    document.Info.Description = "Project identityserver API";
                    document.SchemaType = SchemaType.Swagger2;
                };

            });

                services.AddOpenApiDocument(config =>
            {
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));

                config.DocumentName = "openapi";
                
                config.AddSecurity("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    
                });

                
                
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Project identityserver API";
                    document.Info.Description = "Project identityserver API";
                    document.SchemaType = SchemaType.OpenApi3;
                    document.BasePath = "Project-identityserver";

                };

            });


        }
    }
}