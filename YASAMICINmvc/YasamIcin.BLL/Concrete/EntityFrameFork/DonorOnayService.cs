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
    public class DonorOnayService : IDonorOnayService
    {
        IDonorOnayDAL _donorOnayDAL;

        public DonorOnayService(IDonorOnayDAL donorOnayDAL)
        {
            _donorOnayDAL = donorOnayDAL;
        }

        public void Delete(DonorOnay entity)
        {
            _donorOnayDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            DonorOnay donorOnay = _donorOnayDAL.Get(a => a.DonorID == entityID);
            _donorOnayDAL.Remove(donorOnay);
        }

        public DonorOnay Get(int entityID)
        {
            return _donorOnayDAL.Get(a => a.DonorID == entityID);
        }

        public ICollection<DonorOnay> GetAll()
        {
            return _donorOnayDAL.GetAll();
        }

        public void Insert(DonorOnay entity)
        {
            _donorOnayDAL.Add(entity);
        }

        public void Update(DonorOnay entity)
        {
            _donorOnayDAL.Update(entity);
        }
    }
}
