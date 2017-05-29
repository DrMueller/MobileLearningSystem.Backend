using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mmu.Mls.WebServices.Infrastructure.Configurations;

namespace Mmu.Mls.WebServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseCors("All");
            MiddlewareConfiguration.ConfigureMiddlewares(app);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            AppSettingsConfiguration.ConfigureAppSettings(services, Configuration);

            //services.AddCors(
            //    options =>
            //        {
            //            options.AddPolicy(
            //                "All",
            //                builder =>
            //                    builder.AllowAnyOrigin()
            //                        .AllowAnyMethod()
            //                        .AllowAnyHeader()
            //                        .AllowCredentials());
            //        });

            // Add framework services.
            services.AddMvc();

            services.AddAutoMapper();
            var result = IocConfiguration.ConfigureIoC(services);
            return result;
        }
    }
}