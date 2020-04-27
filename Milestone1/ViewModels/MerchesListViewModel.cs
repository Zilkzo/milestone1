using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.ViewModels
{
    public class MerchesListViewModel
    {
        public IEnumerable<Merch> allMerches { get; set; }

        public string currCategory { get; set; }
    }
}
