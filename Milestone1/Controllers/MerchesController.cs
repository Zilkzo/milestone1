using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milestone1.Data.Interfaces;
using Milestone1.ViewModels;

namespace Milestone1.Controllers
{
    public class MerchesController : Controller
    {
        private readonly IAllMerches _allMerches;
        private readonly IMerchesCategory _allCategories;


        public MerchesController(IAllMerches iAllMerches, IMerchesCategory iMerchesCat)
        {
            _allMerches = iAllMerches;
            _allCategories = iMerchesCat;
        }

        public ViewResult List()
        {
            MerchesListViewModel obj = new MerchesListViewModel();
            obj.allMerches = _allMerches.Merches;
            obj.currCategory = "All merch: ";
            return View(obj);
        }

        
    }
}