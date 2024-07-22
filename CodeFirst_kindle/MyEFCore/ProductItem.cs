using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_kindle.MyEFCore
{
    public class ProductItem
    {
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }

        // navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }    

    }
}
