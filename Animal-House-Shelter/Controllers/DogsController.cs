using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Infrastructure;
using Animal_House_Shelter.Models;
using Animal_House_Shelter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Animal_House_Shelter.Controllers
{
    public class DogsController : Controller
    {
        private readonly IDogRepository _dogRepository;

        public DogsController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public IActionResult List(int? page)
        {
            var dogsItems = _dogRepository.Dogs.ToList();
            var pager = new Pager(dogsItems.Count(), page);

            var dogsViewModel = new DogsViewModel
            {
                Dogs = dogsItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(dogsViewModel);
        }

        public IActionResult Details(int id)
        {
            var dog = _dogRepository.GetDogByID(id);
            if (dog == null)
                return NotFound();


            return View(dog);
        }
    }
}