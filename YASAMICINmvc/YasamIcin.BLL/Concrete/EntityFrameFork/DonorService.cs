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
    public class DonorService : IDonorService
    {
        IDonorDAL _donorDAL;

        public DonorService(IDonorDAL donorDAL)
        {
            _donorDAL = donorDAL;
        }

        public void Delete(Donor entity)
        {
            _donorDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Donor currentDonor = _donorDAL.Get(a => a.UyeID == entityID);
            _donorDAL.Remove(currentDonor);
        }

        public Donor Get(int entityID)
        {
            return _donorDAL.Get(a => a.UyeID == entityID);
        }

        public ICollection<Donor> GetAll()
        {
            return _donorDAL.GetAll();
        }

        public void Insert(Donor entity)
        {
            _donorDAL.Add(entity);
        }

        public void Update(Donor entity)
        {
            _donorDAL.Update(entity);
        }
    }
}
