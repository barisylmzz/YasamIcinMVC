using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class DonorOnay:IEntity
    {
        [Key]
        public int DonorID { get; set; }
        public bool Isim { get; set; }
        public bool Soyisim { get; set; }
        public bool Cinsiyet { get; set; }
        public bool Sehir { get; set; }
        public bool Ulke { get; set; }
        public bool GSM { get; set; }
        public bool Email { get; set; }
        public bool KanGrubu { get; set; }
        public bool BagisTuru { get; set; }

        public virtual Donor Donor { get; set; }


    }

}
