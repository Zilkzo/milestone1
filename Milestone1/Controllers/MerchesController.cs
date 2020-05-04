using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
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

        [Route("Merches/List")]
        [Route("Merches/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Merch> merches=null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                merches = _allMerches.Merches.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Clothes", category, StringComparison.OrdinalIgnoreCase))
                {
                    merches = _allMerches.Merches.Where(i => i.Category.categoryName.Equals("Clothes")).OrderBy(i => i.id);
                }
                else if (string.Equals("Decor", category, StringComparison.OrdinalIgnoreCase))
                {
                    merches = _allMerches.Merches.Where(i => i.Category.categoryName.Equals("Decor")).OrderBy(i => i.id);
                }

                currCategory = _category;

                
            }

            var merchObj = new MerchesListViewModel
            {
                allMerches = merches,
                currCategory = currCategory
            };
            return View(merchObj);
        }

        
    }
}