﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Animal_House_Shelter.Controllers
{
    public class AdoptionController : Controller
    {
        //TODO FORM

        public IActionResult Index()
        {
            return View();
        }
    }
}