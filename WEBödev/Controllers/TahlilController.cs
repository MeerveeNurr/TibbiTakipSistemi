using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBödev.Models;

namespace WEBödev.Controllers
{
    [Authorize(Roles = "Hasta")]
    public class TahlilController : Controller
    {
        // GET: Tahlil
        TıbbiTakipSistemEntities db = new TıbbiTakipSistemEntities();

     
        public ActionResult Index(String ara)
        {
            var list = db.Tahlil.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.TestAdı.Contains(ara) || x.Açıklama.Contains(ara)).ToList();
            }
            return View(list);
            //return View(db.Tahlil.Where(x=>x.Id==Id).ToList());
        }
       
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Ekle(Tahlil data)
        {
            db.Tahlil.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult Sil(int id)
        {
            var Tahlil = db.Tahlil.Where(x => x.Id == id).FirstOrDefault();
            db.Tahlil.Remove(Tahlil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Güncelle(int id)
        {
            // Veritabanından belirli bir ID'ye sahip tahlil kaydını çek
            var tahlil = db.Tahlil.FirstOrDefault(x => x.Id == id);

            // Eğer tahlil kaydı bulunamazsa, hata sayfasına yönlendir
            if (tahlil == null)
            {
                return HttpNotFound();
            }

            // Veritabanından çekilen tahlil modelini view'e gönder
            return View(tahlil);
        }
        [HttpPost]
        public ActionResult Güncelle(Tahlil data)
        {
            // Gelen verinin null olup olmadığını kontrol et
            if (data == null)
            {
                // Hata işlemleri veya kullanıcıya bilgi verme işlemleri yapılabilir
                return HttpNotFound(); // Örnek bir hata durumu, isteğe bağlı olarak değiştirilebilir
            }

            // Güncellenecek kaydı veritabanından bul
            var guncelle = db.Tahlil.FirstOrDefault(x => x.Id == data.Id);

            // Eğer kayıt bulunamazsa hata işlemleri yapabilirsiniz
            if (guncelle == null)
            {
                // Hata işlemleri veya kullanıcıya bilgi verme işlemleri yapılabilir
                return HttpNotFound(); // Örnek bir hata durumu, isteğe bağlı olarak değiştirilebilir
            }

            // Gerekli alanları güncelle
            guncelle.KullanıcıTc = data.KullanıcıTc;
            guncelle.TestNo = data.TestNo;
            guncelle.TestAdı = data.TestAdı;
            guncelle.TestTarihi = data.TestTarihi;
            guncelle.SorumluDoktor = data.SorumluDoktor;
            guncelle.Açıklama = data.Açıklama;

            // Değişiklikleri veritabanına kaydet
            db.SaveChanges();

            // İşlem başarılı olduğunda Index sayfasına yönlendir
            return RedirectToAction("Index");
        }

    }
}
     