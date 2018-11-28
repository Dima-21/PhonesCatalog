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
        public void ShowInfo()
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.ShowDialog();
        }
        public void AddWindow()
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }
        public void EditWindow()
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();

        }
    }
}
