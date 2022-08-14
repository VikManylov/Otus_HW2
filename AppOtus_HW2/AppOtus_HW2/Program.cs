using System;
using System.Linq;


namespace AppOtus_HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (eBayDBContext db = new eBayDBContext())
            {
                var categories = db.Categories.ToList();
                var products = db.Products.ToList();
                var customers = db.Customers.ToList();
                var purcheses = db.Purcheses.ToList();
                Console.WriteLine("Categories list:");
                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.Id}. {c.Categoryname}");
                }
                Console.WriteLine("Products list:");
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Id}. {p.Productname} | {p.Price} | {p.Categoryid}");
                }
                Console.WriteLine("Customers list:");
                foreach (Customer c in customers)
                {
                    Console.WriteLine($"{c.Id}. {c.Customername} | {c.Customersurname}");
                }
                Console.WriteLine("Purcheses list:");
                foreach (Purchese p in purcheses)
                {
                    Console.WriteLine($"{p.Id}. {p.Productid} | {p.Customerid}");
                }
            }
        }
    }
}
