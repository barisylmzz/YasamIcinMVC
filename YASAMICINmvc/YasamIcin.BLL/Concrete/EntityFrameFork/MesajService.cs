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
    public class MesajService : IMesajService
    {
        IMesajDAL _mesajDAL;

        public MesajService(IMesajDAL mesajDAL)
        {
            _mesajDAL = mesajDAL;
        }

        public void Delete(Mesaj entity)
        {
            _mesajDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Mesaj currentMesaj = _mesajDAL.Get(a => a.MesajID == entityID);
            _mesajDAL.Remove(currentMesaj);
        }

        public Mesaj Get(int entityID)
        {
            return _mesajDAL.Get(a => a.MesajID == entityID);
        }

        public ICollection<Mesaj> GetAll()
        {
            return _mesajDAL.GetAll();
        }

        public List<Mesaj> getAllMesajbyUserID(int ID)
        {
            List<Mesaj> mesajs = new List<Mesaj>();
            foreach (var item in _mesajDAL.GetAll())
            {
                if (item.UyeID1 == ID)
                    mesajs.Add(item);
                else if (item.UyeID2 == ID)
                    mesajs.Add(item);
            }
            return mesajs;
        }

        public Mesaj getMesajbyUsersID(int ID1, int ID2)
        {
            if (ID1 != ID2)
            {
                if (_mesajDAL.Get(x => x.UyeID1 == ID2 && x.UyeID2 == ID1) != null)
                    return _mesajDAL.Get(x => x.UyeID1 == ID2 && x.UyeID2 == ID1);
                else if (_mesajDAL.Get(x => x.UyeID1 == ID1 && x.UyeID2 == ID2) != null)
                {
                    return _mesajDAL.Get(x => x.UyeID1 == ID1 && x.UyeID2 == ID2);
                }
                else
                {
                    _mesajDAL.Add(new Mesaj {
                        UyeID1=ID1,
                        UyeID2=ID2,
                    });
                    return getMesajbyUsersID(ID1, ID2);
                }
            }
            throw new Exception("İletime geçmek için başka kullanıcı seçiniz");
        }

        public void Insert(Mesaj entity)
        {
            foreach (var item in _mesajDAL.GetAll())
            {
                if (_mesajDAL.Get(x => x.UyeID1 == entity.UyeID1 && x.UyeID2 == entity.UyeID2) != null)
                {
                    throw new Exception("Mesaj öncesinde oluşturuldu");
                }                   
                else if (_mesajDAL.Get(x => x.UyeID1 == entity.UyeID1 && x.UyeID2 == entity.UyeID2) != null)
                {
                    throw new Exception("Mesaj öncesinde oluşturuldu");
                }
            }
            _mesajDAL.Add(entity);
        }

        public void Update(Mesaj entity)
        {
            _mesajDAL.Update(entity);
        }
    }
}
