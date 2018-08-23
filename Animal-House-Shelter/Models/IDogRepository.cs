using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public interface IDogRepository
    {
        IQueryable<Dog> Dogs { get; }

        void SaveDog(Dog dog);

        Dog DeleteDog(int dogID);
    }
}
