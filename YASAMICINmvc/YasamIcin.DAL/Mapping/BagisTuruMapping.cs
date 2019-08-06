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
    public class BagisTuruMapping: EntityTypeConfiguration<BagisTuru>
    {
        public BagisTuruMapping()
        {
            ToTable("BagisTürleri");

            HasKey(a => a.BagisTuruID);

            Property(a=>a.BagisTuruID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.BagisTipi)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(a => a.Donorler)
                .WithRequired(a => a.BagisTuru)
                .HasForeignKey(a => a.BagisTuruID);

            HasMany(a => a.Hastalar)
               .WithRequired(a => a.BagisTuru)
               .HasForeignKey(a => a.BagisTuruID);
        }
    }
}
