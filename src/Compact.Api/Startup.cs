using Compact.Comments;
using Compact.Impressions;
using Compact.Reports;
using Compact.Routes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(endpoints =>
            {
                endpoints.EnableEndpointRouting = false;
            });

            services.AddCors();

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
            services.AddScoped<IReportWriter, ReportWriter>();

            services.AddSingleton<ICommentsDataStore, CommentsDataStore>();
            services.AddScoped<ICommentsWriter, CommentsWriter>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(
                options => options
                .WithOrigins(new string[] { "http://localhost:3000", "https://contentsourceweb.azurewebsites.net" })
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
            );

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.cmpct.io V1");
            });

            if (env.IsDevelopment())
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