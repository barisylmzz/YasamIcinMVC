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
    public class DonorMapping:EntityTypeConfiguration<Donor>
    {
        public DonorMapping()
        {
            ToTable("Donorler");

            HasKey(a => a.UyeID);


            HasRequired(x => x.DonorOnay)
                .WithRequiredPrincipal(x => x.Donor)
                .WillCascadeOnDelete(false);
            
                
        }
    }
}
