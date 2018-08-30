using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public interface IVolunteerRepository
    {
        void Volunteer(Volunteer volunteer);
    }
}
