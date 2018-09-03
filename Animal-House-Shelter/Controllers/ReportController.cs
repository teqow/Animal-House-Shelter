using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal_House_Shelter.Models;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Animal_House_Shelter.Controllers
{
    public class ReportController : Controller
    {
        private readonly IDogRepository _dogRepository;
        private readonly ICatRepository _catRepository;

        public ReportController(IDogRepository dogRepository, ICatRepository catRepository)
        {
            _dogRepository = dogRepository;
            _catRepository = catRepository;
        }

        public IActionResult DogsReport()
        {
            return new ViewAsPdf("DogsReport", _dogRepository.Dogs.ToList());
        }

        public IActionResult CatsReport()
        {
            return new ViewAsPdf("CatsReport", _catRepository.Cats.ToList());
        }
    }
}