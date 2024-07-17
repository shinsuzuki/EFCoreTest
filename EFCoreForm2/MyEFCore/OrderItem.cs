using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreForm2.MyEFCore
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }


        public int Quantity { get; set; }
        public int Price { get; set; }


        // ナビゲーションプロパティ
        public ProductEntity? Product { get; set; }
        public Order? Order { get; set; }
    }
}
