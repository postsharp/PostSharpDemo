using System;
using System.ComponentModel;

namespace MyApp
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private CustomerModel _customer;
        private AddressModel _currentAddress;


        public CustomerViewModel()
        {
            
        }

        public CustomerModel Customer
        {
            get { return _customer; }
            set {
                if (_customer != value)
                {
                    if (_customer != null)
                    {
                        _customer.PropertyChanged -= CustomerOnPropertyChanged;
                    }

                    _customer = value;
                    this.OnPropertyChanged("Customer");

                    if (value != null)
                    {
                        _customer.PropertyChanged += CustomerOnPropertyChanged;
                        
                        if (_customer.PrincipalAddress != _currentAddress)
                        {
                            this.OnCurrentAddressChanged();

                        }
                    }

                }
            }
        }

        private void OnCurrentAddressChanged()
        {
            if (_currentAddress != null)
            {
                _currentAddress.PropertyChanged -= CurrentAddressOnPropertyChanged;
            }

            _currentAddress = _customer != null ? _customer.PrincipalAddress : null;

            if (_currentAddress != null)
            {
                _currentAddress.PropertyChanged += CurrentAddressOnPropertyChanged;
            }

        }

        private void CurrentAddressOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "FullAddress")
            {
                this.OnPropertyChanged("FullName");
            }
        }

        private void CustomerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case null:
                case "FirstName":
                case "LastName":
                    this.OnPropertyChanged("FullName");
                    break;

                case "PrincipalAddress":
                    this.OnPropertyChanged("FullName");
                    this.OnCurrentAddressChanged();
                    break;


            }
        }

        public string FullName
        {
            get
            {
                if (this.Customer == null) return "null";

                return string.Format("{0} {1} from {2}", 
                    this.Customer.FirstName, 
                    this.Customer.LastName,
                    this.Customer.PrincipalAddress != null ? this.Customer.PrincipalAddress.FullAddress: "?");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}