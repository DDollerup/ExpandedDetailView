using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpandedDetailView.Models.BaseModels;

namespace ExpandedDetailView.Models.Factories
{
    public class ProductFactory
    {
        List<Product> allProducts = new List<Product>();

        public ProductFactory()
        {
            allProducts.Add(new Product()
            {
                ProductID = 1,
                CategoryID = 1,
                Name = "Nike Sko",
                Price = 99,
                SalePrice = 99,
                OnSale = false,
                StorageAmount = 300,
                Image = "placeholder.jpg",
                DateAdded = DateTime.Today
            });

            allProducts.Add(new Product()
            {
                ProductID = 2,
                CategoryID = 2,
                Name = "Lacoste Sko",
                Price = 16000,
                SalePrice = 8000,
                OnSale = true,
                StorageAmount = 0,
                Image = "placeholder.jpg",
                DateAdded = DateTime.Today
            });
            allProducts.Add(new Product()
            {
                ProductID = 3,
                CategoryID = 3,
                Name = "Converse Sko",
                Price = 16.50f,
                SalePrice = 0,
                OnSale = false,
                StorageAmount = 5,
                Image = "placeholder.jpg",
                DateAdded = DateTime.Today
            });
            allProducts.Add(new Product()
            {
                ProductID = 4,
                CategoryID = 2,
                Name = "Lacoste Sko 2",
                Price = 16.50f,
                SalePrice = 0,
                OnSale = false,
                StorageAmount = 16,
                Image = "placeholder.jpg",
                DateAdded = DateTime.Today
            });
        }

        public List<Product> GetAll()
        {
            return allProducts.OrderBy(x => x.Name).ToList();
        }

        public List<Product> GetByCategoryID(int catID)
        {
            return allProducts.Where(x => x.CategoryID == catID).ToList();
        }

        public Product GetProduct(int productID)
        {
            return allProducts.Find(x => x.ProductID == productID);
        }

        public List<Product> GetProductsByCategoryID(int categoryID)
        {
            return allProducts.Where(x => x.CategoryID == categoryID).ToList();
        }
    }
}