using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Smartphone.ViewModel
{
    public class InfoViewModel : INotifyPropertyChanged
    {
        private Phone phone;
        public Phone Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Phone"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
