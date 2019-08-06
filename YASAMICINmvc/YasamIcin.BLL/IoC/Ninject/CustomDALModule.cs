using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.DAL.Abstract;
using YasamIcin.DAL.Concrete.EntityFramework;

namespace YasamIcin.BLL.IoC.Ninject
{
    public class CustomDALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBagisTuruDAL>().To<BagisTuruRepository>();
            Bind<ICinsiyetDAL>().To<CinsiyetRepository>();
            Bind<IDonorDAL>().To<DonorRepository>();
            Bind<IGuvenlikSoruDAL>().To<GuvenlikSoruRepository>();
            Bind<IHastaDAL>().To<HastaRepository>();
            Bind<IKanGrubuDAL>().To<KanGrubuRepository>();
            Bind<IMesajDetayDAL>().To<MesajDetayRepository>();
            Bind<IMesajDAL>().To<MesajRepository>();
            Bind<ISehirDAL>().To<SehirRepository>();
            Bind<IUlkeDAL>().To<UlkeRepository>();
            Bind<IUyeDAL>().To<UyeRepository>();
            Bind<IDonorOnayDAL>().To<DonorOnayRepository>();
        }
    }
}
