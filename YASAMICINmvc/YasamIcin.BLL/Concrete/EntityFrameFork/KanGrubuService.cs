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
    public class KanGrubuService : IKanGrubuService
    {
        IKanGrubuDAL _kanGrubuDAL;

        public KanGrubuService(IKanGrubuDAL kanGrubuDAL)
        {
            _kanGrubuDAL = kanGrubuDAL;
        }
        
        public void Delete(KanGrubu entity)
        {
            _kanGrubuDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            KanGrubu currentKan = _kanGrubuDAL.Get(a => a.KanGrubuID == entityID);
            _kanGrubuDAL.Remove(currentKan);
        }

        public KanGrubu Get(int entityID)
        {
            return _kanGrubuDAL.Get(a => a.KanGrubuID == entityID);
        }

        public ICollection<KanGrubu> GetAll()
        {
            return _kanGrubuDAL.GetAll();
        }

        public void Insert(KanGrubu entity)
        {
            _kanGrubuDAL.Add(entity);
        }

        public void Update(KanGrubu entity)
        {
            _kanGrubuDAL.Update(entity);
        }
    }
}
