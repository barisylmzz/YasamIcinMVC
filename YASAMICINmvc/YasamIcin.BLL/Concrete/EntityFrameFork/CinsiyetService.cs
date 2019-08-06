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
    public class CinsiyetService : ICinsiyetService
    {
        ICinsiyetDAL _cinsiyetDAL;

        public CinsiyetService(ICinsiyetDAL cinsiyetDAL)
        {
            _cinsiyetDAL = cinsiyetDAL;
        }

        public void Delete(Cinsiyet entity)
        {
            _cinsiyetDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Cinsiyet cins = _cinsiyetDAL.Get(a => a.CinsiyetID == entityID);
            _cinsiyetDAL.Remove(cins);
        }

        public Cinsiyet Get(int entityID)
        {
            return _cinsiyetDAL.Get(a => a.CinsiyetID == entityID);
        }

        public ICollection<Cinsiyet> GetAll()
        {
            return _cinsiyetDAL.GetAll();
        }

        public void Insert(Cinsiyet entity)
        {
            _cinsiyetDAL.Add(entity);
        }

        public void Update(Cinsiyet entity)
        {
            _cinsiyetDAL.Update(entity);
        }
    }
}
