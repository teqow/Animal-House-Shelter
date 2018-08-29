using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public class AdoptionRepository : IAdoptionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdoptionRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Adoption(Adoption adoption)
        {
            _applicationDbContext.Adoptions.Add(adoption);
            _applicationDbContext.SaveChanges();
        }


    }
}
