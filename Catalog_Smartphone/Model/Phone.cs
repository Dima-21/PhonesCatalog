using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Catalog_Smartphone
{
    public class Phone
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public static ObservableCollection<Phone> GetAll()
        {
            return new ObservableCollection<Phone>()
            {
                new Phone{ Manufacturer="Xiaomi", Model="Redmi note 5", Price=4899, Image = "../Images/Phone.ico"},
                new Phone{ Manufacturer="Samsung", Model="J5", Price=5499, Image = "../Images/Phone.ico" }
            };
        }
    }
}
