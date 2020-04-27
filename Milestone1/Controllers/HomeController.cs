using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milestone1.Data.Interfaces;
using Milestone1.ViewModels;

namespace Milestone1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllMerches _merchRep;

        public HomeController(IAllMerches merchRep)
        {
            _merchRep = merchRep;
        }

        public ViewResult Index()
        {
            var homeMerches = new HomeViewModel
            {
                favMerches=_merchRep.getFavMerches
            };
            return View(homeMerches);
        }
    }
}