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
    public class UlkeService : IUlkeService
    {
        IUlkeDAL _ulkeDAL;

        public UlkeService(IUlkeDAL ulkeDAL)
        {
            _ulkeDAL = ulkeDAL;
        }

        public void Delete(Ulke entity)
        {
            _ulkeDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Ulke currentUlke = _ulkeDAL.Get(a => a.UlkeID == entityID);
            _ulkeDAL.Remove(currentUlke);
        }

        public Ulke Get(int entityID)
        {
            return _ulkeDAL.Get(a => a.UlkeID == entityID);
        }

        public ICollection<Ulke> GetAll()
        {
            return _ulkeDAL.GetAll();
        }

        public void Insert(Ulke entity)
        {
            _ulkeDAL.Add(entity);
        }

        public void Update(Ulke entity)
        {
            _ulkeDAL.Update(entity);
        }
    }
}
