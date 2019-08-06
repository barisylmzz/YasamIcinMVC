using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Model;

namespace YasamIcin.BLL.Abstract
{
    public interface IMesajService:IBaseService<Mesaj>
    {
        Mesaj getMesajbyUsersID(int ID1,int ID2);
        List<Mesaj> getAllMesajbyUserID(int ID);
    }
}
