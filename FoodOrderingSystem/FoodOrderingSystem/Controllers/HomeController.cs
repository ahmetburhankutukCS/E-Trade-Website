using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrderingSystem.App_Classes;

namespace FoodOrderingSystem.Controllers
{
    using Models;
    using App_Classes;
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        Model1 ctx = new Model1();
        public ActionResult Index()
        {
            ViewBag.ActiveUser = HttpContext.Application["ActiveUser"];
            ViewBag.ToplamZiyaretci = HttpContext.Application["ToplamZiyaretci"];
            return View();
        }
        public ActionResult CookieAta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CookieAta(string CookieAdi, string CookiDegeri)
        {
            HttpCookie ck = new HttpCookie(CookieAdi);
            ck.Value = CookiDegeri;
            ck.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(ck);
            return View();

        }
        public ActionResult CookieOku()
        {
            string deger =  Request.Cookies["deneme"].Value;
            ViewBag.Cerez = deger;
            return View();
        }
        public ActionResult Sepetim()
        {
            List<Food> urunler = new List<Food>();
            if(Session["ActiveBasket"] != null)
            {
                sepet s = (sepet)Session["ActiveBasket"];
                urunler = s.Urunler;
            }
            return View(urunler);
        }

   
    }
}