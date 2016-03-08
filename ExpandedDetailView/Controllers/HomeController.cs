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

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProducts()
        {
            List<Product> allProducts = productFac.GetAll();

            return View(allProducts);
        }

        public ActionResult ShowProduct(int id)
        {
            Product productToGet = productFac.GetProduct(id);
            return View(productToGet);
        }

        public ActionResult ListCategories()
        {
            return View();
        }

        public ActionResult ListProductsByCategoryID(int id)
        {
            return View();
        }
    }
}