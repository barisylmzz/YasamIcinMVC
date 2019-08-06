using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YasamIcin.BLL.Abstract;
using YasamIcin.Model;
using YasamIcin.UI.MVC.CustomFilter;
using YasamIcin.UI.MVC.Models;

namespace YasamIcin.UI.MVC.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        IUyeService _uyeService;
        IMesajDetayService _mesajDetayService;
        IMesajService _mesajService;
        public MesajController(IUyeService uyeService, IMesajService mesajService, IMesajDetayService mesajDetayService)
        {
            _uyeService = uyeService;
            _mesajService= mesajService;
            _mesajDetayService = mesajDetayService;
     }
      
        [MesajYetkiFilter]
        public ActionResult Index(int UyeID)
        {
            Uye uye = Session["uye"] as Uye;
            ViewBag.Mesaj = _mesajService.getMesajbyUsersID(uye.ID, UyeID).MesajDetaylari.OrderByDescending(x=>x.GonderimTarihi);
            ViewBag.MesajID = _mesajService.getMesajbyUsersID(uye.ID, UyeID);
            return View();
        }

        [HttpPost]
        public ActionResult MesajGonder(MesajDetay mesajDetay)
        {
            Uye uye = Session["uye"] as Uye;
            _mesajDetayService.Insert(new MesajDetay {
                MesajID = mesajDetay.MesajID,
                MesajIcerik= mesajDetay.MesajIcerik,
                GondereciUyeID= uye.ID,
                OkunduMu=false,
                GonderimTarihi=DateTime.Now
            });
           
            return RedirectToAction("Gelenkutusu", "Mesaj");
        }

        public ActionResult LoginYonlendirme()
        {
            return View();
        }

        [UyeFilter]
        public ActionResult Gelenkutusu()
        {
            Uye uye = Session["uye"] as Uye;
            List<GelenkutuDTO> _gelenkutu = new List<GelenkutuDTO>();
            foreach (var item in _mesajService.getAllMesajbyUserID(uye.ID))
            {
               
                    _gelenkutu.Add(new GelenkutuDTO
                    {
                        ID = item.MesajID,
                        GonderenIsim = (_uyeService.Get((uye.ID == item.UyeID1) ? item.UyeID2 : item.UyeID1).Type) ? _uyeService.Get((uye.ID == item.UyeID1) ? item.UyeID2 : item.UyeID1).Hasta.Isim : _uyeService.Get((uye.ID == item.UyeID1) ? item.UyeID2 : item.UyeID1).Donor.Isim,
                        GonderilmeTarihi = item.MesajDetaylari.Last().GonderimTarihi,
                        Ulke = (_uyeService.Get(item.UyeID2).Type) ? _uyeService.Get(item.UyeID2).Hasta.Ulke.UlkeAdi : _uyeService.Get(item.UyeID2).Donor.Ulke.UlkeAdi
                        , UyeID = (uye.ID == item.UyeID1) ? item.UyeID2:item.UyeID1                       
                        
                    });
               
            }
            return View(_gelenkutu);
        }

    }
}