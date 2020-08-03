using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReservationSystem.Repository;
using ReservationSystem.Repository.CinemaRepository;
using ReservationSystem.Repository.FilmRepository;
using ReservationSystem.Repository.HallRepository;
using ReservationSystem.Repository.PersonRepository;
using ReservationSystem.Repository.PlaceRepository;
using ReservationSystem.Repository.SessionRepository;
using ReservationSystem.Services.CinemaService;
using ReservationSystem.Services.FilmService;
using ReservationSystem.Services.HallService;
using ReservationSystem.Services.PlaceService;
using Microsoft.OpenApi.Models;
using ReservationSystem.Services.PersonService;


namespace ReservationSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<ConnectionStringOption>((settings) =>
            {
                Configuration.GetSection("ConnectionStrings").Bind(settings);
            });
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ReservationSystem API", Version = "v1"});
            });
            
            services.AddSingleton<Db>();
            
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IFilmRepository, FilmRepository>();
            services.AddSingleton<IHallRepository, HallRepository>();
            services.AddSingleton<IPlaceRepository, PlaceRepository>();
            services.AddSingleton<ISessionRepository, SessionRepository>();
            services.AddSingleton<ICinemaRepository, CinemaRepository>();

            services.AddSingleton<ICinemaService, CinemaService>();
            services.AddSingleton<IFilmService, FilmService>();
            services.AddSingleton<IHallService, HallService>();
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IPlaceService, PlaceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationSystem API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cinema}/{action=Cinemas}/{id?}");
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}