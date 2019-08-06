using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class Cinsiyet:IEntity
    {
        public Cinsiyet()
        {
            Donorler = new HashSet<Donor>();
            Hastalar = new HashSet<Hasta>();
        }

        public int CinsiyetID { get; set; }
        public string CinsiyetTipi { get; set; }

        public virtual ICollection<Donor> Donorler { get; set; }
        public virtual ICollection<Hasta> Hastalar { get; set; }
    }
}
