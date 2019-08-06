using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YasamIcin.UI.MVC.Models
{
    public class ProfilDTO
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string BagisTuru { get; set; }
        public string Ulke { get; set; }
        public bool Donor { get; set; }
        public bool Hasta { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public string YayinTarihi { get; set; }
    }
}