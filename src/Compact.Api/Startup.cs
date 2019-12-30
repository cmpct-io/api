using Compact.Comments;
using Compact.Impressions;
using Compact.Reports;
using Compact.Routes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Compact.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string CorsPolicy = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000", "https://cmpct.azurewebsites.net")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddMvc(endpoints =>
            {
                endpoints.EnableEndpointRouting = false;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api.cmpct.io", Version = "v1" });
            });

            services.AddSingleton<IRoutesDataStore, RoutesDataStore>();
            services.AddScoped<IRoutesReader, RoutesReader>();
            services.AddScoped<IRoutesWriter, RoutesWriter>();

            services.AddSingleton<IImpressionsDataStore, ImpressionsDataStore>();
            services.AddScoped<IImpressionsWriter, ImpressionsWriter>();

            services.AddSingleton<IReportsDataStore, ReportsDataStore>();
            services.AddScoped<IReportsReader, ReportsReader>();
            services.AddScoped<IReportWriter, ReportWriter>();

            services.AddSingleton<ICommentsDataStore, CommentsDataStore>();
            services.AddScoped<ICommentsReader, CommentsReader>();
            services.AddScoped<ICommentsWriter, CommentsWriter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(CorsPolicy);

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.cmpct.io V1");
            });

            if ("Development".Equals(env.EnvironmentName, System.StringComparison.OrdinalIgnoreCase))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}