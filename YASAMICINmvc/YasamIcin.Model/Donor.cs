using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.Entity;

namespace YasamIcin.Model
{
    public class Donor:IEntity
    {
        [Key]
        public int UyeID { get; set; }
        public DateTime BagisTarihi { get; set; }

        [Required(ErrorMessage = "İsim boş geçilemez")]
        [DisplayName("İsim")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Maksimum 20 karakter girebilirsiniz.")]
        public string Isim { get; set; }

        [Required(ErrorMessage = "Soyisim boş geçilemez")]
        [DisplayName("Soyisim")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Maksimum 20 karakter girebilirsiniz.")]
        public string Soyisim { get; set; }

        [Required(ErrorMessage = "TC No boş geçilemez")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Maksimum 11 karakter girebilirsiniz.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Sadece numerik olmalıdır")]
        public string TCKimlikNo { get; set; }

        //[Required(ErrorMessage = "Fotograf boş geçilemez")]
        //[DataType(DataType.ImageUrl, ErrorMessage = "url hatalı")]
        [DataType(DataType.Upload)]
        [DisplayName("Upload File")]
        public string Fotograf { get; set; }

        [Required(ErrorMessage = "Doğum tarihi giriniz")]
        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }

        [Required(ErrorMessage = "Cinsiyet boş bırakılamaz.")]
        public int CinsiyetID { get; set; }

        [Required(ErrorMessage = "Adres boş geçilemez")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Maksimum 200 karakter girebilirsiniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Şehir boş geçilemez")]
        public int SehirID { get; set; }

        [Required(ErrorMessage = "Ülke boş geçilemez")]
        public int UlkeID { get; set; }

        [Required(ErrorMessage = "GSM boş geçilemez")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Maksimum 11 karakter girebilirsiniz.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Sadece numerik olmalıdır")]
        public string GSM { get; set; }

        [Required(ErrorMessage = "Mail adresi boş bırakılamaz ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kan grubu boş geçilemez")]
        public int KanGrubuID { get; set; }

        [Required(ErrorMessage = "Bağış türü boş geçilemez")]
        public int BagisTuruID { get; set; }

        [Required]
        public string ProfilBilgileri { get; set; }
        

        

        public virtual Uye Uye { get; set; }
        public virtual BagisTuru BagisTuru { get; set; }
        public virtual Cinsiyet Cinsiyet { get; set; }
        public virtual KanGrubu KanGrubu { get; set; }
        public virtual Sehir Sehir { get; set; }
        public virtual Ulke Ulke { get; set; }
        public virtual DonorOnay DonorOnay { get; set; }
    }
}
