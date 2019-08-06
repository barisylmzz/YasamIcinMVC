using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YasamIcin.Model;

namespace YasamIcin.DAL.Mapping
{
    public class DonorOnayMapping:EntityTypeConfiguration<DonorOnay>
    {
        public DonorOnayMapping()
        {
            ToTable("DonorOnayi");
        }
    }
}
