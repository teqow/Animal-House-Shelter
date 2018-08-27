using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;
using Animal_House_Shelter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Animal_House_Shelter.Controllers
{
    public class DogsController : Controller
    {
        private readonly IDogRepository _dogRepository;

        public DogsController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public IActionResult List()
        {
            var dogs = _dogRepository.Dogs.OrderBy(d => d.Name);

            var dogsViewModel = new DogsViewModel
            {
                Dogs = dogs.ToList()
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