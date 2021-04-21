using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Controllers
{
    using App_Classes;
    using System.Configuration;
    using System.Drawing;
    using System.IO;
    using System.Web;

    [Authorize]
    public class UrunController : Controller
    {
        // GET: Urun
        Model1 ctx = new Model1();
        public ActionResult Index()
        {
            List<Food> food = ctx.Foods.ToList();
            return View(food);
        }
        public ActionResult AddProduct()
        {
            ViewBag.Category = ctx.Categories.ToList();
            ViewBag.FoodCompany = ctx.FoodCompanies.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Food u, HttpPostedFileBase fileUpload)
        {
            int resimId = -1;
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                int width = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaWidth"].ToString());
                int height = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaHeight"].ToString());

                string name = "/Content/UrunResim/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                Bitmap bm = new Bitmap(img, width,height);
                bm.Save(Server.MapPath(name));

                Resim rsm = new Resim();
                rsm.OrtaYol = name;
                ctx.Resims.Add(rsm);
                ctx.SaveChanges();
                if(rsm.Id != 0)
                    resimId = rsm.Id;
            }
            if (resimId != -1)
                u.ResimID = resimId;

            ctx.Foods.Add(u);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveProduct(int id)
        {
            Food u = ctx.Foods.FirstOrDefault(x => x.FoodID == id);
            return View(u);
        }
        [HttpPost]
        public ActionResult RemoveProduct(Food u)
        {
            Food urn = ctx.Foods.FirstOrDefault(x=>x.FoodID == u.FoodID);
            ctx.Foods.Remove(urn);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunDetay()
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            string adi =Request.QueryString["adi"].ToString();
            Food u = ctx.Foods.FirstOrDefault(x => x.FoodID == id);
            return View(u);
        }
        [HttpPost]
        public void sepeteAt(int id)
        {
            sepet s;
            if (Session["ActiveBasket"] == null)
            {
                s = new sepet();
               
            }
            else
            {
               s = (sepet)Session["ActiveBasket"];
            }
            Food u = ctx.Foods.FirstOrDefault(x => x.FoodID == id);
            s.Urunler.Add(u);
            Session["ActiveBasket"] = s;
        }
        public ActionResult Slider()
        {
            return View();
        }

        
    }
}