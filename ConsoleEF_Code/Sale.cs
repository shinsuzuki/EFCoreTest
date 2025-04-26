using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleEF_Code
{
    [Table("sales")]
    public class Sale
    {
        [Column("stor_id"), Required, MaxLength(40)]
        public string stor_id { get; set; } = string.Empty;

        [Column("ord_num"), Required]
        public DateTime ord_num { get; set; }

        [Column("qty"), Required]
        public Int16 qty { get; set; }

        [Column("payterms"), Required, MaxLength(12)]
        public string payterms { get; set; } = string.Empty;

        [Column("title_id"), Required, MaxLength(6)]
        public string title_id { get; set; } = string.Empty;    
    }
}
