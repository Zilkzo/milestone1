using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Models
{
    public class CartItem
    {
        public int id { get; set; }

        public Merch itemMerch { get; set; }

        public uint price { get; set; }

        public string CartID { get; set; }
    }
}
