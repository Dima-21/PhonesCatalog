using Catalog_Smartphone.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Catalog_Smartphone.ViewModel
{
    public class AddViewModel : INotifyPropertyChanged
    {
        private Phone phone;
        public Phone Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Phone"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddViewModel()
        {
            PhoneMediator.IsApply = false;
            Phone = PhoneMediator.Phone ?? new Phone();
        }

        private RelayCommand openFolder;
        public ICommand OpenFolder
        {
            get
            {
                return openFolder ??
                  (openFolder = new RelayCommand(x => ChangeImage()));
            }
        }

        private RelayCommand apply;
        public ICommand Apply
        {
            get
            {
                return apply ??
                  (apply = new RelayCommand(x =>
                  {
                      PhoneMediator.IsApply = true;
                      CloseWindow(x);
                  }));
            }
        }

        private RelayCommand close;
        public ICommand Close
        {
            get
            {
                return close ??
                  (close = new RelayCommand(x =>
                  {
                      PhoneMediator.Phone = null;
                      CloseWindow(x);
                  }));
            }
        }

        private void CloseWindow(object win)
        {
            System.Windows.Window w = win as System.Windows.Window;
            w.Close();
        }

        private void ChangeImage()
        {
            OpenFileDialog f = new OpenFileDialog()
            {
                Filter =
            "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            if (f.ShowDialog() == DialogResult.OK)
                Phone.Image = f.FileName;
        }


    }
}
