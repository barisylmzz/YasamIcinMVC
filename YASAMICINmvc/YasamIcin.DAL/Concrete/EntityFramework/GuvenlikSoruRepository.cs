using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Core.DataAccess;
using YasamIcin.DAL.Abstract;
using YasamIcin.Model;

namespace YasamIcin.DAL.Concrete.EntityFramework
{
    public class GuvenlikSoruRepository: EFRepositoryBase<GuvenlikSoru, YasamIcinDBContext>, IGuvenlikSoruDAL
    {
    }
}
