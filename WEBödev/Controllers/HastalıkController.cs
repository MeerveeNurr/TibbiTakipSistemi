using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;
using WEBödev.Models;

namespace WEBödev.Controllers
{
    [Authorize(Roles = "Hasta")]
    public class HastalıkController : Controller
    {
        // GET: Urun
        TıbbiTakipSistemEntities db = new TıbbiTakipSistemEntities();

        public ActionResult Index(String ara)
        {
            var list = db.Hastalık.ToList();
            if (!string.IsNullOrEmpty(ara))
            {
                list = list.Where(x => x.HastalıkAdı.Contains(ara) || x.Açıklama.Contains(ara)).ToList();
            }
            return View(list);
        }

        public ActionResult Ekle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Hastalık data)
        {
            try
            {
                // Gelen verinin null olup olmadığını kontrol et
                if (data == null)
                {
                    // Hata işlemleri veya kullanıcıya bilgi verme işlemleri yapılabilir
                    return HttpNotFound(); // Örnek bir hata durumu, isteğe bağlı olarak değiştirilebilir
                }

                // Veritabanına hastalık ekleyin
                db.Hastalık.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Hata durumunda loglama veya kullanıcıya hata mesajı gösterme işlemleri yapılabilir
                return View("Error");
            }
        }

        public ActionResult Sil(int id)
        {
            var Hastalık = db.Hastalık.Where(x => x.Id == id).FirstOrDefault();
            db.Hastalık.Remove(Hastalık);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Güncelle(int id)
        {
            // Veritabanından belirli bir ID'ye sahip hastalık kaydını çek
            var hastalık = db.Hastalık.FirstOrDefault(x => x.Id == id);

            // Eğer hastalık kaydı bulunamazsa, hata sayfasına yönlendir
            if (hastalık == null)
            {
                return HttpNotFound();
            }

            // Veritabanından çekilen hastalık modelini view'e gönder
            return View(hastalık);
        }

        [HttpPost]

        public ActionResult Güncelle(Hastalık data)
        {
            try
            {
                // Gelen verinin null olup olmadığını kontrol et
                if (data == null)
                {
                    // Hata işlemleri veya kullanıcıya bilgi verme işlemleri yapılabilir
                    return HttpNotFound();
                }

                // Güncellenecek kaydı veritabanından bul
                var guncelle = db.Hastalık.FirstOrDefault(x => x.Id == data.Id);

                // Eğer kayıt bulunamazsa hata işlemleri yapabilirsiniz
                if (guncelle == null)
                {
                    // Hata işlemleri veya kullanıcıya bilgi verme işlemleri yapılabilir
                    return HttpNotFound();
                }

                // Güncelleme işlemleri
                guncelle.KullanıcıTc = data.KullanıcıTc;
                guncelle.HastalıkAdı = data.HastalıkAdı;
                guncelle.Açıklama = data.Açıklama;
                guncelle.Belirtiler = data.Belirtiler;
                guncelle.Bölümü = data.Bölümü;
                guncelle.RiskFaktörü = data.RiskFaktörü;
                guncelle.Teşhis = data.Teşhis;
                guncelle.İstenilenTestler = data.İstenilenTestler;
                guncelle.Verilenİlaç = data.Verilenİlaç;

                // Veritabanına değişiklikleri kaydet
                db.SaveChanges();

                // Index action'ına yönlendir
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // Hata durumunda loglama veya kullanıcıya hata mesajı gösterme işlemleri yapılabilir
                return View("Error");
            }
        }

    }
}