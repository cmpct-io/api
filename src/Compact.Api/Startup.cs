using Compact.Comments;
using Compact.Impressions;
using Compact.Infrastructure;
using Compact.Reports;
using Compact.Routes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("openCorsPolicy",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api.cmpct.io", Version = "v1" });
            });

            services.AddSingleton<IConfigurationValueProvider, ConfigurationValueProvider>();
            services.AddSingleton<IAzureStorageManager, AzureStorageManager>();

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
            services.AddApplicationInsightsTelemetry();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("openCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.cmpct.io V1");
            });
        }
    }
}