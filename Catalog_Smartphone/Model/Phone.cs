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
    public class Phone : INotifyPropertyChanged, ICloneable, IDataErrorInfo
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

        private string model = "Unknown";
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                Notify();
            }
        }

        private string manuf = "Unknown";
        public string Manufact
        {
            get { return manuf; }
            set
            {
                manuf = value;
                Notify();
            }
        }

        private double? price = 0;
        public double? Price
        {
            get { return price; }
            set
            {
                price = value;
                Notify();
            }
        }

        private string os = "Unknown";
        public string Os
        {
            get { return os; }
            set
            {
                os = value;
                Notify();
            }
        }

        private double? screen = 0;
        public double? Screen
        {
            get { return screen; }
            set
            {
                screen = value;
                Notify();
            }
        }

        private int? ram = 0;
        public int? Ram
        {
            get { return ram; }
            set
            {
                ram = value;
                Notify();
            }
        }

        private int? memory = 0;
        public int? Memory
        {
            get { return memory; }
            set
            {
                memory = value;
                Notify();
            }
        }

        private int? battery = 0;
        public int? Battery
        {
            get { return battery; }
            set
            {
                battery = value;
                Notify();
            }
        }

        private string image =  "..\\Images\\Phones\\Phone.ico";
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                Notify();
            }
        }

        private int? cam = 0;
        public int? Cam
        {
            get { return cam; }
            set
            {
                cam = value;
                Notify();
            }
        }
        private string description = "-";
        public string Descript
        {
            get { return description; }
            set
            {
                description = value;
                Notify();
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Model":
                        if (Model == null)
                            error = "Введите значение";
                        else if (Model.Count() < 1)
                            error = "Введите значение";
                        else if (Model.Count() > 70)
                            error = "Максимальное количество символов = 70";
                        break;
                    case "Manufact":
                        if (Manufact == null)
                            error = "Введите значение";
                        else if (Manufact.Count() < 1)
                            error = "Введите значение";
                        else if (Manufact.Count() > 70)
                            error = "Максимальное количество символов = 70";
                        break;
                    case "Price":
                        if (Price < 0)
                            error = "Минимальная цена = 0";
                        else if (Price > 1000000)
                            error = "Максимальная цена = 1000000";
                        break;
                    case "Os":
                        if (Os == null)
                            error = "Минимальное количество символов = 3";
                        else if (Os.Count() < 3)
                            error = "Минимальное количество символов = 3";
                        else if (Os.Count() > 40)
                            error = "Максимальное количество символов = 40";
                        break;
                    case "Memory":
                        if (Memory < 0)
                            error = "Минимальное значение = 0";
                        else if (Memory > 512)
                            error = "Значение должно быть < 512";
                        break;
                    case "Ram":
                        if (Ram < 0)
                            error = "Минимальное значение = 0";
                        else if (Ram > 16)
                            error = "Значение должно быть < 16";
                        break;
                    case "Screen":
                        if (Screen < 0)
                            error = "Минимальное значение = 0";
                        else if (Screen > 10)
                            error = "Максимальное значение = 10";
                        break;
                    case "Cam":
                        if (Cam < 0)
                            error = "Минимальное значение = 0";
                        else if (Cam > 30)
                            error = "Максимальное значение = 30";
                        break;
                    case "Battery":
                        if (Battery < 0)
                            error = "Минимальное значение = 0";
                        else if (Battery > 10000)
                            error = "Максимальное значение = 10000";
                        break;
                    case "Descript":
                        if (Descript == null)
                            error = "Введите значение";
                        else if (Descript.Count() < 1)
                            error = "Введите значение";
                        else if (Descript.Count() > 1000)
                            error = "Максимальное количество символов = 1000";
                        break;

                }
                return error;
            }
        }

        #region Methods


        private void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
