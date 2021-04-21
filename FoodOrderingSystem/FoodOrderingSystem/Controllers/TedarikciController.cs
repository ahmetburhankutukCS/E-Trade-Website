using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Controllers
{
    [Authorize]
    public class TedarikciController : Controller
    {
        // GET: Tedarikci
        Model1 ctx = new Model1();
        public ActionResult Index()
        {
            List<FoodCompany> data = ctx.FoodCompanies.ToList();
            return View(data);
        }
        public ActionResult AddCompany() 
        {
            ViewBag.aspnet_Users = ctx.aspnet_Users.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(FoodCompany c)
        {
            ctx.FoodCompanies.Add(c);
            ctx.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public string Sil(int id)
        {
            FoodCompany t = ctx.FoodCompanies.FirstOrDefault(x => x.CompanyID == id);
            ctx.FoodCompanies.Remove(t);
            try
            {
                ctx.SaveChanges();
                return "Successful";
            }
            catch (Exception)
            {
                return "hata";
            } 
        }
        [HttpPost]
        public string CompanyUpdate(int id, string ad)
        {
            FoodCompany c = ctx.FoodCompanies.FirstOrDefault(x => x.CompanyID == id);
            c.CompanyName = ad;
            ctx.SaveChanges();
            return "guncellendi";
        }
    }
}