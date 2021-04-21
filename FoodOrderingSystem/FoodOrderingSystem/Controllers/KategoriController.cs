using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        // GET: Kategori
        Model1 ctx = new Model1();
        public ActionResult Index()
        {
            List<Category> ktg = ctx.Categories.ToList();
            return View(ktg);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category k)
        {
            ctx.Categories.Add(k);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
       

        [HttpPost]
        public void  Sil(int id)
        {
            Category k = ctx.Categories.FirstOrDefault(x => x.CategoryID == id);
            ctx.Categories.Remove(k);
            ctx.SaveChanges();

        }
        [HttpPost]
        public string CategoryUpdate(int id, string ad)
        {
            Category c = ctx.Categories.FirstOrDefault(x => x.CategoryID == id);
            c.CategoryName = ad;
            ctx.SaveChanges();
            return "guncellendi";
        }
    }
}