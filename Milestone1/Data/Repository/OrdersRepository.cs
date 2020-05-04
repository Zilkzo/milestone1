using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly Cart cart;

        public OrdersRepository(AppDBContent appDBContent, Cart cart)
        {
            this.appDBContent = appDBContent;
            this.cart = cart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = cart.listItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    MerchID = el.itemMerch.id,
                    orderID = order.id,
                    price = el.itemMerch.price

                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
