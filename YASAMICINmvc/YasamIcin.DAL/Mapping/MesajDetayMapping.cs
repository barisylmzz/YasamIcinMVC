using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Model;

namespace YasamIcin.DAL.Mapping
{
    public class MesajDetayMapping:EntityTypeConfiguration<MesajDetay>
    {
        public MesajDetayMapping()
        {
            ToTable("MesajDetaylari");

            HasKey(a => a.ID);

            Property(a => a.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
