using System.Collections.ObjectModel;
using System.Windows;

namespace NotifyPropertyChangedBadExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomerViewModel customerViewModel = new CustomerViewModel
                                                      {
                                                          Customer = new CustomerModel()
                                                                         {
                                                                             FirstName = "Jan",
                                                                             LastName = "Noval",
                                                                             Addresses = new ObservableCollection<AddressModel>()
                                                                                                       {
                                                                                                           new AddressModel
                                                                                                               {
                                                                                                                   Line1 = "Saldova 1G",
                                                                                                                   Town = "Prague"
                                                                                                               },
                                                                                                           new AddressModel()
                                                                                                               {
                                                                                                                   Line1 = "Tyrsova 25",
                                                                                                                   Town = "Brno"
                                                                                                               },
                                                                                                               new AddressModel
                                                                                                                   {
                                                                                                                       Line1 = "Pivorarka 154",
                                                                                                                       Town = "Pilsen"
                                                                                                                   }
                                                                                                       }
                                                                         },
                                                                         
                                                      };
            customerViewModel.Customer.PrincipalAddress = customerViewModel.Customer.Addresses[0];
            this.DataContext = customerViewModel;
        }
    }
}
