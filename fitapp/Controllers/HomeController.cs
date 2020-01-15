using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using fitapp.DAL;
using fitapp.Models;
using fitapp.ViewModels;
using PagedList;

namespace fitapp.Controllers
{
    public class HomeController : Controller
    {
        private FitappDbContext db = new FitappDbContext();

        //INDEX - zawartosc do usuniecia
        public ActionResult Index()
        {
            var products = db.Products.ToList();

            return View(products);
        }

        // SEARCH
        public ActionResult Search(string searchQuery)
        {
            var products = db.Products.Where(p => p.Name.ToLower().StartsWith(searchQuery.ToLower()) || searchQuery == null).ToList();
           
            return View(products);
        }

        // PRODUCT SUGGESTIONS
        public ActionResult ProductsSuggestions(string term)
        {
            var products = this.db.Products.Where(p => p.Name.ToLower().StartsWith(term.ToLower())).Take(5).Select(p => new { label = p.Name });

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        // SZCZEGÓŁY PRODUKTU
        //public ActionResult Details(int id)
        //{
        //    var product = db.Products.Find(id);

        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(product);
        //}
        
        // CAŁA BAZA PRODUKTÓW
        public ActionResult ProductsList(int? page = 1)
        {
            var products = db.Products.ToList();

            int pageNumber = (page ?? 1);
            int productsOnPage = 10;
            
            return View(products.ToPagedList(pageNumber, productsOnPage));
        }

        // STATIC CONTENT
        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
    }
}