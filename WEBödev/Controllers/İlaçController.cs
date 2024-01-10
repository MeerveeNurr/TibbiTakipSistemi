using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBödev.Models;

namespace WEBödev.Controllers
{
    [Authorize(Roles = "Hasta")]
    public class İlaçController : Controller
    {

        // GET: İlaç
        TıbbiTakipSistemEntities db = new TıbbiTakipSistemEntities();


        public ActionResult Index(string ara)
        {
            var list = db.İlaç.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.İlaçAdı.Contains(ara) || x.Dozaj.Contains(ara)).ToList();
            }
            return View(list);
            //return View(db.İlaç.Where(x => x.Id == id).ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(İlaç data)
        {
            db.İlaç.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var İlaç = db.İlaç.Where(x => x.Id == id).FirstOrDefault();
            db.İlaç.Remove(İlaç);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Güncelle(int id)
        {
            var ilaç = db.İlaç.FirstOrDefault(x => x.Id == id);
            if (ilaç == null)
            {
                return HttpNotFound();
            }
            return View(ilaç);
        }
        [HttpPost]
        public ActionResult Güncelle(İlaç data)
        {


                // Hata yoksa, güncelleme işlemini yap
                var guncelle = db.İlaç.Where(x => x.Id == data.Id).FirstOrDefault();
                if (guncelle != null)
                {
                    guncelle.KullanıcıTc = data.KullanıcıTc;
                    guncelle.İlaçNo = data.İlaçNo;
                    guncelle.İlaçAdı = data.İlaçAdı;
                    guncelle.SonKullanmaTarihi = data.SonKullanmaTarihi;
                    guncelle.Dozaj = data.Dozaj;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }


        }
    }
