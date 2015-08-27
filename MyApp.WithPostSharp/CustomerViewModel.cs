using PostSharp.Patterns.Model;

namespace MyApp
{
    [NotifyPropertyChanged]
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            
        }

        public CustomerModel Customer { get; set; }

        public string FullName
        {
            get
            {
                if (this.Customer == null) return "(No Data)";

                return string.Format("{0} {1} from {2}", 
                    this.Customer.FirstName, 
                    this.Customer.LastName,
                    this.Customer.PrincipalAddress != null ? this.Customer.PrincipalAddress.FullAddress: "?");
            }
        }


    }
}