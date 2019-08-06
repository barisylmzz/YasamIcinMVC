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
    public class UyeMapping:EntityTypeConfiguration<Uye>
    {
        public UyeMapping()
        {
            ToTable("Uyeler");
          
            HasRequired(x => x.Donor)
                .WithRequiredPrincipal(x => x.Uye)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Hasta)
                .WithRequiredPrincipal(x => x.Uye)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Mesajlar1)
                .WithRequired(x => x.Uye_1)
                .HasForeignKey(X => X.UyeID1)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Mesajlar2)
                .WithRequired(x => x.Uye_2)
                .HasForeignKey(X => X.UyeID2)
                .WillCascadeOnDelete(false);

            HasMany(x => x.MesajDetays)
                .WithRequired(x => x.Uye)
                .HasForeignKey(x => x.GondereciUyeID)
                .WillCascadeOnDelete(false);


        }
    }
}
