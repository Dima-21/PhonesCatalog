using Catalog_Smartphone.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Smartphone.ViewModel
{
    public class InfoViewModel
    {
        public Phone Phone{ get; set; }
        public InfoViewModel()
        {
            Phone = PhoneMediator.Phone;
        }
    }
}
