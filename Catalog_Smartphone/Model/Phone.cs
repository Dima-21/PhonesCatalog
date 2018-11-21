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
    public class Phone : INotifyPropertyChanged, ICloneable
    {

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                Notify();
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                Notify();
            }
        }

        private string manuf;
        public string Manufact
        {
            get { return manuf; }
            set
            {
                manuf = value;
                Notify();
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                Notify();
            }
        }

        private string os;
        public string Os
        {
            get { return os; }
            set
            {
                os = value;
                Notify();
            }
        }

        private double screen;
        public double Screen
        {
            get { return screen; }
            set
            {
                screen = value;
                Notify();
            }
        }

        private int ram;
        public int Ram
        {
            get { return ram; }
            set
            {
                ram = value;
                Notify();
            }
        }

        private int hdd;
        public int Hdd
        {
            get { return hdd; }
            set
            {
                hdd = value;
                Notify();
            }
        }

        private int battery;
        public int Battery
        {
            get { return battery; }
            set
            {
                battery = value;
                Notify();
            }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                Notify();
            }
        }
        private int cam;
        public int Cam
        {
            get { return cam; }
            set
            {
                cam = value;
                Notify();
            }
        }
        private string description;
        public string Descript
        {
            get { return description; }
            set
            {
                description = value;
                Notify();
            }
        }
        private void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
