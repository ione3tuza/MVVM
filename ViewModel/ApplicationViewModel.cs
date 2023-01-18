using MVVM.Command;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private DigitalProduct selectedDigitalProduct;
        public ObservableCollection<DigitalProduct> DigitalProducts { get; set; }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      DigitalProduct digitalProduct = new DigitalProduct();
                      DigitalProducts.Insert(0, digitalProduct);
                      SelectedDigitalProduct = digitalProduct;
                  }));
            }
        }

        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      DigitalProduct digitalProduct = obj as DigitalProduct;
                      if (digitalProduct != null)
                      {
                          DigitalProducts.Remove(digitalProduct);
                      }
                  },
                 (obj) => DigitalProducts.Count > 0));
            }
        }
        public DigitalProduct SelectedDigitalProduct
        {
            get { return selectedDigitalProduct; }
            set
            {
                selectedDigitalProduct = value;
                OnPropertyChanged("SelectedDigitalProduct");
            }
        }

        public ApplicationViewModel()
        {
            DigitalProducts = new ObservableCollection<DigitalProduct>
            {
                new DigitalProduct {Title="iPhone 7", Сategory="Apple", Price=56000 },
                new DigitalProduct {Title="Galaxy S7 Edge", Сategory="Samsung", Price =60000 },
                new DigitalProduct {Title="Elite x3", Сategory="HP", Price=56000 },
                new DigitalProduct {Title="Mi5S", Сategory="Xiaomi", Price=35000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
