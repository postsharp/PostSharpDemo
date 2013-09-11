#region Copyright (c) 2004-2010 by SharpCrafters s.r.o.

// This file is part of PostSharp source code and is the property of SharpCrafters s.r.o.
// 
// Source code is provided to customers under strict non-disclosure agreement (NDA). 
// YOU MUST HAVE READ THE NDA BEFORE HAVING RECEIVED ACCESS TO THIS SOURCE CODE. 
// Severe financial penalties apply in case of non respect of the NDA.

#endregion

using System.Text;

namespace NotifyPropertyChangedBadExample
{
    public class AddressModel : ModelBase
    {
        private string _line1;
        private string _line2;
        private string _town;
        private string _country;

        public string Line1
        {
            get { return _line1; }
            set
            {
                _line1 = value;
                OnPropertyChanged("Line1");
                OnPropertyChanged("FullAddress");
            }
        }

        public string Line2
        {
            get { return _line2; }
            set
            {
                _line2 = value;
                OnPropertyChanged("Line2");
                OnPropertyChanged("FullAddress");
            }
        }

        public string Town
        {
            get { return _town; }
            set
            {
                _town = value;
                OnPropertyChanged("Town");
                OnPropertyChanged("FullAddress");
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged("Country");
                OnPropertyChanged("FullAddress");
            }
        }

        public string FullAddress
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (Line1 != null) stringBuilder.Append(Line1);
                if (Line2 != null)
                {
                    if (stringBuilder.Length > 0) stringBuilder.Append("; ");
                    stringBuilder.Append(Line2);
                }
                if (Town != null)
                {
                    if (stringBuilder.Length > 0) stringBuilder.Append("; ");
                    stringBuilder.Append(Town);
                }
                if (Country != null)
                {
                    if (stringBuilder.Length > 0) stringBuilder.Append("; ");
                    stringBuilder.Append(Country);
                }

                return stringBuilder.ToString();
            }
        }
    }
}