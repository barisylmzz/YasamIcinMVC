using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.DAL.Mapping;
using YasamIcin.Model;

namespace YasamIcin.DAL.Concrete
{
    public class YasamIcinDBContext : DbContext
    {
        public YasamIcinDBContext() : base("Server =.; Database=YasamicinDB;uid=sa;pwd=123")
        { 
            //base("Server =DESKTOP-Q0A3P5Q\\SQLEXPRESS; Database=YasamicinDB;Integrated Security = True") (muahrrem)
            //: base("Server =.; Database=YasamicinDB;uid=sa;pwd=123")
        Database.SetInitializer(new YasamicinInitializer());

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Configurations.Add(new UyeMapping());
            modelBuilder.Configurations.Add(new HastaMapping());
            modelBuilder.Configurations.Add(new BagisTuruMapping());
            modelBuilder.Configurations.Add(new CinsiyetMapping());
            modelBuilder.Configurations.Add(new DonorMapping());
            modelBuilder.Configurations.Add(new GuvenlikSoruMapping());
            modelBuilder.Configurations.Add(new KanGrubuMapping());
            modelBuilder.Configurations.Add(new MesajDetayMapping());
            modelBuilder.Configurations.Add(new MesajMapping());
            modelBuilder.Configurations.Add(new SehirMapping());
            modelBuilder.Configurations.Add(new UlkeMapping());
            modelBuilder.Configurations.Add(new DonorOnayMapping());
        }


        public virtual DbSet<Uye> Uyes { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Hasta> Hastas { get; set; }
        public virtual DbSet<Mesaj> Mesajs { get; set; }
        public virtual DbSet<Ulke> Ulkes { get; set; }
        public virtual DbSet<Sehir> Sehirs { get; set; }
        public virtual DbSet<BagisTuru> BagisTurus { get; set; }
        public virtual DbSet<Cinsiyet> Cinsiyets { get; set; }
        public virtual DbSet<GuvenlikSoru> GuvenlikSorus { get; set; }
        public virtual DbSet<KanGrubu> KanGrubus { get; set; }
        public virtual DbSet<MesajDetay> MesajDetays { get; set; }
        public virtual DbSet<DonorOnay> DonorOnays { get; set; }
        
    }
}
