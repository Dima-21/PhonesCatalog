﻿using Catalog_Smartphone.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Catalog_Smartphone.ViewModel
{
    public class AddViewModel
    {
        public Phone Phone { get; set; }


        public bool IsApply { get; set; }
        public AddViewModel()
        {
            IsApply = false;
            Phone = new Phone() { Image = "..\\Images\\Phones\\Phone.ico" };
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
                      IsApply = true;
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
                      System.Windows.Window w = x as System.Windows.Window;
                      w.Close();
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
