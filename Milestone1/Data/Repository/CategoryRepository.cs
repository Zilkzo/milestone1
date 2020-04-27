using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Repository
{

    public class CategoryRepository : IMerchesCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
