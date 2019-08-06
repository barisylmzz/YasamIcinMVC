using Ninject;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YasamIcin.BLL.Abstract;
using YasamIcin.BLL.Concrete.EntityFrameFork;

namespace YasamIcin.UI.MVC.Models
{
   public class SayfaDetayText
    {
      
        public SayfaDetayText()
        {
            
        }
        private static List<SayfaDetay> _sayfaDetays = new List<SayfaDetay>();      
       

        public static void Insert(SayfaDetay sayfaDetay)
        {
            _sayfaDetays.Add(sayfaDetay);
        }
        public static SayfaDetay Get(string head)
        {
            return _sayfaDetays.Where(x => x.Baslik == head).FirstOrDefault();
        }
        public static List<SayfaDetay> GetAll()
        {
            return _sayfaDetays;
        }
        public static void Update(SayfaDetay sayfaDetay)
        {
            var temp =_sayfaDetays.Where(x => x.Baslik == sayfaDetay.Baslik).FirstOrDefault();
            temp.Metin = sayfaDetay.Metin;
        }

        public static int TotalDonor()
        {

            
            IKernel kernel = new StandardKernel(new YasamIcin.BLL.IoC.Ninject.CustomDALModule());
            IUyeService uyeService = kernel.Get<UyeService>();
            return uyeService.GetAll().Where(x => x.Type == false && x.OnayliMi == true).Count();
        }
        public static int TotalHasta()
        {
            IKernel kernel = new StandardKernel(new YasamIcin.BLL.IoC.Ninject.CustomDALModule());
            IUyeService uyeService = kernel.Get<UyeService>();
            return uyeService.GetAll().Where(x => x.Type == true && x.OnayliMi == true).Count();
        }
    }
}