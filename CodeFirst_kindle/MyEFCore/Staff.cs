using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_kindle.MyEFCore
{
    public class Staff
    {
        public int StaffId { get; set; }    
        public string StaffName { get; set; }


        // navigation property
        public ICollection<Customer> Customers { get; } = new List<Customer>();
    }
}
