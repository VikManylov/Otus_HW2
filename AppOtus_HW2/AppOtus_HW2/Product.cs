using System;
using System.Collections.Generic;

#nullable disable

namespace AppOtus_HW2
{
    public partial class Product
    {
        public Product()
        {
            Purcheses = new HashSet<Purchese>();
        }

        public int Id { get; set; }
        public string Productname { get; set; }
        public decimal? Price { get; set; }
        public int? Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Purchese> Purcheses { get; set; }
    }
}
