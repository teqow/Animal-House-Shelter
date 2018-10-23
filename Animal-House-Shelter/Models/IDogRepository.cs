using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public interface IDogRepository
    {
        IEnumerable<Dog> Dogs { get; }

        Dog GetDogByID(int dogID);

        void SaveDog(Dog dog);

        Dog DeleteDog(int dogID);
    }
}
