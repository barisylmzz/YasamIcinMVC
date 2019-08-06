using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YasamIcin.Model;

namespace YasamIcin.UI.MVC.Models
{
    public class DonorUyeGuncelleDTO
    {
        public Uye  Uye { get; set; }
        public Donor Donor { get; set; }
        public DonorOnay DonorOnay { get; set; }
    }
}