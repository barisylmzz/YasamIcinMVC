using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class BagisTuru:IEntity
    {
        public BagisTuru()
        {
            Donorler = new HashSet<Donor>();
            Hastalar = new HashSet<Hasta>();
        }

        public int BagisTuruID { get; set; }
        public string BagisTipi { get; set; }

        public virtual ICollection<Donor> Donorler { get; set; }
        public virtual ICollection<Hasta> Hastalar { get; set; }
    }
}
