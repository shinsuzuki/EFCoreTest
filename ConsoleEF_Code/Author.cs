using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleEF_Code
{
    [Table("Authors")]
    public class Author
    {
        [Column("au_id"), Required, MaxLength(11)]
        public string au_id { get; set; } = string.Empty;

        [Column("au_lname"), Required, MaxLength(40)]
        public string au_lname { get; set; } = string.Empty;
        
        [Column("au_fname"), Required, MaxLength(20)]
        public string au_fname { get; set; } = string.Empty;

        [Column("phone"), MaxLength(12)]
        public string? phone{ get; set; }

        [Column("address"), MaxLength(40)]
        public string? address { get; set; }

        [Column("city"), MaxLength(20)]
        public string? city{ get; set; }
        
        [Column("state"), MaxLength(2)]
        public string? state{ get; set; }
        
        [Column("zip"), MaxLength(5)]
        public string? zip { get; set; }

        [Column("contract"), Required]
        public bool bit { get; set; } = false;
    }
}
