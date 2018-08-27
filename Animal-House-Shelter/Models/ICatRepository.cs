using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public interface ICatRepository
    {
        IQueryable<Cat> Cats { get; }

        Cat GetCatByID(int catID);

        void SaveCat(Cat cat);

        Cat DeleteCat(int catID);
    }
}
