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
    public class GuvenlikSoruMapping:EntityTypeConfiguration<GuvenlikSoru>
    {
        public GuvenlikSoruMapping()
        {
            ToTable("GüvenlikSorulari");

            HasKey(a => a.ID);

            Property(a => a.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.GuvenlikSorusu)
                .IsRequired()
                .HasMaxLength(200);

            HasMany(a => a.Uyeler)
                .WithRequired(a => a.GuvenlikSoru)
                .HasForeignKey(a => a.GuvenlikSorusuID);

           
        }
    }
}
