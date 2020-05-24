using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Milestone1.Data;
using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
using Milestone1.ViewModels;

namespace Milestone1.Controllers
{
    public class MerchesController : Controller
    {
        private readonly IAllMerches _allMerches;
        private readonly IMerchesCategory _allCategories;
        private readonly AppDBContent _dbContext;


        public MerchesController(IAllMerches iAllMerches, IMerchesCategory iMerchesCat, AppDBContent dbContext)
        {
            _allMerches = iAllMerches;
            _allCategories = iMerchesCat;
            _dbContext = dbContext;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(Merch merch)
        {


            _dbContext.Merch.Add(merch);
            await _dbContext.SaveChangesAsync();

            var merches = await _dbContext.Merch.ToListAsync();

            return RedirectToAction("List");
        }



        public RedirectToActionResult Delete(int id)
        {
            var item = _allMerches.Merches.FirstOrDefault(i => i.id == id);

            if (item != null)
            {
                _dbContext.Remove(item);
            }
            _dbContext.SaveChanges();

            return RedirectToAction("List");
        }


    }
}