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
    public class SehirService : ISehirService
    {
        ISehirDAL _sehirDAL;

        public SehirService(ISehirDAL sehirDAL)
        {
            _sehirDAL = sehirDAL;
        }

        public void Delete(Sehir entity)
        {
            _sehirDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Sehir currentSehir = _sehirDAL.Get(a => a.SehirID == entityID);
            _sehirDAL.Remove(currentSehir);
        }

        public Sehir Get(int entityID)
        {
            return _sehirDAL.Get(a => a.SehirID == entityID);
        }

        public ICollection<Sehir> GetAll()
        {
            return _sehirDAL.GetAll();
        }

        public void Insert(Sehir entity)
        {
            _sehirDAL.Add(entity);
        }

        public void Update(Sehir entity)
        {
            _sehirDAL.Update(entity);
        }
    }
}
