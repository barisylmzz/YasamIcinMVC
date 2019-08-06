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
    public class CinsiyetMapping: EntityTypeConfiguration<Cinsiyet>
    {
        public CinsiyetMapping()
        {
            ToTable("Cinsiyet");

            HasKey(a => a.CinsiyetID);

            Property(a => a.CinsiyetID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.CinsiyetTipi)
                .IsRequired()
                .HasMaxLength(5);

            HasMany(a => a.Donorler)
                .WithRequired(a => a.Cinsiyet)
                .HasForeignKey(a => a.CinsiyetID);

            HasMany(a => a.Hastalar)
               .WithRequired(a => a.Cinsiyet)
               .HasForeignKey(a => a.CinsiyetID);

        }
    }
}
