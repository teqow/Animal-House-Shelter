﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal_House_Shelter.Models
{
    public interface IAdoptionRepository
    {
        void Adoption(Adoption adoption);
    }
}
