using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Animal_House_Shelter.Controllers
{
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
    }
}