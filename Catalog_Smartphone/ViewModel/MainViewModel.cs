using Catalog_Smartphone.Infrastructure;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using Catalog_Smartphone.DAL;
using System.IO;
using System.Data.Entity;
using Catalog_Smartphone.View;
using Catalog_Smartphone.ViewModel;

namespace Catalog_Smartphone
{
    class MainViewModel : INotifyPropertyChanged
    {
        public PhonesContext Db { get; set; }

        public WindowsManager WM { get; set; }

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
                Notify();
            }
        }

        private Phone selectedPhone;
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                Notify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName]string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        public MainViewModel()
        {
            Db = new PhonesContext();
            Db.Phones.Load();
            Phones = Db.Phones.Local;
            WM = new WindowsManager();
        }

        #region Commands
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
            get
            {
                return delete ??
                  (delete = new RelayCommand(x => DeletePhone(), y => SelectedPhone != null));
            }
        }
        private RelayCommand edit;
        public ICommand Edit
        {
            get
            {
                return edit ??
                  (edit = new RelayCommand(x => UpdatePhone(), y => SelectedPhone != null));
            }
        }
        private RelayCommand info;
        public ICommand Info
        {
            get
            {
                return info ??
                  (info = new RelayCommand(x => { WM.ShowInfo(SelectedPhone); }, y => SelectedPhone != null));
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
                      System.Windows.Window w = x as System.Windows.Window;
                      w.Close();
                  }));
            }
        }
        #endregion


        #region Methods
        private void DeletePhone()
        {
            Phone phone = SelectedPhone as Phone;
            Db.Phones.Remove(phone);
            Db.SaveChanges();
            if (Phones.Count != 0)
                SelectedPhone = Phones[0];
        }
        private void AddPhone()
        {
            Phone phone = WM.AddWindow();
            if (phone != null)
            {
                Db.Phones.Add(phone);
                Db.SaveChanges();
            }

        }
        private void UpdatePhone()
        {
            Phone vmPhone = (SelectedPhone.Clone()) as Phone;
            WM.EditWindow(vmPhone);
            Db.Update(vmPhone);
            Db.SaveChanges();
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
            UpdatePhone();
        }
        private void SortMethod(object obj)
        {
            switch (obj.ToString())
            {
                case "Manufacturer":
                    Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Manufact));
                    break;
                case "Model":
                    Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Model));
                    break;
                case "Price":
                    Phones = new ObservableCollection<Phone>(Phones.OrderBy(x => x.Price));
                    break;
            }
        }
        #endregion
    }
}
