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
    public class SehirMapping:EntityTypeConfiguration<Sehir>
    {
        public SehirMapping()
        {
            ToTable("Sehirler");

            HasKey(a => a.SehirID);

            Property(a => a.SehirID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.SehirAdi)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(a => a.Donorler)
                .WithRequired(a => a.Sehir)
                .HasForeignKey(a => a.SehirID);

            HasMany(a => a.Hastalar)
               .WithRequired(a => a.Sehir)
               .HasForeignKey(a => a.SehirID);
        }
    }
}
