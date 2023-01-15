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
                new DigitalProduct { Title="iPhone 7", Сategory="Apple", Price=56000 },
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
