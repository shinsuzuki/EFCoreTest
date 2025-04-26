using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleEF_Code
{
    [Table("titles")]
    public class Title
    {
        [Column("title_id"), Required, MaxLength(6)]
        public string title_id { get; set; } = string.Empty;

        [Column("title"), Required, MaxLength(80)]
        public string title { get; set; } = string.Empty;

        [Column("type"), Required, MaxLength(12)]
        public string type { get; set; } = string.Empty;

        [Column("pub_id"), Required, MaxLength(4)]
        public string pub_id { get; set; } = string.Empty;

        [Column("price")]
        public decimal price { get; set; }
        
        [Column("advance")]
        public decimal advance { get; set; }
        
        [Column("ytd_sales")]
        public int ytd_sales { get; set; }

        [Column("notes"), Required, MaxLength(200)]
        public string notes { get; set; } = string.Empty;

        [Column("pubdate"), Required]
        public DateTime pubdate { get; set; }   

    }
}
