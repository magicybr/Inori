using Inori.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Linq;
using System.Security.Principal;

namespace Inori.WebApi
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
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => { 
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api1";
                    options.TokenValidationParameters.ClockSkew = TimeSpan.FromMinutes(5);  // 验证token是否超时
                    options.TokenValidationParameters.RequireExpirationTime = true;
                });
            services.AddControllers(configure =>
                {
                    configure.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters();

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Inori API";
                    document.Info.Description = "Inori Web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };

                //string[] scopes = new[] { "openid", "email" };
                //Enumerable.Empty<string>()
                //config.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                //{
                //    Type = OpenApiSecuritySchemeType.OAuth2,
                //    Description = "这里是信息描述",
                //    Flow = OpenApiOAuth2Flow.Implicit,
                //    TokenUrl = "http://localhost:5000/connect/token",
                //    AuthorizationUrl = "http://localhost:5000/connect/authorize",
                //    Scopes = new Dictionary<string, string>
                //    {
                //        {"api1", "这里是测试API资源" }
                //    },
                //});
                //config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
                //config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
                config.AddSecurity("apikey", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "api1",
                    In = OpenApiSecurityApiKeyLocation.Header
                });

                config.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddTransient<ICurrentPrincipalAccessor, ThreadCurrentPrincipalAccessor>();
            services.AddTransient<ICurrentUser, CurrentUser>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();
            //app.UseSwaggerUi3(settings =>
            //{
            //    settings.OAuth2Client = new OAuth2ClientSettings
            //    {
            //        ClientId = "api1",
            //        ClientSecret = "",
            //        AppName = "Test Swagger Api",
            //    };
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
