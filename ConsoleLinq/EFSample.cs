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
            Console.WriteLine("____フィルタリング処理");
            using (var pubsContext = new pubsContext())
            {
                var authors = pubsContext.authors
                    .Where(x => x.state == "CA" && x.contract == true)
                    //.Where(x => x.au_fname.Length == 5)
                    .Where(x => x.au_fname.EndsWith("e"));

                foreach (var author in authors) { Console.WriteLine(author); }
            }

            Console.WriteLine("____日付の範囲チェック");
            using (var nwContext = new northwindContext())
            {
                var orders = nwContext.Orders
                    .Where(x => x.OrderDate >= DateTime.Parse("1996/7/1")
                             && x.OrderDate < DateTime.Parse("1996/8/1"))
                    .Select(x => x);

                foreach (var order in orders) { Console.WriteLine($"{order.OrderID},{order.OrderDate}"); }
            }
        }

        /// <summary>
        /// 射影
        /// </summary>
        public void Select()
        {
            Console.WriteLine("____射影");
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
            Console.WriteLine("____リレーション1");
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


            Console.WriteLine("____リレーション2");
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

                foreach (var p in pubs) { Console.WriteLine(p); }
            }
        }

        /// <summary>
        /// 並び替え
        /// </summary>
        public void Order()
        {
            Console.WriteLine("____並び替え");
            using (var pubs = new pubsContext())
            {
                var authors = pubs.authors.OrderBy(x => x.state).ThenBy(x => x.phone);
                foreach (var a in authors) { Console.WriteLine($"{a.au_id}, {a.state}, {a.phone}"); }
            }
        }

        /// <summary>
        /// 集計
        /// </summary>
        public void Totalling()
        {
            using (var pubs = new pubsContext())
            {
                Console.WriteLine("____単一集計");
                Console.WriteLine(pubs.authors.Where(x => x.state == "CA").Count());
                Console.WriteLine(pubs.titles.Average(x => x.price));
                Console.WriteLine(pubs.titles.Sum(x => x.price));


                Console.WriteLine("____グループ集計");
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
            Console.WriteLine("____読み飛ばし");
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
            using (var pubs = new pubsContext())
            {
                Console.WriteLine("____グループ化");
                var groups = pubs.authors.GroupBy(x => x.state).Select(g => new
                {
                    state = g.Key,
                    count = g.Count(),

                });

                foreach (var g in groups) { Console.WriteLine(g); }


                Console.WriteLine("____様々なグループ化1");
                var titlesByPubs = pubs.titles
                    .GroupBy(t => t.pub_id)
                    .Select(g => new
                    {
                        pub_id = g.Key,
                        titles = g.Select(x => x)
                    });

                foreach (var p in titlesByPubs)
                {
                    Console.WriteLine($"{p.pub_id}");
                    foreach (var title in p.titles)
                    {
                        Console.WriteLine($"{title.pub_id}, {title.title_id}, {title.title1}, {title.price}");
                    }
                }


                Console.WriteLine("____様々なグループ化2");
                var avePrices = pubs.titles.GroupBy(t => t.pub_id).Select(g => new
                {
                    pub_id = g.Key,
                    averagePrice = g.Average(x => x.price)
                });

                foreach (var p in avePrices)
                {
                    Console.WriteLine($"{p.pub_id}, {p.averagePrice}");
                }


                Console.WriteLine("____複合キーによるグループ化");
                var authors = pubs.authors
                    .GroupBy(a => new { a.state, a.contract })
                    .OrderBy(g => g.Key.state)
                    .ThenBy(g => g.Key.contract)
                    .Select(g => new
                    {
                        state = g.Key.state,
                        contract = g.Key.contract,
                        count = g.Count()
                    });

                foreach (var a in authors)
                {
                    Console.WriteLine($"{a.state}, {a.contract}, {a.count}");
                }

            }
        }

        /// <summary>
        /// 内部結合
        /// </summary>
        public void Join()
        {
            using (var pubs = new pubsContext())
            {
                Console.WriteLine("____リレーションがあればJOINは不要");
                var titles = pubs.titles
                    .Where(x => x.price > 20)
                    .Select(t => new {
                            t.title_id,
                            t.title1,
                            t.price,
                            pub_name = t.pub.pub_name
                        });

                foreach (var t in titles) { Console.WriteLine(t); }


                Console.WriteLine("____JOIN");
                var avePrices = pubs.titles
                    .GroupBy(t => t.pub_id)
                    .Select(g => new
                    {
                        pub_id = g.Key,
                        avePrice = g.Average(x => x.price!.Value)
                    })
                    .Join(pubs.publishers,
                        o => o.pub_id,  // < 
                        p => p.pub_id,  // < JOINの引数のpubs.publishers
                        (o, p) => new {
                                o.pub_id,
                                o.avePrice,
                                p.pub_name
                            });

                foreach (var ap in avePrices) { Console.WriteLine(ap); }


                Console.WriteLine("____JOIN-集計1");
                var storeSales = pubs.sales
                    .Select(s => new
                    {
                        s.stor_id,
                        subtotal = s.qty * s.title.price
                    })
                    .GroupBy(s => s.stor_id)
                    .Select(g => new
                    {
                        store_id = g.Key,
                        totalSale = g.Sum(x => x.subtotal)
                    })
                    .Join(pubs.stores,
                        sl => sl.store_id,
                        st => st.stor_id,
                        (sl, st) => new
                        {
                            sl.store_id,
                            st.stor_name,
                            sl.totalSale
                        });

                foreach (var ss in storeSales) { Console.WriteLine(ss); }


                Console.WriteLine("____JOIN-集計2");
                var storeSales2 = pubs.sales
                    .GroupBy(sl => sl.stor_id)
                    .Select(g => new
                    {
                        store_id = g.Key,
                        totalSale = g.Sum(x => x.qty * x.title.price)
                    })
                    .Join(pubs.stores,
                        sl => sl.store_id,
                        st => st.stor_id,
                        (sl, st) => new
                        {
                            sl.store_id,
                            st.stor_name,
                            sl.totalSale
                        });

                foreach (var ss2 in storeSales2) { Console.WriteLine(ss2); }


                Console.WriteLine("____JOIN-集計3");
                var storeSales3 = pubs.stores
                    .Select(st => new
                    {
                        st.stor_id,
                        st.stor_name,
                        totalSale = st.sales.Sum(x => x.qty * x.title.price)
                    });

                foreach (var ss3 in storeSales3) { Console.WriteLine(ss3); }
            }
        }

        /// <summary>
        /// グループ化結合
        /// </summary>
        public void GroupJoin()
        {
            using (var nw = new northwindContext())
            {
                Console.WriteLine("____GroupJoin1");
                var ordersWithDetails = nw.Orders
                    .GroupJoin(nw.Order_Details,
                        o => o.OrderID,
                        od => od.OrderID,
                        (o, g) => new           // < グループ化したものに突き合わせる
                        {
                            OrderID = o.OrderID,
                            OrderDate = o.OrderDate,
                            OrderCount = g.Count(),
                            OrderDetails = g
                        }
                    );

                foreach (var o in ordersWithDetails)
                {
                    Console.WriteLine($"{o.OrderID}, {o.OrderDate}, {o.OrderCount}");
                    foreach (var od in o.OrderDetails)
                    {
                        Console.WriteLine($"{od.ProductID}, {od.Quantity}");
                    }
                }


                Console.WriteLine("____GroupJoin2");
                var ordersWithDetails2 = nw.Orders
                    .Select(s => new
                    {
                        OrderID = s.OrderID,
                        OrderDate = s.OrderDate,
                        OrderCount = s.Order_Details.Count(),
                        OrderDetails = s.Order_Details
                    });

                foreach (var o in ordersWithDetails2)
                {
                    Console.WriteLine($"{o.OrderID}, {o.OrderDate}, {o.OrderCount}");
                    foreach (var od in o.OrderDetails)
                    {
                        Console.WriteLine($"{od.ProductID}, {od.Quantity}");
                    }
                }

            }


            using (var pubs = new pubsContext())
            {
                Console.WriteLine("____外部結合(LINQ-to-SQL)");
                var titles = pubs.titles
                    .Select(x => new
                    {
                        x.title_id,
                        x.title1,
                        x.price,
                        x.pub_id,
                        pub_name = x.pub.pub_name
                    });

                foreach (var t in titles) { Console.WriteLine(t); }



                Console.WriteLine("____外部結合(GroupJoin)");
                var titles2 = pubs.titles
                    .GroupJoin(
                        pubs.publishers,
                        t => t.pub_id,
                        p => p.pub_id,
                        (t, g) => new
                        { temp1 = t, temp2 = g })
                    .SelectMany(
                        o => o.temp2.DefaultIfEmpty(),
                        (x, p2) => new
                        {
                            title_id = x.temp1.title_id,
                            title_name = x.temp1.title1,
                            price = x.temp1.price,
                            pub_name = (p2 != null ? p2.pub_name : null)
                        });

                foreach (var t in titles) { Console.WriteLine(t); }

            }

        }

    }
}
