using System.Text;

namespace MyApp
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
                if (this.Line1 != null) stringBuilder.Append(this.Line1);
                if (this.Line2 != null)
                {
                    if (stringBuilder.Length > 0) stringBuilder.Append("; ");
                    stringBuilder.Append(this.Line2);
                }
                if (this.Town != null)
                {
                    if (stringBuilder.Length > 0) stringBuilder.Append("; ");
                    stringBuilder.Append(this.Town);
                }
                if (this.Country != null)
                {
                    if (stringBuilder.Length > 0) stringBuilder.Append("; ");
                    stringBuilder.Append(this.Country);
                }

                return stringBuilder.ToString();
            }
        }
    }
}