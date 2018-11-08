using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Animal_House_Shelter.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly IAdoptionRepository _adoptionRepository;

        public AdoptionController(IAdoptionRepository adoptionRepository)
        {
            _adoptionRepository = adoptionRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Adoption adoption)
        {
            if (ModelState.IsValid)
            {
                _adoptionRepository.Adoption(adoption);
                return RedirectToAction("Completed");
            }
            return View(adoption);
        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}