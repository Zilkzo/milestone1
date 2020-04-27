using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Mocks
{
    public class MockMerches : IAllMerches
    {
        private readonly IMerchesCategory _categoryMerches = new MockCategory();


        public IEnumerable<Merch> Merches {
            get
            {
                return new List<Merch>
                {
                    new Merch {
                        name="T-shirt Han Solo", 
                        desc="T-shirt with the image of Han Solo from SW", 
                        img="/img/tshirtsolo.png", 
                        price=75, 
                        isFav=true, 
                        available=true, 
                        Category=_categoryMerches.AllCategories.First() 
                    },
                    new Merch {
                        name="Poster of Baby Yoda",
                        desc="Poster with the image of Baby Yoda from Mandalorian",
                        img="/img/posterbaby.jpg",
                        price=35,
                        isFav=true,
                        available=true,
                        Category=_categoryMerches.AllCategories.Last()
                    },
                    new Merch {
                        name="Sweatshirt of Darth Vader",
                        desc="Sweatshirt with the image of Darth Vader from SW",
                        img="/img/sweatshirtvader.jpg",
                        price=100,
                        isFav=false,
                        available=true,
                        Category=_categoryMerches.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Merch> getFavMerches { get; set; }

        public Merch getObjectMerch(int merchID)
        {
            throw new NotImplementedException();
        }
    }
}
