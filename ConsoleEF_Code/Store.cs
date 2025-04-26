using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleEF_Code
{
    [Table("stores")]
    public class Store
    {
        [Column("stor_id"), MaxLength(4)]
        public string stor_id { get; set; } = string.Empty;

        [Column("stor_name"), Required, MaxLength(40)]
        public string stor_name { get; set; } = string.Empty;

        [Column("stor_address"), MaxLength(40)]
        public string? stor_address { get; set; }

        [Column("city"), MaxLength(20)]
        public string? city { get; set; }

        [Column("state"), MaxLength(2)]
        public string? state { get; set; }

        [Column("zip"), MaxLength(5)]
        public string? zip { get; set; }
    }
}
