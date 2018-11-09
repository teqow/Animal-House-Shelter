using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Infrastructure;
using Animal_House_Shelter.Models;

namespace Animal_House_Shelter.ViewModels
{
    public class CatsViewModel
    {
        public IEnumerable<Cat> Cats { get; set; }
        public Pager Pager { get; set; }
    }
}
