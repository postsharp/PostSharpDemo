#region Copyright (c) 2004-2010 by SharpCrafters s.r.o.

// This file is part of PostSharp source code and is the property of SharpCrafters s.r.o.
// 
// Source code is provided to customers under strict non-disclosure agreement (NDA). 
// YOU MUST HAVE READ THE NDA BEFORE HAVING RECEIVED ACCESS TO THIS SOURCE CODE. 
// Severe financial penalties apply in case of non respect of the NDA.

#endregion

using System.Collections.ObjectModel;

namespace NotifyPropertyChangedBadExample
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
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
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