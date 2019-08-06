using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class Uye:IEntity
    {
        public Uye()
        {
            Mesajlar1 = new HashSet<Mesaj>();
            Mesajlar2 = new HashSet<Mesaj>();
            IsDeleted = false;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz ! ")]
        [DisplayName("KullaniciAdi")]
        [StringLength(20, ErrorMessage = "Maksimum 20 karakter girebilirsiniz.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre kısmı boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required]
        [DisplayName("Güvenlik Sorusu")]
        public int GuvenlikSorusuID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Maksimum 20 karakter girebilirsiniz.")]
        public string GuvenlikSoruCevabi { get; set; }

        public bool Type { get; set; }

        public bool OnayliMi { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }

        public virtual GuvenlikSoru GuvenlikSoru { get; set; }
        public virtual Donor Donor { get; set; }
        public virtual Hasta Hasta { get; set; }
        public virtual ICollection<Mesaj> Mesajlar1 { get; set; }
        public virtual ICollection<Mesaj> Mesajlar2 { get; set; }
        public virtual ICollection<MesajDetay> MesajDetays { get; set; }
    }
}
