using System;
using System.Collections.Generic;

#nullable disable

namespace AppOtus_HW2
{
    public partial class Purchese
    {
        public int Id { get; set; }
        public int? Productid { get; set; }
        public int? Customerid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
