using FoodOrderingSystem.App_Classes;
using FoodOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodOrderingSystem.Controllers
{
    [Authorize]
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        Model1 ctx = new Model1();
        public ActionResult Index()
        {
            MembershipUserCollection users =  Membership.GetAllUsers();            
            return View(users);
        }
        [AllowAnonymous]
        public ActionResult Ekle()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Ekle(Kullanici k)
        {

            MembershipCreateStatus durum;

            Membership.CreateUser(k.KullaniciAdi, k.Password,k.Email, k.SecretQuestion, k.SecretAnswer,true,out durum);
            string mesaj = "";
            switch (durum)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    mesaj += "Invalid Membership Name!";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    mesaj+= "Invalid Password!";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    mesaj += "Invalid Secret Quetion!";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    mesaj += "Invalid Secret Answer!";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    mesaj += "Invalid E-Mail Address'";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    mesaj += "Taken Membership Name!";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    mesaj += "Taken E-Mail has been typed.";
                    break;
                case MembershipCreateStatus.UserRejected:
                    mesaj += "Membership ban Error!";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    mesaj += "Invalid Membership Key Error!";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    mesaj += "Taken Membership key Error!";
                    break;
                case MembershipCreateStatus.ProviderError:
                    mesaj += "Member Manager Provider Error!";
                    break;
                default:
                    break;

            }
            ViewBag.Mesaj = mesaj;
            if(durum == MembershipCreateStatus.Success)
                return RedirectToAction("Index");
            else
            
                return View();
        }

        [Authorize(Roles ="Admin")]
        public ActionResult RolAta()
        {
            ViewBag.Roller = Roles.GetAllRoles().ToList();
            ViewBag.Kullanicilar = Membership.GetAllUsers();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RolAta(string KullaniciAdi,string RolAdi)
        {
            Roles.AddUserToRole(KullaniciAdi, RolAdi);
            return RedirectToAction("Index");
        }
   

        [HttpPost]
        public string UyeRolleri(string kullaniciAdi)
        {
            List<string> roller = Roles.GetRolesForUser(kullaniciAdi).ToList();
            string rol = "";
            foreach (string r in roller)
            {
                rol += r + "-";

            }
            rol = rol.Remove(rol.Length - 1, 1);
            return rol;
        }

        [HttpPost]
        public void Sil(string id)
        {
            aspnet_Membership k = ctx.aspnet_Membership.FirstOrDefault(x => x.UserId.ToString().Equals(id));
            ctx.aspnet_Membership.Remove(k);
            ctx.SaveChanges();
            
        }
    }
}