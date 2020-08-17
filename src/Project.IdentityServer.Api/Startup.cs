using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.identityserver.Api.Configurations;
using Project.identityserver.Application.Services;
using Project.identityserver.Domain.Authentication;
using Project.identityserver.Domain.Core.Extensions.Identity;
using Project.identityserver.Domain.ErrorHandler;
using Project.identityserver.Infrastructure.Contexts.MongoDb;
using Project.identityserver.Infrastructure.Mappings.Mongo;
using Project.identityserver.IoC;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.identityserver.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            string path = string.Empty;

            path = "config/";

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


           // services.AddAuthentication(Configuration);
            services.AddAuthorization();
            services.AddAutoMapperSetup();
            // services.AddPostgreContext<PostgreContext>(Configuration).AddScoped<DbContext, PostgreContext>();

            services.AddMongoDbContext<ReadMongoDbContextConfig, ReadMongoClient>(Configuration, "MongoDb:ReadMongoConfig");//.AddScoped<IReadMongoDbContext, ReadMongoDbContext>();
            services.AddMongoDbContext<WriteMongoDbContextConfig, WriteMongoClient>(Configuration, "MongoDb:WriteMongoConfig").AddScoped<IWriteMongoDbContext, WriteMongoDbContext>();
            services.AddMongoDbContext<EventStoreContextConfig, EventStoreClient>(Configuration, "MongoDb:EventStoreConfig");//.AddScoped<IEventStoreContext, EventStoreContext>();

            //services.AddEventStoreContext(Configuration, "MongoDb:EventStoreConfig");
            //   services.AddRedisContext(Configuration);

            services.AddHealthChecks()
                .AddMongoDb(Configuration.GetSection("MongoDb:ReadMongoConfig:ConnectionString").Value, name: "MongoDb Read")
                .AddMongoDb(Configuration.GetSection("MongoDb:WriteMongoConfig:ConnectionString").Value, name: "MongoDb Connection")
                .AddMongoDb(Configuration.GetSection("MongoDb:EventStoreConfig:ConnectionString").Value, name: "EventStore Connection")
                .AddRedis(Configuration.GetSection("Redis:ConnectionString").Value, name: "Redis Connection")
                .AddNpgSql(Configuration.GetSection("Postgre:ConnectionString").Value, name: "Postgre Connection");

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("Health-API", $"{Configuration.GetSection("ASPNETCORE_URLS").Value}/healthchecks");

            });
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddApiVersioning(v =>
            {
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = new ApiVersion(DateTime.Now);
            });

            //services.AddHttpClient("DemoHttpClientService", c=>
            //{
            //    c.BaseAddress = new Uri("Http://google.com.br");
                
            // });

            services.AddSwaggerSetup();
            //  services.AddKafkaProducer(Configuration, "KafkaProducer");

            RegisterServices(services);

            
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
                               
                
            });

            builder.AddClientStore<ClientStoreService>();
            builder.AddResourceStore<ResourcesStoreAppService>();
            builder.AddPersistedGrantStore<PersistedGrantStoreService>();
            builder.AddResourceOwnerValidator<ResourceOwnerPasswordValidatorService>();
            builder.AddProfileService<ProfileService>();
            builder.AddDeviceFlowStore<DeviceFlowCodeStoreService>();
            builder.AddSigningCredential(services, Configuration, "Certificate");
            builder.AddJwtBearerClientAuthentication();
            builder.AddAppAuthRedirectUriValidator();

            //services.AddOidcStateDataFormatterCache("aad", "demoidsrv");

            services.AddAuthentication();
                        //services.AddLocalApiAuthentication(principal =>
            //{
            //    principal.Identities.First().AddClaim(new Claim("additional_claim", "additional_value"));

            //    return Task.FromResult(principal);
            //});

            MongoDbPersistenceConfigure.Configure();

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, IServiceProvider serviceProvider*/)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.ConfigureExceptionHandler();

            app.UseHealthChecks("/healthchecks", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            //Habilitar para pegar chamada http
            //app.Use(async (context, next) =>

            //{
            //    await next();
            //});


            //Criar indices MongoDB
            var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.IndicesConfigure();
            
            //WhiteListMidlleWare
            //app.UseWhiteListMiddleware();

            app.UseHealthChecksUI(c => {
                c.AsideMenuOpened = true;
                c.AddCustomStylesheet("logo.css");
            });

            app.UseOpenApi();
            app.UseSwaggerUi3(s =>
            {
                s.Path = "/identityserver-api/swagger";
            });

            app.UseApiVersioning();
            app.UseRouting();

            

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseIdentityServer();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services, Configuration);
        }
    }
}