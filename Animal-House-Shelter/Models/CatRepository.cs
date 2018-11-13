using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public class CatRepository : ICatRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CatRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Cat> Cats => _applicationDbContext.Cats;

        public void SaveCat(Cat cat)
        {
            if (cat.CatID == 0)
            {
                _applicationDbContext.Cats.Add(cat);
            }
            else
            {
                Cat dbEntry = _applicationDbContext.Cats.FirstOrDefault(c => c.CatID == cat.CatID);
                if (dbEntry != null)
                {
                    dbEntry.Age = cat.Age;
                    dbEntry.Breed = cat.Breed;
                    dbEntry.Description = cat.Description;
                    dbEntry.Gender = cat.Gender;
                    dbEntry.Name = cat.Name;
                    dbEntry.Weight = cat.Weight;
                    dbEntry.ImgUrl = cat.ImgUrl;
                }
            }
            _applicationDbContext.SaveChanges();
        }

        public Cat DeleteCat(int catID)
        {
            Cat dbEntry = _applicationDbContext.Cats.FirstOrDefault(c => c.CatID == catID);
            if (dbEntry != null)
            {
                _applicationDbContext.Remove(dbEntry);
                _applicationDbContext.SaveChanges();
            }

            return dbEntry;
        }

        public Cat GetCatByID(int catID)
        {
            return _applicationDbContext.Cats.FirstOrDefault(c => c.CatID == catID);
        }
    }
}
