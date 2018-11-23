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
        public void Update(Phone p)
        {
            Phone dbPhone = Phones.Find(p.Id);
            if (dbPhone != null)
            {
                dbPhone.Manufact = p.Manufact;
                dbPhone.Model = p.Model;
                dbPhone.Price = p.Price;
                dbPhone.Os = p.Os;
                dbPhone.Ram = p.Ram;
                dbPhone.Memory = p.Memory;
                dbPhone.Screen = p.Screen;
                dbPhone.Image = p.Image;
                dbPhone.Descript = p.Descript;
                dbPhone.Battery = p.Battery;
                dbPhone.Cam = p.Cam;
                Entry(dbPhone).State = EntityState.Modified;
            }
        }
    }
}
