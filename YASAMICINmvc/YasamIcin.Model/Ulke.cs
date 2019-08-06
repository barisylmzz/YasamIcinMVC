using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class Ulke:IEntity
    {
        public Ulke()
        {
            Donorler = new HashSet<Donor>();
            Hastalar = new HashSet<Hasta>();
        }

        public int UlkeID { get; set; }
        public string UlkeAdi { get; set; }
        public int UlkeKodu { get; set; }

        public virtual ICollection<Donor> Donorler { get; set; }
        public virtual ICollection<Hasta> Hastalar { get; set; }
    }
}
