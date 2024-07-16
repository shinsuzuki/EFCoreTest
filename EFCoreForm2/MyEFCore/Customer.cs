using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreForm2.MyEFCore
{
    public class Customer
    {
        public int CustomerId { get; set; }  
        public string CustomerName { get; set; } = string.Empty;
        public string? TEL { get; set; }
        public string? MailAddress { get; set; }


        public List<Order> Orders { get; set; } = new();
    }
}
