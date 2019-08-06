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
    public class GuvenlikSoruService : IGuvenlikSoruService
    {
        IGuvenlikSoruDAL _guvenlikSoruDAL;

        public GuvenlikSoruService(IGuvenlikSoruDAL guvenlikSoruDAL)
        {
            _guvenlikSoruDAL = guvenlikSoruDAL;
        }

        public void Delete(GuvenlikSoru entity)
        {
            _guvenlikSoruDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            GuvenlikSoru currentSoru = _guvenlikSoruDAL.Get(a => a.ID == entityID);
            _guvenlikSoruDAL.Remove(currentSoru);
        }

        public GuvenlikSoru Get(int entityID)
        {
            return _guvenlikSoruDAL.Get(a => a.ID == entityID);
        }

        public ICollection<GuvenlikSoru> GetAll()
        {
            return _guvenlikSoruDAL.GetAll();
        }

        public void Insert(GuvenlikSoru entity)
        {
            _guvenlikSoruDAL.Add(entity);
        }

        public void Update(GuvenlikSoru entity)
        {
            _guvenlikSoruDAL.Update(entity);
        }
    }
}
