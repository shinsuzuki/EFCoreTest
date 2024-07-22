using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_kindle.MyEFCore
{
    public class Product
    {
        public int ProductId { get; set; }
        //[MaxLength(200)]
        public string ProductName { get; set; } 
        public int Price { get; set; }
        public string? BarCodeA { get; set; }
        //[NotMapped]
        public int TempId { get; set; }


        // navigation property
        public ICollection<ProductItem> ProductItems { get; } = new List<ProductItem>();
    }
}
