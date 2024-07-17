using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreForm2.MyEFCore
{
    public class ProductEntity
    {
        public int ProductId { get; set; }  


        public string? ProductName { get; set; }  
        public int Price {  get; set; }


        // ナビゲーションプロパティ
        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

        public override string ToString()
        {
            return $"Id:{ProductId}, Name={ProductName}, Price={Price}";
        }
    }
}
