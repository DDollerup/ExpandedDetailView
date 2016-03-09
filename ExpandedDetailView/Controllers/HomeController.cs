using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpandedDetailView.Models.Factories;
using ExpandedDetailView.Models.BaseModels;

namespace ExpandedDetailView.Controllers
{
    public class HomeController : Controller
    {
        ProductFactory productFac = new ProductFactory();
        CategoryFactory categoryFac = new CategoryFactory();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProducts(int id = 0)
        {
            if (id == 0)
            {
                List<Product> allProducts = productFac.GetAll();
                return View(allProducts); 
            }
            else
            {
                List<Product> allProductsByCategoryID = productFac.GetProductsByCategoryID(id);
                return View(allProductsByCategoryID);
            }
        }

        public ActionResult ShowProduct(int id)
        {
           
            Product productToGet = productFac.GetProduct(id);
            return View(productToGet);
        }

        public ActionResult ListCategories()
        {
            List<Category> allCategories = categoryFac.GetAll();
            return View(allCategories);
        }

        public ActionResult ListProductsByCategoryID(int id)
        {
            return View();
        }
    }
}