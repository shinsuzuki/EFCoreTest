﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreForm2.MyEFCore
{
    public class Order
    {
        public int OrderId {  get; set; }
        public int CustomerId{  get; set; }
        public DateTime OrderDate { get; set; }

    }
}
