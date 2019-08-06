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
    public class HastaService : IHastaService
    {
        IHastaDAL _hastaDAL;

        public HastaService(IHastaDAL hastaDAL)
        {
            _hastaDAL = hastaDAL;
        }

        public void Delete(Hasta entity)
        {
            _hastaDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Hasta currentHasta = _hastaDAL.Get(a => a.UyeID == entityID);
            _hastaDAL.Remove(currentHasta);
        }

        public Hasta Get(int entityID)
        {
            return _hastaDAL.Get(a => a.UyeID == entityID);
        }

        public ICollection<Hasta> GetAll()
        {
            return _hastaDAL.GetAll();
        }

        public void Insert(Hasta entity)
        {
            
            _hastaDAL.Add(entity);
        }

        public void Update(Hasta entity)
        {
            _hastaDAL.Update(entity);
        }
    }
}
