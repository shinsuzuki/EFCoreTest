using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEF_Code
{
    public class StoresOverView
    {
        public string stor_name { get; set; } = string.Empty;

        public string? state { get; set; }

        public Int16 qty { get; set; }
    }
}
