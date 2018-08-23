using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public class DbInitializerDogs
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Dogs.Any())
            {
                context.AddRange(
                    new Dog { //TODO }
                        );
            }
        }
    }
}
