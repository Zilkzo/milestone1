using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Merch.Any())
            {
                content.AddRange(
                    new Merch
                    {
                        name = "T-shirt Han Solo",
                        desc = "T-shirt with the image of Han Solo from SW",
                        img = "/img/tshirtsolo.png",
                        price = 75,
                        isFav = true,
                        available = true,
                        Category = Categories["Clothes"]
                    },
                    new Merch
                    {
                        name = "Poster of Baby Yoda",
                        desc = "Poster with the image of Baby Yoda from Mandalorian",
                        img = "/img/posterbaby.jpg",
                        price = 35,
                        isFav = true,
                        available = true,
                        Category = Categories["Decor"]
                    },
                    new Merch
                    {
                        name = "Sweatshirt of Darth Vader",
                        desc = "Sweatshirt with the image of Darth Vader from SW",
                        img = "/img/sweatshirtvader.jpg",
                        price = 100,
                        isFav = false,
                        available = true,
                        Category = Categories["Clothes"]
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category==null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName="Clothes", description="Branded piece of wardrobe to be worn on body used to promote a film, pop group, artist, etc." },
                        new Category {categoryName="Decor", description="Branded piece of decor to your house used to promote a film, pop group, artist, etc."}
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category cat in list)
                    {
                        category.Add(cat.categoryName, cat);
                    }
                }

                return category;
            }
        }
    }
}
