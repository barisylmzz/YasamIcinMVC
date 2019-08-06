using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YasamIcin.UI.MVC.Areas.Admin.Models
{
    public class OnayDTO
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }
    }
}