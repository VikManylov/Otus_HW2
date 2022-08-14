using System;
using System.Collections.Generic;

#nullable disable

namespace AppOtus_HW2
{
    public partial class Customer
    {
        public Customer()
        {
            Purcheses = new HashSet<Purchese>();
        }

        public int Id { get; set; }
        public string Customername { get; set; }
        public string Customersurname { get; set; }

        public virtual ICollection<Purchese> Purcheses { get; set; }
    }
}
