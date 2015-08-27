using System;
using System.Collections.ObjectModel;

namespace MyApp
{
    public class CustomerModel : ModelBase
    {
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _mobile;
        private string _email;
        private AddressModel _principalAddress;
        private ObservableCollection<AddressModel> _addresses;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Mobile
        {
            get { return _mobile; }
            set
            {
                _mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public ObservableCollection<AddressModel> Addresses
        {
            get { return _addresses; }
            set
            {
                _addresses = value;
                OnPropertyChanged("Addresses");
            }
        }

        public AddressModel PrincipalAddress
        {
            get { return _principalAddress; }
            set
            {
                _principalAddress = value;
                OnPropertyChanged("PrincipalAddress");
            }
        }
    }
}