using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.MyEFCore
{
    public class Product
    {
        public int ProductId { get; set; }
        //[MaxLength(200)]
        public string ProductName { get; set; }
        public int Price { get; set; }

        public string? BarCode{ get; set; }
        //[NotMapped]
        public int TempId {  get; set; }

        public List<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
    }
}
