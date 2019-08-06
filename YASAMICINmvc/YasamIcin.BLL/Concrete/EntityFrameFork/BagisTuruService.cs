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
    public class BagisTuruService : IBagisTuruService
    {
        IBagisTuruDAL _bagisTuruDAL;

        public BagisTuruService(IBagisTuruDAL bagisTuruDAL)
        {
            _bagisTuruDAL = bagisTuruDAL;
        }

        public void Delete(BagisTuru entity)
        {
            _bagisTuruDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            BagisTuru bagisTuru = _bagisTuruDAL.Get(a => a.BagisTuruID == entityID);
            _bagisTuruDAL.Remove(bagisTuru);
        }

        public BagisTuru Get(int entityID)
        {
            return _bagisTuruDAL.Get(a => a.BagisTuruID == entityID);
        }

        public ICollection<BagisTuru> GetAll()
        {
            return _bagisTuruDAL.GetAll();
        }

        public void Insert(BagisTuru entity)
        {
            _bagisTuruDAL.Add(entity);
        }

        public void Update(BagisTuru entity)
        {
            _bagisTuruDAL.Update(entity);
        }
    }
}
