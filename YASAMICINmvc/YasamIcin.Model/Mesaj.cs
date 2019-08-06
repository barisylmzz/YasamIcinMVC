using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class Mesaj:IEntity
    {
        public Mesaj()
        {
            MesajDetaylari = new HashSet<MesajDetay>();
        }

        public int MesajID { get; set; }
        public int UyeID1 { get; set; }
        public int UyeID2 { get; set; }



        public virtual Uye Uye_1 { get; set; }
        public virtual Uye Uye_2 { get; set; }
        public virtual ICollection<MesajDetay> MesajDetaylari { get; set; }
    }
}
