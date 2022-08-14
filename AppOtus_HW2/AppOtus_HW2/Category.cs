using System;
using System.Collections.Generic;

#nullable disable

namespace AppOtus_HW2
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Categoryname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
