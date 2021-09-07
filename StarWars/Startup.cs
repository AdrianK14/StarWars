using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarWars.Contracts.Factory;
using StarWars.Contracts.Repositories;
using StarWars.Contracts.SwApiClient;
using StarWars.Factories;
using StarWars.Repositories;
using StarWars.SwApiClient;

namespace StarWars
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
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddTransient<IFilmsRepository, FilmsRepository>();
            services.AddTransient<IStarshipsRepository, StarshipsRepository>();
            services.AddTransient<IVehiclesRepository, VehiclesRepository>();
            services.AddTransient<IStarWarsApiClient, StarWarsApiClient>();
            services.AddTransient<IPersonInfoDtoFactory, PersonInfoDtoFactory>();
            services.AddTransient<IWebClient, WebClient>();
            services.AddTransient<IRetrievePersonInfoCommandFactory, RetrievePersonInfoCommandFactory>();

            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
