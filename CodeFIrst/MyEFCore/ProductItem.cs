using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.MyEFCore
{
    public class ProductItem
    {
        public int ProductItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductItemName { get; set; }
    }
}
