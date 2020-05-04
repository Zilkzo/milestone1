using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;

namespace Milestone1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly Cart cart;

        public OrderController(IAllOrders allOrders, Cart cart)
        {
            this.allOrders = allOrders;
            this.cart = cart;
        }

        public IActionResult Checkout()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            cart.listItems = cart.getItems();

            if (cart.listItems.Count==0)
            {
                ModelState.AddModelError("", "You have to have some merch!");
            }

            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order was successfully processed!";
            return View();
        }

    }
}