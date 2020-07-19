using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Inori.IdentityApi
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
            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                options.UserInteraction = new UserInteractionOptions
                {
                    LogoutUrl = "/Account/Logout",                              // 登录地址
                    LoginUrl = "/Account/Login",                                // 登出地址
                    LoginReturnUrlParameter = "returnUrl"                       // 设置传递给登录页面的返回URL参数的名称。默认为returnUrl 
                    // ConsentUrl = "/Account/Consent",                         // 允许授权同意页面地址
                    // ErrorUrl = "/Account/Error",                             // 错误页面地址
                    // LogoutIdParameter = "logoutId",                          // 设置传递给注销页面的注销消息ID参数的名称。缺省为logoutId 
                    // ConsentReturnUrlParameter = "ReturnUrl",                 // 设置传递给同意页面的返回URL参数的名称。默认为returnUrl
                    // ErrorIdParameter = "errorId",                            // 设置传递给错误页面的错误消息ID参数的名称。缺省为errorId
                    // CustomRedirectReturnUrlParameter = "ReturnUrl",          // 设置从授权端点传递给自定义重定向的返回URL参数的名称。默认为returnUrl                   
                    // CookieMessageThreshold = 5                               // 由于浏览器对Cookie的大小有限制，设置Cookies数量的限制，有效的保证了浏览器打开多个选项卡，一旦超出了Cookies限制就会清除以前的Cookies值
                };
            })
            .AddInMemoryIdentityResources(Config.GetIds())
            .AddInMemoryApiResources(Config.GetApis())
            .AddInMemoryClients(Config.GetClients())
            .AddTestUsers(Config.GetTestUsers())
            .AddDeveloperSigningCredential();

            // services.AddAuthorization();
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
