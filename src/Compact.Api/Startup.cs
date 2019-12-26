using Compact.Routes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddSingleton<IRoutesDataStore, RoutesDataStore>();
            services.AddScoped<IRoutesReader, RoutesReader>();
            services.AddScoped<IRoutesWriter, RoutesWriter>();
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