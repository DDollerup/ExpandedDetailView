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

        private HttpContextBase context;

        public ProductFactory(HttpContextBase context)
        {
            this.context = context;

            // If the session ProductList does not exist, we create one
            if (this.context.Session["ProductList"] == null)
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


                this.context.Session["ProductList"] = allProducts;
            }
            else
            {
                allProducts = this.context.Session["ProductList"] as List<Product>;
            }
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

        public void Add(Product newProduct)
        {
            newProduct.ProductID = allProducts.Count + 1;
            newProduct.DateAdded = DateTime.Now;
            // We add the product to our List of Products
            allProducts.Add(newProduct);
            // And then we update the current session, so that the browser will remember the new list
            this.context.Session["ProductList"] = allProducts;
        }

        public void Remove(Product productToDelete)
        {
            // We remove the product 'productToDelete' from the list
            allProducts.Remove(productToDelete);
            // And then we update the current session, so that the browser will remember the new list
            this.context.Session["ProductList"] = allProducts;
        }

        public void Update(Product productToUpdate)
        {
            Product oldProduct = GetProduct(productToUpdate.ProductID);
            oldProduct.Name = productToUpdate.Name;
            oldProduct.Price = productToUpdate.Price;

            if (productToUpdate.Image != null)
            {
                oldProduct.Image = productToUpdate.Image; 
            }
            oldProduct.OnSale = productToUpdate.OnSale;
            oldProduct.SalePrice = productToUpdate.SalePrice;
            oldProduct.StorageAmount = productToUpdate.StorageAmount;
            oldProduct.CategoryID = productToUpdate.CategoryID;

            this.context.Session["ProductList"] = allProducts;
        }
    }
}