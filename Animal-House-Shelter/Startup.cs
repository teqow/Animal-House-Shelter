﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Infrastructure;
using Animal_House_Shelter.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Animal_House_Shelter
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<ICatRepository, CatRepository>();
            services.AddScoped<IAdoptionRepository, AdoptionRepository>();
            services.AddScoped<IVolunteerRepository, VolunteerRepository>();

            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["AnimalHouseShelterIdentity:DefaultConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddSingleton<EmailSender>();
            services.AddSingleton<IHostedService>(serviceProvider => serviceProvider.GetService<EmailSender>());
            services.AddSingleton<IEmailSender>(serviceProvider => serviceProvider.GetService<EmailSender>());

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();

            //Change
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Dogs/List/Page{dogsPage}",
                    defaults: new {Controller = "Dogs", action = "List"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializerDogs.Seed(app);
            DbInitializerCats.Seed(app);
            IdentitySeedData.Seed(app);

            RotativaConfiguration.Setup(env);
        }
    }
}
