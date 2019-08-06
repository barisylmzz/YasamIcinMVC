using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YasamIcin.BLL.Abstract;
using YasamIcin.Model;
using YasamIcin.UI.MVC.CustomFilter;
using YasamIcin.UI.MVC.Models;
using YasamIcin.UI.MVC.Tools;

namespace YasamIcin.UI.MVC.Controllers
{
    public class HastaController : Controller
    {
        IUyeService _uyeService;
        IHastaService _hastaService;
        IGuvenlikSoruService _guvenlikSoruService;
        IUlkeService _ulkeService;
        ISehirService _sehirService;
        ICinsiyetService _cinsiyetService;
        IKanGrubuService _kanGrubuService;
        IBagisTuruService _bagisTuruService;
        static HttpPostedFileBase  _file;
        public HastaController(IUyeService uyeService, IHastaService hastaService, IGuvenlikSoruService guvenlikSoruService, IUlkeService ulkeService, ISehirService sehirService, ICinsiyetService cinsiyetService, IKanGrubuService kanGrubuService, IBagisTuruService bagisTuruService)
        {
            _uyeService = uyeService;
            _hastaService = hastaService;
            _guvenlikSoruService = guvenlikSoruService;
            _ulkeService = ulkeService;
            _sehirService = sehirService;
            _cinsiyetService = cinsiyetService;
            _kanGrubuService = kanGrubuService;
            _bagisTuruService = bagisTuruService;
        }
        // GET: Hasta
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Uye uye)
        {
            Uye tempuye = _uyeService.Login(uye);
            if (tempuye != null && tempuye.Hasta != null)
            {
                Session["uye"] = tempuye;
                Session["hasta"] = tempuye.Hasta;
                return RedirectToAction("Profil", "Hasta");
            }
            return RedirectToAction("Index", "Hasta");
        }
        [HastaFilter]
        public ActionResult Profil()
        {
            Hasta hasta = Session["hasta"] as Hasta;

            return View(hasta);
        }

        [HastaFilter]
        public ActionResult ProfilGuncelle()
        {
            Hasta hasta = Session["hasta"] as Hasta;
            Uye uye = Session["uye"] as Uye;
            HastaUyeGuncelleDTO _hastauye = new HastaUyeGuncelleDTO
            {
                Uye = uye,
                Hasta = hasta
            };
            DateTime DogumTarihi = hasta.DogumTarihi;
            List<SelectListItem> Sehirler = new List<SelectListItem>();
            List<SelectListItem> Ulkeler = new List<SelectListItem>();
            List<SelectListItem> Cinsiyetler = new List<SelectListItem>();
            List<SelectListItem> KanGruplari = new List<SelectListItem>();
            List<SelectListItem> BagisTurleri = new List<SelectListItem>();
            foreach (var item in _ulkeService.GetAll())
            {
                Ulkeler.Add(new SelectListItem
                {
                    Text = item.UlkeAdi,
                    Value = item.UlkeID.ToString()

                });
            }
            foreach (var item in _sehirService.GetAll())
            {
                Sehirler.Add(new SelectListItem
                {
                    Text = item.SehirAdi,
                    Value = item.SehirID.ToString()

                });
            }
            foreach (var item in _cinsiyetService.GetAll())
            {
                Cinsiyetler.Add(new SelectListItem
                {
                    Text = item.CinsiyetTipi,
                    Value = item.CinsiyetID.ToString()

                });
            }
            foreach (var item in _kanGrubuService.GetAll())
            {
                KanGruplari.Add(new SelectListItem
                {
                    Text = item.KanGrubuTipi,
                    Value = item.KanGrubuID.ToString()
                    
                    

                });
            }
            foreach (var item in _bagisTuruService.GetAll())
            {
                BagisTurleri.Add(new SelectListItem
                {
                    Text = item.BagisTipi,
                    Value = item.BagisTuruID.ToString()

                });
            }
            //DateTime test = Convert.ToDateTime(hasta.DogumTarihi.Year + "-" + hasta.DogumTarihi.Month + "-" + hasta.DogumTarihi.Day);
            ViewBag.DT = DogumTarihi;
            ViewBag.Cinsiyetler = Cinsiyetler;
            ViewBag.BagisTurleri = BagisTurleri;
            ViewBag.KanGruplari = KanGruplari;
            ViewBag.Ulkeler = Ulkeler;
            ViewBag.Sehirler = Sehirler;
            return View(_hastauye);
        }

        
        public ActionResult SifreDegistir()
        {
            Uye uye = Session["uye"] as Uye;
            return View(uye);
        }

