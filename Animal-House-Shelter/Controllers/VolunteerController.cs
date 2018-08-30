using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Animal_House_Shelter.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerController(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _volunteerRepository.Volunteer(volunteer);
                return RedirectToAction("Completed");
            }
            return View(volunteer);

        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}