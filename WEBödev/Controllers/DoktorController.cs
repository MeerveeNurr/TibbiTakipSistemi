using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBödev.Models;

namespace WEBödev.Controllers
{
    [Authorize(Roles = "Doktor")]
    public class DoktorController : Controller
    {
        private TıbbiTakipSistemEntities db = new TıbbiTakipSistemEntities();

        public ActionResult TumHastalar()
        {
            var tumHastalar = db.Kullanıcı.Where(k => k.Rol == "Hasta").ToList();
            return View(tumHastalar);
        }
    }
}
