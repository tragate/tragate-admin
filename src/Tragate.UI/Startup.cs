using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using StackExchange.Redis;
using Tragate.UI.BuildingBlocks.ApiClient;
using Tragate.UI.Infrastructure;
using Tragate.UI.Service.Location;
using Tragate.UI.Service.Parameter;
using Tragate.UI.Service.Quotation;
using Tragate.UI.Services;

namespace Tragate.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                    optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Error()
                .WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(
                        new Uri(Configuration["ElasticsearchUrl"]))
                    {
                        MinimumLogEventLevel = LogEventLevel.Error,
                        AutoRegisterTemplate = true
                    })
                .CreateLogger();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            // Registers an IDistributedCache to Redis database
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration["RedisUrl"];
                options.InstanceName = "tragate-admin";
            });

            // Uses IDistributedCache to store per-browser sessions!
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromDays(1); });

            // Uses a designated key in the Redis database to store cookie encryption keys!  
            services.AddDataProtection().SetApplicationName("Admin_TragateSharedCookie")
                .PersistKeysToRedis(ConnectionMultiplexer.Connect(Configuration["RedisUrl"]),
                    "Tragate_DataProtectionKeys");

            services.AddAuthentication("TragateIdentity").AddCookie("TragateIdentity", options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(3);
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = "ReturnUrl";
            });

            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            });
            services.AddAutoMapper();
            services.AddCloudscribePagination();
            services.Configure<ConfigSettings>(Configuration);
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.AddNodeServices();

            //add application services
            services.AddTransient<IQuotationService, QuotationService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IParameterService, ParameterService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IRestClient, RestClient>();
            services.AddSingleton<IApplicationUser, ApplicationUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseWebpackDevMiddleware (new WebpackDevMiddlewareOptions {
                //     HotModuleReplacement = true
                // });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseXXssProtection(options => options.EnabledWithBlockMode());
                app.UseXContentTypeOptions();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}