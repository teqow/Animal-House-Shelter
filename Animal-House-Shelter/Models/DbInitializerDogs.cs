using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Animal_House_Shelter.Models
{
    public static class DbInitializerDogs
    {
        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Dogs.Any())
            {
                context.AddRange(
                    new Dog { Name = "Abbey", Age = 3, Weight = 48,Gender = "Female",Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" },
                    new Dog { Name = "Test1", Age = 3, Weight = 48, Gender = "Female", Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" },
                    new Dog { Name = "Test2", Age = 3, Weight = 48, Gender = "Female", Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" },
                    new Dog { Name = "Test3", Age = 3, Weight = 48, Gender = "Female", Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" },
                    new Dog { Name = "Test4", Age = 3, Weight = 48, Gender = "Female", Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" },
                    new Dog { Name = "Test5", Age = 3, Weight = 48, Gender = "Female", Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" },
                    new Dog { Name = "Test6", Age = 3, Weight = 48, Gender = "Female", Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" },
                    new Dog { Name = "Test7", Age = 3, Weight = 48, Gender = "Female", Breed = "American Staffordshire Terrier / Labrador Retriever", Description = "Abbey is a timid dog. It takes him a little while to warm up and trust someone. He would do best in a quieter home, with an experienced dog person. He loves other dogs. Abbey IS IN FOSTER CARE! PLEASE FILL OUT THE ADOPTION APPLICATION AND WE WILL CALL AS SOON AS WE RECEIVE IT TO SET UP AN APPOINTMENT FOR YOU TO MEET HIM!", ImgUrl = "https://www.animalhouseshelter.com/wp-content/uploads/2018/08/Abbey-face-600x600.jpg" }
                    );

                context.SaveChanges();
            }
            
        }
    }
}
