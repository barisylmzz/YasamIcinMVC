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
    public class HastaMapping: EntityTypeConfiguration<Hasta>
    {
        public HastaMapping()
        {
            ToTable("Hastalar");

            HasKey(a => a.UyeID);

        
        }
    }
}
