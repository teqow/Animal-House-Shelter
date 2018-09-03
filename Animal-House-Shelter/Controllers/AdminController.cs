using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Animal_House_Shelter.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ICatRepository _catRepository;
        private readonly IDogRepository _dogRepository;

        public AdminController(ICatRepository catRepository, IDogRepository dogRepository)
        {
            _catRepository = catRepository;
            _dogRepository = dogRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET List of Dogs
        public IActionResult DogsList()
        {
            return View(_dogRepository.Dogs);
        }

        //GET List of Cats
        public IActionResult CatsList()
        {
            return View(_catRepository.Cats);
        }

        //Dogs

        public IActionResult EditDogs(int dogID)
        {
            return View(_dogRepository.Dogs.FirstOrDefault(d => d.DogID == dogID));
        }

        [HttpPost]
        public IActionResult EditDogs(Dog dog)
        {
            if (ModelState.IsValid)
            {
                _dogRepository.SaveDog(dog);
                TempData["message"] = $"Save {dog.Name}.";
                return RedirectToAction("DogsList");
            }
            else
            {
                return View(dog);
            }
        }

        public IActionResult CreateDogs()
        {
            return View("EditDogs", new Dog());
        }

        [HttpPost]
        public IActionResult DeleteDogs(int dogID)
        {
            Dog deleteDog = _dogRepository.DeleteDog(dogID);
            if (deleteDog != null)
            {
                TempData["message"] = $"Delete {deleteDog.Name}.";
            }

            return RedirectToAction("DogsList");
        }

        //Cats

        public IActionResult EditCats(int catID)
        {
            return View(_catRepository.Cats.FirstOrDefault(c => c.CatID == catID));
        }

        [HttpPost]
        public IActionResult EditCats(Cat cat)
        {
            if (ModelState.IsValid)
            {
                _catRepository.SaveCat(cat);
                TempData["message"] = $"Save {cat.Name}.";
                return RedirectToAction("CatsList");
            }
            else
            {
                return View(cat);
            }
        }

        public IActionResult CreateCats()
        {
            return View("EditCats", new Cat());
        }

        [HttpPost]
        public IActionResult DeleteCats(int catID)
        {
            Cat deteleCat = _catRepository.DeleteCat(catID);
            if (deteleCat != null)
            {
                TempData["message"] = $"Delete {deteleCat.Name}.";
            }

            return RedirectToAction("CatsList");
        }

    }
}