using System.Collections.ObjectModel;
using PostSharp.Patterns.Contracts;
using PostSharp.Patterns.Model;
using PostSharp.Patterns.Collections;

namespace MyApp
{
    public class CustomerModel: ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        [Child]
        public AdvisableCollection<AddressModel> Addresses { get; set; }
        [Reference]
        public AddressModel PrincipalAddress { get; set; }
    }
}
