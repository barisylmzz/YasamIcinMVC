using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class GuvenlikSoru:IEntity
    {
        public GuvenlikSoru()
        {
            Uyeler = new HashSet<Uye>();
        }

        [Key]
        public int ID { get; set; }
        public string GuvenlikSorusu { get; set; }

        public virtual ICollection<Uye> Uyeler { get; set; }
    }
}
