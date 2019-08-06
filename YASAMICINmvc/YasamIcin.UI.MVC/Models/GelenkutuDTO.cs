using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YasamIcin.UI.MVC.Models
{
    public class GelenkutuDTO
    {
        public int ID { get; set; }
        public string GonderenIsim { get; set; }
        public DateTime GonderilmeTarihi { get; set; }
        public string Ulke { get; set; }
        public int UyeID { get; set; }
    }
}