        [HttpPost]
        public ActionResult SifreDegistirPost(Uye uye)
        {           
            Uye tempuye = _uyeService.GetUyeByUserName(uye.KullaniciAdi);
            if (tempuye != null && tempuye.GuvenlikSoruCevabi==uye.GuvenlikSoruCevabi)
            {
                Session["uye"] = tempuye;
                tempuye.KullaniciAdi = uye.KullaniciAdi;
                tempuye.Sifre = uye.Sifre;
                _uyeService.Update(tempuye);
                return RedirectToAction("Index", "Hasta");
            }
            return RedirectToAction("SifreDegistir","Hasta");
        }


        [HttpPost]
        public ActionResult ProfilGuncellePost(HastaUyeGuncelleDTO _hastauye)
        {

            Uye uye = _uyeService.Get(_hastauye.Uye.ID);
            uye.KullaniciAdi = _hastauye.Uye.KullaniciAdi;
            uye.Sifre = _hastauye.Uye.Sifre;
            //uye.GuvenlikSorusuID = _hastauye.Uye.GuvenlikSorusuID;
            //uye.GuvenlikSoruCevabi = _hastauye.Uye.GuvenlikSoruCevabi;
            //uye.Type = _hastauye.Uye.Type;
            //uye.OnayliMi = _hastauye.Uye.OnayliMi;
            //uye.IsDeleted = _hastauye.Uye.IsDeleted;
            //uye.OlusturulmaTarihi = _hastauye.Uye.OlusturulmaTarihi;
            _uyeService.Update(uye);

            Hasta hasta = _hastaService.Get(_hastauye.Uye.ID);
            hasta.Adres = _hastauye.Hasta.Adres;
            hasta.BagisTarihi = _hastauye.Hasta.BagisTarihi;
            hasta.BagisTuruID = _hastauye.Hasta.BagisTuruID;
            hasta.CinsiyetID = _hastauye.Hasta.CinsiyetID;
            hasta.DogumTarihi = _hastauye.Hasta.DogumTarihi;
            hasta.Email = _hastauye.Hasta.Email;
            hasta.Fotograf = _hastauye.Hasta.Fotograf;
            hasta.GSM = _hastauye.Hasta.GSM;
            hasta.Isim = _hastauye.Hasta.Isim;
            hasta.KanGrubuID = _hastauye.Hasta.KanGrubuID;
            hasta.SehirID = _hastauye.Hasta.SehirID;
            hasta.Soyisim = _hastauye.Hasta.Soyisim;
            hasta.TCKimlikNo = _hastauye.Hasta.TCKimlikNo;
            hasta.UlkeID = _hastauye.Hasta.UlkeID;
          

            _hastaService.Update(hasta);
            Session["uye"] = null;
            Session["hasta"] = null;
            Session["donor"] = null;
            return RedirectToAction("Index", "Hasta");
        }

       
        public ActionResult HastaKayit()
        {

            return View();
        }
        [CustomFilter.HastaFilter]
        public ActionResult Adim1()
        {
            Hasta hasta = Session["hasta"] as Hasta;
            List<SelectListItem> Sehirler = new List<SelectListItem>();
            List<SelectListItem> Ulkeler = new List<SelectListItem>();
            List<SelectListItem> Cinsiyetler = new List<SelectListItem>();
            List<SelectListItem> KanGruplari = new List<SelectListItem>();
            List<SelectListItem> BagisTurleri = new List<SelectListItem>();
            foreach (var item in _ulkeService.GetAll())
            {
                Ulkeler.Add(new SelectListItem
                {
                    Text = item.UlkeAdi,
                    Value = item.UlkeID.ToString()

                });
            }
            foreach (var item in _sehirService.GetAll())
            {
                Sehirler.Add(new SelectListItem
                {
                    Text = item.SehirAdi,
                    Value = item.SehirID.ToString()

                });
            }
            foreach (var item in _cinsiyetService.GetAll())
            {
                Cinsiyetler.Add(new SelectListItem
                {
                    Text = item.CinsiyetTipi,
                    Value = item.CinsiyetID.ToString()

                });
            }
            foreach (var item in _kanGrubuService.GetAll())
            {
                KanGruplari.Add(new SelectListItem
                {
                    Text = item.KanGrubuTipi,
                    Value = item.KanGrubuID.ToString()

                });
            }
            foreach (var item in _bagisTuruService.GetAll())
            {
                BagisTurleri.Add(new SelectListItem
                {
                    Text = item.BagisTipi,
                    Value = item.BagisTuruID.ToString()

                });
            }
            ViewBag.Cinsiyetler = Cinsiyetler;
            ViewBag.BagisTurleri = BagisTurleri;
            ViewBag.KanGruplari = KanGruplari;
            ViewBag.Ulkeler = Ulkeler;
            ViewBag.Sehirler = Sehirler;
            return View(hasta);
        }
        [CustomFilter.HastaFilter]
        public ActionResult Adim2()
        {
            List<SelectListItem> GuvenlikSorulari = new List<SelectListItem>();
            foreach (var item in _guvenlikSoruService.GetAll())
            {
                GuvenlikSorulari.Add(new SelectListItem
                {
                    Text = item.GuvenlikSorusu,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.GuvenlikSorulari = GuvenlikSorulari;
            return View();
        }
        [CustomFilter.HastaFilter]
        [HttpPost]
        public ActionResult SonAdim(Uye uye)
        {
           
            Hasta temphasta = Session["hasta"] as Hasta;
            Uye tempuye = uye;
            tempuye.Type = true;
            _uyeService.Insert(tempuye);
            temphasta.UyeID = uye.ID;
            _hastaService.Insert(temphasta);
            Session["uye"] = null;
            Session["hasta"] = null;
            Session["donor"] = null;
            Session["donoronay"] = null;
            return RedirectToAction("Index", "Hasta");
        }

        [HttpPost]
        public ActionResult HastaKayitPOST(string isim, string soyisim)
        {
            Session["hasta"] = new Hasta { Isim = isim, Soyisim = soyisim };
            return RedirectToAction("Adim1", "Hasta");
        }

        [HttpPost]
        public ActionResult HastaKayitPOST2(Hasta hasta, HttpPostedFileBase file)
        {
            Hasta temphasta = Session["hasta"] as Hasta;
            _file = file;
            hasta.Isim = temphasta.Isim;
            hasta.Soyisim = temphasta.Soyisim;
            Session["hasta"] = hasta;
        
            return RedirectToAction("Adim2", "Hasta");
        }
        //[HttpPost]
        //public ActionResult LoginHasta(Uye uye)
        //{
        //    var gelenHasta = _uyeService.GetUyeByLogin(uye.KullaniciAdi, uye.Sifre);
        //    if (gelenHasta != null)
        //    {

        //        Session["hasta"] = gelenHasta;
        //        return RedirectToAction("Login", "Hasta");
        //    }


        //    ViewBag.Error = "Hasta Bulunamadı";
        //    return View();
        //}
    }
}