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
    public class DonorController : Controller
    {
        IUyeService _uyeService;
        IDonorService _donorService;
        IGuvenlikSoruService _guvenlikSoruService;
        IUlkeService _ulkeService;
        ISehirService _sehirService;
        ICinsiyetService _cinsiyetService;
        IKanGrubuService _kanGrubuService;
        IBagisTuruService _bagisTuruService;
        IDonorOnayService _donorOnayService;

        public DonorController(IUyeService uyeService, IDonorService donorService, IGuvenlikSoruService guvenlikSoruService, IUlkeService ulkeService, ISehirService sehirService, ICinsiyetService cinsiyetService, IKanGrubuService kanGrubuService, IBagisTuruService bagisTuruService,IDonorOnayService donorOnayService)
        {
            _uyeService = uyeService;
            _donorService = donorService;
            _guvenlikSoruService = guvenlikSoruService;
            _ulkeService = ulkeService;
            _sehirService = sehirService;
            _cinsiyetService = cinsiyetService;
            _kanGrubuService = kanGrubuService;
            _bagisTuruService = bagisTuruService;
            _donorOnayService = donorOnayService;
        }

       
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Uye uye)
        {
            Uye tempuye = _uyeService.Login(uye);
            if (tempuye != null && tempuye.Donor != null)
            {
                Session["uye"] = tempuye;
                Session["donor"] = tempuye.Donor;
                return RedirectToAction("Profil", "Donor");
            }
            return RedirectToAction("Index", "Donor");
        }

        //[DonorFilter]
        
        public ActionResult Profil()
        {
            Donor donor = Session["donor"] as Donor;
            DonorOnay donorOnay = Session["donoronay"] as DonorOnay;
            return View(donor);
        }

        
        public ActionResult ProfilGuncelle()
        {
            Donor donor = Session["donor"] as Donor;
            DonorOnay donorOnay = Session["donoronay"] as DonorOnay;
            Uye uye = Session["uye"] as Uye;
            DonorUyeGuncelleDTO _donoruye = new DonorUyeGuncelleDTO
            {
                Uye = uye,
                Donor = donor,
                DonorOnay=donorOnay
            };
            //DateTime DogumTarihi = donor.DogumTarihi;
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
            //ViewBag.DT = DogumTarihi;
            ViewBag.Cinsiyetler = Cinsiyetler;
            ViewBag.BagisTurleri = BagisTurleri;
            ViewBag.KanGruplari = KanGruplari;
            ViewBag.Ulkeler = Ulkeler;
            ViewBag.Sehirler = Sehirler;
            return View(_donoruye);
        }

        [HttpPost]
        public ActionResult ProfilGuncellePost(DonorUyeGuncelleDTO _donoruye)
        {

            Uye uye = _uyeService.Get(_donoruye.Uye.ID);
            uye.KullaniciAdi = _donoruye.Uye.KullaniciAdi;
            uye.Sifre = _donoruye.Uye.Sifre;
            //uye.GuvenlikSorusuID = _hastauye.Uye.GuvenlikSorusuID;
            //uye.GuvenlikSoruCevabi = _hastauye.Uye.GuvenlikSoruCevabi;
            //uye.Type = _hastauye.Uye.Type;
            //uye.OnayliMi = _hastauye.Uye.OnayliMi;
            //uye.IsDeleted = _hastauye.Uye.IsDeleted;
            //uye.OlusturulmaTarihi = _hastauye.Uye.OlusturulmaTarihi;
            _uyeService.Update(uye);

            Donor donor = _donorService.Get(_donoruye.Uye.ID);
            donor.Adres = _donoruye.Donor.Adres;
            donor.BagisTarihi = _donoruye.Donor.BagisTarihi;
            donor.BagisTuruID = _donoruye.Donor.BagisTuruID;
            donor.CinsiyetID = _donoruye.Donor.CinsiyetID;
            donor.DogumTarihi = _donoruye.Donor.DogumTarihi;
            donor.Email = _donoruye.Donor.Email;
            donor.Fotograf = _donoruye.Donor.Fotograf;
            donor.GSM = _donoruye.Donor.GSM;
            donor.Isim = _donoruye.Donor.Isim;
            donor.KanGrubuID = _donoruye.Donor.KanGrubuID;
            donor.SehirID = _donoruye.Donor.SehirID;
            donor.Soyisim = _donoruye.Donor.Soyisim;
            donor.TCKimlikNo = _donoruye.Donor.TCKimlikNo;
            donor.UlkeID = _donoruye.Donor.UlkeID;
            _donorService.Update(donor);

            DonorOnay donorOnay = _donorOnayService.Get(_donoruye.Uye.ID);
            donorOnay.BagisTuru = _donoruye.DonorOnay.BagisTuru;
            donorOnay.Cinsiyet = _donoruye.DonorOnay.Cinsiyet;
            donorOnay.Email = _donoruye.DonorOnay.Email;
            donorOnay.GSM = _donoruye.DonorOnay.GSM;
            donorOnay.Sehir = _donoruye.DonorOnay.Sehir;
            donorOnay.Soyisim = _donoruye.DonorOnay.Soyisim;
            donorOnay.Isim = _donoruye.DonorOnay.Isim;
            donorOnay.KanGrubu = _donoruye.DonorOnay.KanGrubu;
            donorOnay.Ulke = _donoruye.DonorOnay.Ulke;
            _donorOnayService.Update(donorOnay);


            Session["uye"] = null;
            Session["hasta"] = null;
            Session["donor"] = null;
            Session["donoronay"] = null;
            return RedirectToAction("Index", "Donor");
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
            if (tempuye != null && tempuye.GuvenlikSoruCevabi == uye.GuvenlikSoruCevabi)
            {
                Session["uye"] = tempuye;
                tempuye.KullaniciAdi = uye.KullaniciAdi;
                tempuye.Sifre = uye.Sifre;
                _uyeService.Update(tempuye);
                return RedirectToAction("Index", "Donor");
            }
            return RedirectToAction("SifreDegistir", "Donor");
        }


        public ActionResult DonorKayit()
        {

            return View();
        }
        [CustomFilter.DonorFilter]
        public ActionResult Adim1()
        {
            Donor donor = Session["donor"] as Donor;
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
            return View(donor);
        }
        [CustomFilter.DonorFilter]
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
        [CustomFilter.DonorFilter] 
        public ActionResult Adim3()
        {
            List<SelectListItem> GuvenlikSorulari = new List<SelectListItem>();
            foreach (var item in _guvenlikSoruService.GetAll())
            {
                GuvenlikSorulari.Add(new SelectListItem
                {
                    Text = item.GuvenlikSorusu,
                    Value = item.ID.ToString()
                });
                //0545 436 0480
            }
            ViewBag.GuvenlikSorulari = GuvenlikSorulari;
            return View();
        }
        [HttpPost]
        public ActionResult DonorKayitPOST3(DonorOnay donorOnay)
        {
            Session["donoronay"] = donorOnay;
            return RedirectToAction("Adim3", "Donor");
        }
        [HttpPost]
        public ActionResult DonorKayitPOST4(Uye uye)
        {

            Donor tempdonor = Session["donor"] as Donor;
            Uye tempuye = uye;
            _uyeService.Insert(tempuye);
            tempdonor.UyeID = uye.ID;
            _donorService.Insert(tempdonor);
            DonorOnay tempdonorOnay = Session["donoronay"] as DonorOnay;
            tempdonorOnay.DonorID = uye.ID;
            _donorOnayService.Insert(tempdonorOnay);
            return RedirectToAction("Index", "Donor");
        }

        [HttpPost]
        public ActionResult DonorKayitPOST(string isim, string soyisim)
        {
            Session["donor"] = new Donor { Isim = isim, Soyisim = soyisim };
            return RedirectToAction("Adim1", "Donor");
        }
        static HttpPostedFileBase _file;
        [HttpPost]
        public ActionResult DonorKayitPOST2(Donor donor, HttpPostedFileBase file)
        {
            Donor tempdonor = Session["donor"] as Donor;
            _file = file;
            donor.Isim = tempdonor.Isim;
            donor.Soyisim =tempdonor.Soyisim;
            Session["donor"] = donor;
            return RedirectToAction("Adim2", "Donor");
        }
        [HttpPost]
        public ActionResult LoginDonor(Uye uye)
        {

            var gelenDonor = _uyeService.GetUyeByLogin(uye.KullaniciAdi, uye.Sifre);
            if (gelenDonor != null)
            {
                Session["donor"] = gelenDonor;
                return RedirectToAction("Login", "Donor");
            }


            ViewBag.Error = "Donor Bulunamadı";
            return View();
        }


    }
}