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
    public class KanGrubuMapping:EntityTypeConfiguration<KanGrubu>
    {
        public KanGrubuMapping()
        {
            ToTable("KanGruplari");

            HasKey(a => a.KanGrubuID);

            Property(a => a.KanGrubuID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.KanGrubuTipi)
                .IsRequired()
                .HasMaxLength(10);

            HasMany(a => a.Donorler)
                .WithRequired(a => a.KanGrubu)
                .HasForeignKey(a => a.KanGrubuID);

            HasMany(a => a.Hastalar)
               .WithRequired(a => a.KanGrubu)
               .HasForeignKey(a => a.KanGrubuID);
        }
    }
}
