using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }

        public int orderID { get; set; }

        public int MerchID { get; set; }

        public uint price { get; set; }

        public virtual Merch merch { get; set; }

        public virtual Order order { get; set; }
    }
}
