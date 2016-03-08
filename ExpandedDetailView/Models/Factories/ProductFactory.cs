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
                StorageAmount = 1,
                Image = "placeholder.jpg",
                DateAdded = DateTime.Today
            });
        }

        public List<Product> GetAll()
        {
            return allProducts;
        }

        public List<Product> GetByCategoryID(int catID)
        {
            return allProducts.Where(x => x.CategoryID == catID).ToList();
        }

        public Product GetProduct(int productID)
        {
            return allProducts.Find(x => x.ProductID == productID);
        }
    }
}