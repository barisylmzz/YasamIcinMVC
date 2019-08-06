using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Model;

namespace YasamIcin.BLL.Abstract
{
    public interface IUyeService:IBaseService<Uye>
    {
        Uye Login(Uye uye);

        Uye GetUyeByLogin(string kAdi, string pW);

        Uye GetUyeByUserName(string kullaniciAdi);
    }
}
