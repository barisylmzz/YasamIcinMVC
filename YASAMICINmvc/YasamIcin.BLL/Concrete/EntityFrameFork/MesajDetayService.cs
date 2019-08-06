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
    public class MesajDetayService : IMesajDetayService
    {
        IMesajDetayDAL _mesajDetayDAL;

        public MesajDetayService(IMesajDetayDAL mesajDetayDAL)
        {
            _mesajDetayDAL = mesajDetayDAL;
        }

        public void Delete(MesajDetay entity)
        {
            _mesajDetayDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            MesajDetay currentDetay = _mesajDetayDAL.Get(a => a.ID == entityID);
            _mesajDetayDAL.Remove(currentDetay);
        }

        public MesajDetay Get(int entityID)
        {
            return _mesajDetayDAL.Get(a => a.ID == entityID);
        }

        public ICollection<MesajDetay> GetAll()
        {
            return _mesajDetayDAL.GetAll();
        }

        public void Insert(MesajDetay entity)
        {
            _mesajDetayDAL.Add(entity);
        }

        public void Update(MesajDetay entity)
        {
            _mesajDetayDAL.Update(entity);
        }
    }
}
