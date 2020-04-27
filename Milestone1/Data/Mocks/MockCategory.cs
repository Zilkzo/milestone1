using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Mocks
{
    public class MockCategory : IMerchesCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName="Clothes", description="Branded piece of wardrobe to be worn on body used to promote a film, pop group, artist, etc." },
                    new Category {categoryName="Decor", description="Branded piece of decor to your house used to promote a film, pop group, artist, etc."}
                };
            }
        }
    }
}
