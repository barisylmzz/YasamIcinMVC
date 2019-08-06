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
    class UlkeMapping:EntityTypeConfiguration<Ulke>
    {
        public UlkeMapping()
        {
            ToTable("Ulkeler");

            HasKey(a => a.UlkeID);

            Property(a => a.UlkeID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.UlkeAdi)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.UlkeKodu)
                .IsRequired();
                

            HasMany(a => a.Donorler)
                .WithRequired(a => a.Ulke)
                .HasForeignKey(a => a.UlkeID);

            HasMany(a => a.Hastalar)
               .WithRequired(a => a.Ulke)
               .HasForeignKey(a => a.UlkeID);
        }
    }
}
