using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;

namespace Animal_House_Shelter.ViewModels
{
    public class DogsViewModel
    {
        public IEnumerable<Dog> Dogs { get; set; }
    }
}
