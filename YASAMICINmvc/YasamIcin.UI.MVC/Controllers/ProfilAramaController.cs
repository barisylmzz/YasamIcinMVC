using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YasamIcin.BLL.Abstract;
using YasamIcin.Model;
using YasamIcin.UI.MVC.Models;

namespace YasamIcin.UI.MVC.Controllers
{
    public class ProfilAramaController : Controller
    {
        IUyeService _uyeService;
        IUlkeService _ulkeService;
        IBagisTuruService _bagisTuruService;

        public ProfilAramaController(IUyeService uyeService, IUlkeService ulkeService, IBagisTuruService bagisTuruService)
        {
            _uyeService = uyeService;
            _ulkeService = ulkeService;
            _bagisTuruService = bagisTuruService;
        }

        // GET: ProfilArama
        public ActionResult Index()
        {
            //Uye uye = Session["uye"] as Uye;
            List<SelectListItem> Ulkeler = new List<SelectListItem>();
            List<SelectListItem> BagisTurleri = new List<SelectListItem>();
            List<SelectListItem> TarihKisitlama = new List<SelectListItem>();
            foreach (var item in _ulkeService.GetAll())
            {
                Ulkeler.Add(new SelectListItem
                {
                    Text = item.UlkeAdi,
                    Value = item.UlkeAdi

                });
            }
            foreach (var item in _bagisTuruService.GetAll())
            {
                BagisTurleri.Add(new SelectListItem
                {
                    Text = item.BagisTipi,
                    Value = item.BagisTipi

                });
            }
            TarihKisitlama.Add(new SelectListItem
            {
                Value = "Bugün Yayınlananlar",
                Text = "Bugün Yayınlananlar"
            });
            TarihKisitlama.Add(new SelectListItem
            {
                Value = "Son 7 Gün",
                Text = "Son 7 Gün"
            });
            ViewBag.TarihKisitlama = TarihKisitlama;
            ViewBag.Ulkeler = Ulkeler;
            ViewBag.BagisTurleri = BagisTurleri;
            return View();
        }



        public ActionResult AramaSonuc(ProfilDTO profilDTO)
        {
            List<ProfilDTO> Uyeler = new List<ProfilDTO>();
            #region foreach
            //foreach (var item in _uyeService.GetAll())

            //{
            //    if (item.OnayliMi == true)
            //    {
            //        if (profilDTO.Hasta)
            //        {
            //            if (item.Type && item.Hasta.BagisTuru.BagisTipi==profilDTO.BagisTuru)
            //            {
            //                Uyeler.Add(new ProfilDTO
            //                {
            //                    Isim = item.Hasta.Isim,
            //                    ID = item.ID,
            //                    Ulke = item.Hasta.Ulke.UlkeAdi,
            //                    BagisTuru = item.Hasta.BagisTuru.BagisTipi,
            //                    OlusturulmaTarihi = item.OlusturulmaTarihi,
            //                    Hasta = item.Type,
            //                    Soyisim = item.Hasta.Soyisim
            //                });
            //            }
            //        }
            //        if(profilDTO.Donor)
            //        {
            //            if(!item.Type && item.Donor.BagisTuru.BagisTipi == profilDTO.BagisTuru)
            //            {
            //                Uyeler.Add(new ProfilDTO
            //                {
            //                    Isim = item.Donor.Isim,
            //                    ID = item.ID,
            //                    Ulke = item.Donor.Ulke.UlkeAdi,
            //                    BagisTuru = item.Donor.BagisTuru.BagisTipi,
            //                    OlusturulmaTarihi = item.OlusturulmaTarihi,
            //                    Donor = item.Type,
            //                    Soyisim = item.Donor.Soyisim
            //                });
            //            }
            //        }


            //    }
            //}
            #endregion

            var UyeList = _uyeService.GetAll();
            ICollection<Uye> tempUyeler = new List<Uye>();
            if ((!profilDTO.Donor && !profilDTO.Hasta) || (profilDTO.Donor && profilDTO.Hasta))
            {
                tempUyeler = UyeList;
            }
            else if (profilDTO.Donor && !profilDTO.Hasta)
            {
                tempUyeler = UyeList.Where(x => x.Type == false).ToList();
            }
            else if (!profilDTO.Donor && profilDTO.Hasta)
            {
                tempUyeler = UyeList.Where(x => x.Type == true).ToList();
            }


            if (profilDTO.Ulke != null)
            {
                if (profilDTO.Donor && profilDTO.Hasta)
                {
                    tempUyeler = tempUyeler.Where(x =>( x.Donor.Ulke.UlkeAdi == profilDTO.Ulke) || (x.Hasta.Ulke.UlkeAdi == profilDTO.Ulke)).ToList();
                }
                else if (!profilDTO.Donor && profilDTO.Hasta)
                {
                    tempUyeler = tempUyeler.Where(x =>x.Hasta.Ulke.UlkeAdi == profilDTO.Ulke).ToList();
                }
                else if (profilDTO.Donor && !profilDTO.Hasta)
                {
                    tempUyeler = tempUyeler.Where(x => x.Donor.Ulke.UlkeAdi == profilDTO.Ulke).ToList();
                }
            }

            if (profilDTO.BagisTuru != null)
            {
                tempUyeler = tempUyeler.Where(x => x.Donor.BagisTuru.BagisTipi == profilDTO.BagisTuru || x.Hasta.BagisTuru.BagisTipi == profilDTO.BagisTuru).ToList();
            }

            switch (profilDTO.YayinTarihi)
            {
                case "Bugün Yayınlananlar":
                    tempUyeler = tempUyeler.Where(a => a.OlusturulmaTarihi == DateTime.Now).ToList();
                    break;
                case "Son 7 Gün":
                    tempUyeler = tempUyeler.Where(a => (DateTime.Now - a.OlusturulmaTarihi).TotalDays <= 7).ToList();
                    break;
            }

            foreach (var item in tempUyeler)
            {

                if (item.OnayliMi == true)
                {
                    if (item.Type)
                    {

                        Uyeler.Add(new ProfilDTO
                        {
                            Isim = item.Hasta.Isim,
                            ID = item.ID,
                            Ulke = item.Hasta.Ulke.UlkeAdi,
                            BagisTuru = item.Hasta.BagisTuru.BagisTipi,
                            OlusturulmaTarihi = item.OlusturulmaTarihi,
                            Hasta = item.Type,
                            Soyisim = item.Hasta.Soyisim
                        });

                    }
                    if (!item.Type)
                    {

                        Uyeler.Add(new ProfilDTO
                        {
                            Isim = item.Donor.Isim,
                            ID = item.ID,
                            Ulke = item.Donor.Ulke.UlkeAdi,
                            BagisTuru = item.Donor.BagisTuru.BagisTipi,
                            OlusturulmaTarihi = item.OlusturulmaTarihi,
                            Donor = item.Type,
                            Soyisim = item.Donor.Soyisim
                        });

                    }



                }

            }

            return View(Uyeler);
        }

        public ActionResult UyeDetay(int id)
        {
            Uye uye = _uyeService.Get(id);
            return View(uye);
        }

        //public ActionResult AramaSonuc(int id)
        //{
        //    Session["donor"] = new Donor { UyeID = id };
        //    return RedirectToAction("UyeDetay", "ProfilArama");
        //}
    }
}