using Catalog_Smartphone.View;
using Catalog_Smartphone.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Smartphone.Infrastructure
{
    class WindowsManager
    {
        public void ShowInfo(Phone phone)
        {
            InfoWindow infoWindow = new InfoWindow();
            (infoWindow.DataContext as InfoViewModel).Phone = phone;
            infoWindow.ShowDialog();
        }
        public Phone AddWindow()
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            if (!(addWindow.DataContext as AddViewModel).IsApply)
                return null;
            Phone phone = (addWindow.DataContext as AddViewModel).Phone;
            return phone;
        }
        public Phone EditWindow(Phone phone)
        {
            AddWindow addWindow = new AddWindow();
            (addWindow.DataContext as AddViewModel).Phone = phone;
            addWindow.ShowDialog();       
            if (!(addWindow.DataContext as AddViewModel).IsApply)
                return null;

            return phone;
        }
    }
}
