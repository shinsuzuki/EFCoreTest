using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLinq.Models.Pubs;
using ConsoleLinq.Models.Northwind;

namespace ConsoleLinq
{
    public class PubsSample
    {
        pubsContext _context;

        public PubsSample()
        {
        }

        public void SelectTest()
        {
            Console.WriteLine("____pubContext");
            using (var pubsContext = new pubsContext())
            {
                var authors = pubsContext.authors
                    .Where(x => x.state == "CA")
                    .Select(a => new
                    {
                        a.au_id,
                        au_name = a.au_fname + " " + a.au_lname,
                        a.phone
                    });

                foreach (var auth in authors) { Console.WriteLine(auth); }
            }

            Console.WriteLine("____northwindContext");
            using (var nwContext = new northwindContext())
            {
                var orders = nwContext.Orders
                    .Where(x => x.CustomerID == "VINET" && x.OrderDate > new DateTime(1997, 1, 1))
                    .Select(x => new
                    {
                        x.OrderID,
                        x.CustomerID,
                        x.OrderDate
                    });

                foreach (var order in orders) { Console.WriteLine(order); }
            }



        }

    }
}
