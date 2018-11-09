using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Infrastructure;
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

        public IActionResult List(int? page)
        {
            var catsItems = _catRepository.Cats.ToList();
            var pager = new Pager(catsItems.Count(), page);

            var catsViewModel = new CatsViewModel
            {
                Cats = catsItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
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