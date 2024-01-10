using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WEBödev.Models;

namespace WEBödev.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        TıbbiTakipSistemEntities db = new TıbbiTakipSistemEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public ActionResult Login(Models.Kullanıcı p)
        {
            var bilgiler = db.Kullanıcı.FirstOrDefault(x => x.KullanıcıTc == p.KullanıcıTc && x.Şifre == p.Şifre);
            if(bilgiler != null)
            {
                

                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıTc, false);
                Session["kimlikno"]=bilgiler.KullanıcıTc.ToString();
                Session["adSoyad"]=bilgiler.AdSoyad.ToString();
                Session["KullanıcıTc"] = bilgiler.KullanıcıTc.ToString();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.hata = "Tc kimlik No veya Şifre Hatalı!";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.Kullanıcı data)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı kaydetme işlemi (veritabanına ekleme)
                db.Kullanıcı.Add(data);
                db.SaveChanges();

                // Kullanıcı kaydedildikten sonra oturum değişkenlerini ayarla
                FormsAuthentication.SetAuthCookie(data.KullanıcıTc, false);
                Session["kimlikno"] = data.KullanıcıTc.ToString();
                Session["adSoyad"] = data.AdSoyad.ToString();
                Session["KullanıcıTc"] = data.KullanıcıTc.ToString();

                // Ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }

            // ModelState geçerli değilse, hataları göster ve kayıt sayfasını tekrar göster
            return View(data);
        }
    }
}