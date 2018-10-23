using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public class DogRepository : IDogRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DogRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Dog> Dogs => _applicationDbContext.Dogs;

        public void SaveDog(Dog dog)
        {
            if (dog.DogID == 0)
            {
                _applicationDbContext.Dogs.Add(dog);
            }
            else
            {
                Dog dbEntry = _applicationDbContext.Dogs.FirstOrDefault(d => d.DogID == dog.DogID);
                if(dbEntry != null)
                {
                    dbEntry.Age = dog.Age;
                    dbEntry.Breed = dog.Breed;
                    dbEntry.Description = dog.Description;
                    dbEntry.Gender = dog.Gender;
                    dbEntry.Name = dog.Name;
                    dbEntry.Weight = dog.Weight;
                    dbEntry.ImgUrl = dog.ImgUrl;
                }
            }

            _applicationDbContext.SaveChanges();
        }

        public Dog DeleteDog(int dogID)
        {
            Dog dbEntry = _applicationDbContext.Dogs.FirstOrDefault(d => d.DogID == dogID);
            if (dbEntry != null)
            {
                _applicationDbContext.Remove(dbEntry);
                _applicationDbContext.SaveChanges();
            }

            return dbEntry;
        }

        public Dog GetDogByID(int dogID)
        {
            return _applicationDbContext.Dogs.FirstOrDefault(d => d.DogID == dogID);
        }
    }
}
