using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YasamIcin.BLL.Abstract;
using YasamIcin.Model;
using YasamIcin.UI.MVC.Areas.Admin.Models;
using YasamIcin.UI.MVC.CustomFilter;
using YasamIcin.UI.MVC.Tools;

namespace YasamIcin.UI.MVC.Areas.Admin.Controllers
{
    public class OnayController : Controller
    {
        IUyeService _uyeService;
        IDonorService _donorService;
        IHastaService _hastaService;

        // GET: Admin/Onay
        public OnayController(IUyeService uyeService, IDonorService donorService, IHastaService hastaService)
        {
            _uyeService = uyeService;
            _donorService = donorService;
            _hastaService = hastaService;
        }
        [AdminFilter]
        public ActionResult Index()
        {
            List<OnayDTO> Uyeler = new List<OnayDTO>();
            foreach (var item in _uyeService.GetAll())
            {
                if (item.OnayliMi == false && item.IsDeleted == false)
                {
                    if (item.Type)
                    {
                        Uyeler.Add(new OnayDTO
                        {
                            Isim = item.Hasta.Isim,
                            ID = item.ID,
                            OlusturulmaTarihi = item.OlusturulmaTarihi,
                            Soyisim = item.Hasta.Soyisim
                        });
                    }
                    else
                    {
                        Uyeler.Add(new OnayDTO
                        {
                            Isim = item.Donor.Isim,
                            ID = item.ID,
                            OlusturulmaTarihi = item.OlusturulmaTarihi,
                            Soyisim = item.Donor.Soyisim
                        });
                    }
                }
            }
            return View(Uyeler);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string kullaniciAdi, string password)
        {
            if (kullaniciAdi == "Admin" && password == "123")
            {
                Session["admin"] = true;
                return RedirectToAction("Index", "Onay");
            }
            Session["admin"] = false;
            return RedirectToAction("Login", "Onay");
        }
        [AdminFilter]
        public ActionResult AdminOnayla(int id)
        {
            Uye uye = _uyeService.Get(id);
            return View(uye);
        }

        [HttpPost]
        [AdminFilter]
        public ActionResult AdminReddet(int id)
        {
            Uye uye = _uyeService.Get(id);

            try
            {


                if (uye.Type == true && uye.OnayliMi == false)
                {

                    bool sonuc = OnayMailHelper.UyelikOnayMail(uye.Hasta.Isim, uye.Hasta.Soyisim, uye.Hasta.Email, "Kayıt işleminiz Reddedildi", "Red");
                    if (!sonuc)
                    {
                        return Json("False");
                    }

                }
                else
                {
                    bool sonuc = OnayMailHelper.UyelikOnayMail(uye.Donor.Isim, uye.Donor.Soyisim, uye.Donor.Email, "Kayıt işleminiz Reddedildi", "Red");
                    if (!sonuc)
                    {
                        return Json("False");
                    }


                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(); //Hata sayfasına yönlendirilicek
            }
            uye.IsDeleted = true;
            _uyeService.Update(uye);
            return Json("True");

        }

        [HttpPost]
        [AdminFilter]
        public ActionResult AdminOnayi(int id)
        {

            try
            {
                Uye uye = _uyeService.Get(id);

                if (uye.Type == true && uye.OnayliMi == false)
                {

                    bool sonuc = OnayMailHelper.UyelikOnayMail(uye.Hasta.Isim, uye.Hasta.Soyisim, uye.Hasta.Email, "Kayıt işleminiz onaylandı", "Hoşgeldiniz");
                    if (!sonuc)
                    {
                        return Json("False");
                    }
                    uye.OnayliMi = true;
                    _uyeService.Update(uye);
                }
                else
                {
                    bool sonuc = OnayMailHelper.UyelikOnayMail(uye.Donor.Isim, uye.Donor.Soyisim, uye.Donor.Email, "Kayıt işleminiz onaylandı", "Hoşgeldiniz");
                    if (!sonuc)
                    {
                        return Json("False");
                    }
                    uye.OnayliMi = true;
                    _uyeService.Update(uye);

                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(); //Hata sayfasına yönlendirilicek
            }
            return Json("True");


        }
    }
}