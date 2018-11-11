using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public class Cat
    {
        public int CatID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter greater than 0 variable.")]
        public int Age { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter greater than 0 variable.")]
        public int Weight { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

        //To upload photo from administration panel
        public byte[] Image { get; set; }
    }
}
