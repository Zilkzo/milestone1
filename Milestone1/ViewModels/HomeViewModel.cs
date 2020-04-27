using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Merch> favMerches { get; set; }
    }
}
