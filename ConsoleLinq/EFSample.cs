using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLinq.Models.Pubs;
using ConsoleLinq.Models.Northwind;
using System.Security.Cryptography.X509Certificates;
using System.Xml;


namespace ConsoleLinq
{
    public class EFSample
    {
        pubsContext _context;

        public EFSample()
        {
        }

        /// <summary>
        /// test
        /// </summary>
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

        /// <summary>
        /// 抽出
        /// </summary>
        public void Where()
        {
            // フィルタリング処理
            using (var pubsContext = new pubsContext())
            {
                var authors = pubsContext.authors
                    .Where(x => x.state == "CA" && x.contract == true)
                    //.Where(x => x.au_fname.Length == 5)
                    .Where(x => x.au_fname.EndsWith("e"));

                foreach (var author in authors) { Console.WriteLine(author); }
            }

            // 日付の範囲チェック
            using (var nwContext = new northwindContext())
            {
                var orders = nwContext.Orders
                    .Where(x => x.OrderDate >= DateTime.Parse("1996/7/1") 
                             && x.OrderDate <  DateTime.Parse("1996/8/1"))
                    .Select(x => x);

                foreach (var order in orders ) { Console.WriteLine( $"{order.OrderID},{order.OrderDate}"); }
            }
        }

        /// <summary>
        /// 射影
        /// </summary>
        public void Select()
        {
            // 射影
            using (var pubsContext = new pubsContext())
            {
                var authors = pubsContext.authors
                    .Where(x => x.state == "CA")
                    .Select(x => new
                    {
                        au_id = x.au_id,
                        au_name = x.au_fname + " " + x.au_lname,
                        phone = x.phone,
                        state = x.state
                    });

                foreach (var author in authors) { Console.WriteLine(author); }
            }

        }

        /// <summary>
        /// リレーション
        /// </summary>
        public void Relation()
        {
            // リレーション1
            using (var pubsContext = new pubsContext())
            {
                var titles = pubsContext.titles
                    .Where(t => t.price > 20.0M)
                    .Select(t => new
                    {
                        title_id = t.title_id,
                        title_name = t.title1,
                        price = t.price,
                        pub_name = t.pub.pub_name
                    });

                foreach (var t in titles) { Console.WriteLine(t); }
            }

            // リレーション2
            using (var pubsContext = new pubsContext())
            {
                var pubs = pubsContext.publishers
                    .Where(p => p.country == "USA")
                    .Select(p => new
                    {
                        pub_id = p.pub_id,
                        pub_name = p.pub_name, 
                        titleCount = p.titles.Count,
                    });

                foreach (var p in pubs ) { Console.WriteLine(p); }
            }
        }

        /// <summary>
        /// 並び替え
        /// </summary>
        public void Order()
        {
            using (var pubs = new pubsContext())
            {
                var authors = pubs.authors.OrderBy(x => x.state).ThenBy(x => x.phone);
                foreach (var a in authors) { Console.WriteLine($"{a.au_id}, {a.state}, {a.phone}"); }
            }
        }

        /// <summary>
        /// 集計
        /// </summary>
        public void Totalling ()
        {
            using (var pubs = new pubsContext())
            {
                // 単一集計
                Console.WriteLine(pubs.authors.Where(x => x.state == "CA").Count());
                Console.WriteLine(pubs.titles.Average(x => x.price));
                Console.WriteLine(pubs.titles.Sum(x => x.price));

                // グループ集計
                var averagePriceList = pubs.publishers.Select(p => new
                {
                    p.pub_id,
                    p.pub_name,
                    averagePrice = p.titles.Average(t => t.price)
                });

                foreach (var a in averagePriceList) { Console.WriteLine(a); }
            }
        }

        /// <summary>
        /// 読み飛ばし
        /// </summary>
        public void Skip()
        {
            using (var pubs = new pubsContext())
            {
                foreach (var item in pubs.authors.OrderBy(x => x.au_id).Skip(2).Take(3))
                {
                    Console.WriteLine($"{item.au_id}, {item.au_fname} ");
                }
            }

        }

        /// <summary>
        /// グループ化
        /// </summary>
        public void Group()
        {
            using (var pubx = new pubsContext())
            {
                var groups = pubx.authors.GroupBy(x => x.state).Select(g => new
                {
                    state = g.Key,
                    count = g.Count()
                });

                foreach (var g in groups) { Console.WriteLine(g); }
            }
        }

    }
}
