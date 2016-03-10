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
        ProductFactory productFac;
        CategoryFactory categoryFac = new CategoryFactory();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            productFac = new ProductFactory(this.HttpContext);
            base.OnActionExecuting(filterContext);
        }

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

        public ActionResult Search()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchResult(string searchString)
        {
            // Get all products from productFac through the Method GetAll()
            List<Product> allProducts = productFac.GetAll();

            // Saving the search result in TempData["SearchResult"] which will persist through one POST
            // We then search the list for products which contains the users' searchString 
            TempData["SearchResult"] = allProducts.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();

            // We the redirect the result to the Search View.
            return RedirectToAction("Search");
        }

        public ActionResult AdvancedSearch()
        {
            List<Category> allCategories = categoryFac.GetAll();
            return View(allCategories);
        }

        [HttpPost]
        public ActionResult AdvancedSearchSubmit(int categoryID)
        {
            // After getting categoryID from user, we redirect the ID to the ListProduct action
            // where we reuse the listproducts code
            return RedirectToAction("ListProducts", new { id = categoryID });
        }


        public ActionResult AddProduct()
        {
            List<Category> allCategories = categoryFac.GetAll();
            return View(allCategories);
        }

        [HttpPost]
        public ActionResult AddProductSubmit(Product newProduct, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0 && file != null)
            {
                newProduct.Image = file.FileName;
                string path = HttpContext.Request.PhysicalApplicationPath;
                file.SaveAs(path + "/Content/Images/Products/" + file.FileName);
            }

            productFac.Add(newProduct);

            return RedirectToAction("ListProducts", new { id = 0 });
        }
    }
}