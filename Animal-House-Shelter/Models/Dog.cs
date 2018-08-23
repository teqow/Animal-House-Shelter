using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public class Dog
    {
        public int DogID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
    }
}
