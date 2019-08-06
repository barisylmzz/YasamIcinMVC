using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YasamIcin.UI.MVC.Models;

namespace YasamIcin.UI.MVC.Areas.Admin.Controllers
{
    public class IcerikController : Controller
    {
        // GET: Admin/Icerik
        [CustomFilter.AdminFilter]
        public ActionResult Index()
        {
            return View(SayfaDetayText.GetAll());
        }

        [HttpPost]
        [CustomFilter.AdminFilter]
        public ActionResult Guncelle(SayfaDetay sayfaDetay)
        {
            SayfaDetayText.Update(sayfaDetay);
            return RedirectToAction("Index");
        }
        [CustomFilter.AdminFilter]
        public ActionResult _TextGunceller(string baslik)
        {
            return View(SayfaDetayText.Get(baslik));
        }

    }
}