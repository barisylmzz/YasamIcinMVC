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
    public class MesajMapping:EntityTypeConfiguration<Mesaj>
    {
        public MesajMapping()
        {
            ToTable("Mesajlar");

            HasKey(a => a.MesajID);

            Property(a => a.MesajID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.UyeID1)
                .IsRequired();

            Property(a => a.UyeID2)
                .IsRequired();

            HasMany(a => a.MesajDetaylari)
                .WithRequired(a => a.Mesaj)
                .HasForeignKey(a => a.MesajID)
                .WillCascadeOnDelete(false); ;

        }
    }
}
