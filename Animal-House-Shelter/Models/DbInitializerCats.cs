using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Animal_House_Shelter.Models
{
    public static class DbInitializerCats
    {
        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Cats.Any())
            {
                context.AddRange(
                    new Cat { Name = "Abby", Age = 2, Gender = "Female", Breed = "Calico / Domestic Short Hair", Description = "Born: 04/16/2018 All cats are microchipped, neutered, current on all vaccines, FeLV/FIV tested and started on Heartgard Plus & Frontline Plus.All family members need to be present at the time of the adoption", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/abby-head-1-600x600.jpg" },
                    new Cat { Name = "afasf", Age = 2, Gender = "Female", Breed = "Calico / Domestic Short Hair", Description = "Born: 04/16/2018 All cats are microchipped, neutered, current on all vaccines, FeLV/FIV tested and started on Heartgard Plus & Frontline Plus.All family members need to be present at the time of the adoption", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/abby-head-1-600x600.jpg" }
                );
                context.SaveChanges();
            }
        }
    }
}
