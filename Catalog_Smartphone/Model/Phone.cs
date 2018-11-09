using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Catalog_Smartphone
{
    public class Phone : INotifyPropertyChanged
    {

        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; Notify(); }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set { model = value; Notify(); }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; Notify(); }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; Notify(); }
        }

        private void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Phone> GetAll()
        {
            return new ObservableCollection<Phone>()
            {
                new Phone{ Manufacturer="iPhone", Model="5S", Price=8000, Image = "../Images/Phones/iPhone_5s.jpg"},
                new Phone{ Manufacturer="Samsung", Model="S8", Price=13999, Image = "../Images/Phones/Samsung_s8.png" }
            };
        }
    }
}
