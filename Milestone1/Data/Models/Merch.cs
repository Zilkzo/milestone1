using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Models
{
    public class Merch
    {
        public int id { set; get; }

        public string name { set; get; }

        public string desc { set; get; }

        public string img { set; get; }

        public uint price { set; get; }

        public bool isFav { set; get; }

        public bool available { set; get; }

        public int categoryID { set; get; }

        public virtual Category Category { set; get; }
    }
}
