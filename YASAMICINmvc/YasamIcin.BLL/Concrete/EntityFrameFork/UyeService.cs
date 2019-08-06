using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.BLL.Abstract;
using YasamIcin.DAL.Abstract;
using YasamIcin.Model;

namespace YasamIcin.BLL.Concrete.EntityFrameFork
{
    public class UyeService : IUyeService
    {
        IUyeDAL _uyeDAL;

        public UyeService(IUyeDAL uyeDAL)
        {
            _uyeDAL = uyeDAL;
        }

        public void Delete(Uye entity)
        {
            _uyeDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Uye currentUye = _uyeDAL.Get(a => a.ID == entityID);
            _uyeDAL.Remove(currentUye);
        }

        public Uye Get(int entityID)
        {
            return _uyeDAL.Get(a => a.ID == entityID);
        }

        public ICollection<Uye> GetAll()
        {
            return _uyeDAL.GetAll();
        }

        public void Insert(Uye entity)
        {
            _uyeDAL.Add(entity);
        }

        public Uye Login(Uye uye)
        {
            Uye tempUye = _uyeDAL.Get(x => x.KullaniciAdi == uye.KullaniciAdi && x.Sifre == uye.Sifre);
            if(tempUye!=null)
            { 
            if (tempUye.OnayliMi)
                return tempUye;
            }
            return null;
        }

        public void Update(Uye entity)
        {
            _uyeDAL.Update(entity);
        }
        public Uye GetUyeByLogin(string kAdi,string pW)
        {
            Uye tempUye = _uyeDAL.Get(a => a.KullaniciAdi == kAdi && a.Sifre == pW);
                if(tempUye.OnayliMi)
                 return tempUye;
            return null;
        }

        public Uye GetUyeByUserName(string kullaniciAdi)
        {
            return _uyeDAL.Get(a => a.KullaniciAdi == kullaniciAdi); 
        }
    }
}
