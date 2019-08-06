using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class MesajDetay:IEntity
    {
        [Key]
        public int ID { get; set; }
        public int MesajID { get; set; }
        public int GondereciUyeID { get; set; }
        public string MesajIcerik { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public bool OkunduMu { get; set; }

        public virtual Mesaj Mesaj { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
