using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VolunteerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Volunteer(Volunteer volunteer)
        {
            _applicationDbContext.Volunteers.Add(volunteer);
            _applicationDbContext.SaveChanges();
        }
    }
}
