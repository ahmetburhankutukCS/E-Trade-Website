using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOrderingSystem.Controllers
{
    using App_Classes;
    using System.Web.Security;

    [Authorize]

    public class UyeController : Controller
    {
        // GET: Uye
        [AllowAnonymous]
        public ActionResult GirisYap()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult GirisYap(Kullanici k, string Remember)
        {
            bool sonuc = Membership.ValidateUser(k.KullaniciAdi, k.Password);

            if (sonuc)
            {
                if (Remember == "on")
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, true);
                else
                    FormsAuthentication.RedirectFromLoginPage(k.KullaniciAdi, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "User Name or Password is Wrong!";
                return View();
            }
            
                

        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap");
        }
        [AllowAnonymous]
        public ActionResult IForgotMyPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult IForgotMyPassword(Kullanici k)
        {
            MembershipUser mu = Membership.GetUser(k.KullaniciAdi);
            if(mu.PasswordQuestion == k.SecretQuestion)
            {
                string pwd = mu.ResetPassword(k.SecretAnswer);
                mu.ChangePassword(pwd, k.Password);
                return RedirectToAction("GirisYap");

            }
            else
            {
                ViewBag.Mesaj = "Typed Information Are Wrong!";
                return View();
            }
        }
    }
}