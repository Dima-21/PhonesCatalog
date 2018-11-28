using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Smartphone.Infrastructure
{
    static class PhoneMediator
    {
        public static bool IsApply { get; set; }
        public static Phone Phone { get; set; }

        static PhoneMediator()
        {
            Phone = new Phone();
        }
    }
}
