using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;
using WEBödev.Models;

namespace WEBödev.Controllers
{
    public class TümHastalarController : Controller
    {
        private TıbbiTakipSistemEntities db = new TıbbiTakipSistemEntities();

        public ActionResult Index()
        {
            // Veritabanından tüm hastaları çek
            List<Kullanıcı> tumHastalar = db.Kullanıcı.ToList();

            // Verileri view'e gönder
            return View(tumHastalar);
        }
    }
}
