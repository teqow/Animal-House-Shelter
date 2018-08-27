using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;
using Animal_House_Shelter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Animal_House_Shelter.Controllers
{
    public class CatsController : Controller
    {
        private readonly ICatRepository _catRepository;

        public CatsController(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }


        public IActionResult List()
        {
            var cats = _catRepository.Cats.OrderBy(c => c.Name);

            var catsViewModel = new CatsViewModel
            {
                Cats = cats.ToList()
            };

            return View(catsViewModel);
        }

        public IActionResult Details(int id)
        {
            var cat = _catRepository.GetCatByID(id);
            if (cat == null)
                return NotFound();


            return View(cat);
        }
    }
}