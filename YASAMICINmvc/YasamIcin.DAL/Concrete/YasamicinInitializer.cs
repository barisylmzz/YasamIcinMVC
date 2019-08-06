
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using YasamIcin.Model;

namespace YasamIcin.DAL.Concrete
{
    public class YasamicinInitializer : DropCreateDatabaseIfModelChanges<YasamIcinDBContext>
    {
        protected override void Seed(YasamIcinDBContext context)
        {

            context.Ulkes.Add(new Model.Ulke { UlkeAdi = "Türkiye", UlkeKodu = 1 });
            //context.Ulkes.Add(new Model.Ulke { UlkeAdi = "Almanya", UlkeKodu = 2 });
            context.Sehirs.Add(new Model.Sehir { SehirAdi = "Istanbul" });
            context.Sehirs.Add(new Model.Sehir { SehirAdi = "Ankara" });
            context.Sehirs.Add(new Model.Sehir { SehirAdi = "İzmir" });
            context.Sehirs.Add(new Model.Sehir { SehirAdi = "Bursa" });
            context.Sehirs.Add(new Model.Sehir { SehirAdi = "Adana" });
            context.BagisTurus.Add(new BagisTuru { BagisTipi = "kalp" });
            context.BagisTurus.Add(new BagisTuru { BagisTipi = "böbrek" });
            context.Cinsiyets.Add(new Cinsiyet { CinsiyetTipi = "Kadın" });
            context.Cinsiyets.Add(new Cinsiyet { CinsiyetTipi = "Erkek" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "A Rh(+)" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "A Rh(-)" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "B Rh(+)" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "B Rh(-)" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "AB Rh(+)" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "AB Rh(-)" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "0 Rh(+)" });
            context.KanGrubus.Add(new KanGrubu { KanGrubuTipi = "0 Rh(-)" });
            context.GuvenlikSorus.Add(new Model.GuvenlikSoru { GuvenlikSorusu = "evcil hayvan ismi" });
            context.SaveChanges();
            Uye _tempUye = new Model.Uye
            {
                KullaniciAdi = "m",
                Sifre = "1",
                GuvenlikSorusuID = 1,
                GuvenlikSoruCevabi = "karabaş",
                Type = true,
                OnayliMi = false,
            };
            
            context.Uyes.Add(_tempUye);
           
            context.SaveChanges();
            Hasta _tempHasta = new Hasta();
            _tempHasta.UyeID = _tempUye.ID;
            _tempHasta.Adres = "aaaaaaaa";
            _tempHasta.BagisTuruID = 1;
            _tempHasta.CinsiyetID = 1;
            _tempHasta.DogumTarihi = DateTime.Now;
            _tempHasta.Email = "aaaa@hotmail.com";
            _tempHasta.KanGrubuID = 1;
            _tempHasta.SehirID = 1;
            _tempHasta.Isim = "Ahmet";
            _tempHasta.Soyisim = "mehet";
            _tempHasta.ProfilBilgileri = "baaaaaaaa";
            _tempHasta.TCKimlikNo = "11111111111";
            _tempHasta.UlkeID = 1;
            _tempHasta.GSM = "11111111111";
            _tempHasta.Fotograf = "abc";
            context.Hastas.Add(_tempHasta);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}