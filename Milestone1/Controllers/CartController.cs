using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
using Milestone1.Data.Repository;
using Milestone1.ViewModels;

namespace Milestone1.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllMerches _merchRep;
        private readonly Cart _cart;

        public CartController(IAllMerches merchRep, Cart cart)
        {
            _merchRep = merchRep;
            _cart = cart;
        }

        public ViewResult Index()
        {
            var items = _cart.getItems();
            _cart.listItems = items;

            var obj = new CartViewModel
            {
                cart = _cart
            };

            return View(obj);

        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _merchRep.Merches.FirstOrDefault(i=>i.id==id);

            if  (item!=null)
            {
                _cart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

    }
}