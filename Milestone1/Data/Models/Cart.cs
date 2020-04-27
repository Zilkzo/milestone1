using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Models
{
    public class Cart
    {
        private readonly AppDBContent appDBContent;

        public Cart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string CartID { get; set; }

        public List<CartItem> listItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDBContent>();

            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new Cart(context) { CartID = shopCartId };
        }

        public void AddToCart(Merch merch)
        {
            appDBContent.CartItem.Add(new CartItem
            {
                CartID=CartID,
                itemMerch = merch,
                price=merch.price
            });

            appDBContent.SaveChanges();
        }

        public List<CartItem> getItems()
        {
            return appDBContent.CartItem.Where(c => c.CartID == CartID).Include(s => s.itemMerch).ToList();
        }
    }
}
