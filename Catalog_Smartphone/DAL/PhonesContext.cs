using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Smartphone.DAL
{
    class PhonesContext : DbContext
    {
        public PhonesContext() : base("DefaultConnection")
        {
        }
        public DbSet<Phone> Phones { get; set; }
    }
}
