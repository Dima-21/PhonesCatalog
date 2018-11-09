using Catalog_Smartphone.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
namespace Catalog_Smartphone
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Phone> phones;
        public ObservableCollection<Phone> Phones
        {
            get
            {
                return phones;

            }
            set
            {
                phones = value;
                OnPropertyChanged();
            }
        }

        private Phone phone;
        public Phone SelectedPhone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }


        private void OnPropertyChanged([CallerMemberName]string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        //Ctor
        public ViewModel()
        {
            Phones = Phone.GetAll();
            //Sort = new RelayCommand(SortMethod);
        }
        //

        //Commands
        private RelayCommand sort;
        public ICommand Sort
        {
            get { return sort ?? (sort = new RelayCommand(SortMethod)); }
        }
        private RelayCommand add;
        public ICommand Add
        {
            get { return add ?? (add = new RelayCommand(x => AddPhone())); }
        }
        private RelayCommand delete;
        public ICommand Delete
        {
            get { return delete ?? 
                    (delete = new RelayCommand(x => DeletePhone(), y => SelectedPhone!=null)); }
        }
        private RelayCommand openFolder;
        public ICommand OpenFolder
        {
            get { return openFolder ?? 
                    (openFolder = new RelayCommand(x => ChangeImage(), y => SelectedPhone!=null)); }
        }

        //


        //Methods
        private void DeletePhone()
        {
            Phones.Remove(SelectedPhone);
        }
        private void AddPhone()
        {
            Phones.Add(new Phone()
            {
                Manufacturer = "Unknown",
                Model = "Unknown",
                Image = "../Images/Phones/Phone.ico"
            });
        }
        private void ChangeImage()
        {
                OpenFileDialog f = new OpenFileDialog()
                {
                    Filter =
                "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
                };

                if (f.ShowDialog() == DialogResult.OK)
                    SelectedPhone.Image = f.FileName;
        }
        private void SortMethod(object obj)
        {
            switch (obj.ToString())
            {
                case "Manufacturer":
                    Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Manufacturer));
                    break;
                case "Model":
                    Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Model));
                    break;
                case "Price":
                    Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Price));
                    break;
            }
        }
        //
    }
}
