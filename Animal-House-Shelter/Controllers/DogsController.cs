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
        public int PageSize = 4;

        public DogsController(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public IActionResult List(int dogsPage = 1)
            => View(new DogsViewModel
            {
                Dogs = _dogRepository.Dogs.OrderBy(d => d.DogID).Skip((dogsPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = dogsPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _dogRepository.Dogs.Count()
                }
            });


        public IActionResult Details(int id)
        {
            var dog = _dogRepository.GetDogByID(id);
            if (dog == null)
                return NotFound();


            return View(dog);
        }
    }
}