using ExpandedDetailView.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpandedDetailView.Models.Factories
{
    public class CategoryFactory
    {
        List<Category> allCategories = new List<Category>();

        public CategoryFactory()
        {
            allCategories.Add(new Category()
            {
                CategoryID = 1,
                Name = "Nike"
            });

            allCategories.Add(new Category()
            {
                CategoryID = 2,
                Name = "Lacoste"
            });

            allCategories.Add(new Category()
            {
                CategoryID = 3,
                Name = "Æbler"
            });

            allCategories.Add(new Category()
            {
                CategoryID = 4,
                Name = "Converse"
            });


        }

        public List<Category> GetAll()
        {
            return allCategories.OrderBy(x => x.Name).ToList();
        }

        public Category GetCategory(int categoryID)
        {
            return allCategories.Find(x => x.CategoryID == categoryID);
        }
    }
}