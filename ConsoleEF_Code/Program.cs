using Microsoft.EntityFrameworkCore;

namespace ConsoleEF_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("________efcore start\n");

            using (var pubs = new PubsDbContext())
            {
                Console.WriteLine("____複数件取得");
                var q1 = from a in pubs.Stores where a.state == "CA" select a;

                foreach (var store in q1.ToList())
                {
                    Console.WriteLine(store.stor_name);
                }

                Console.WriteLine("____1件取得");
                var q2 = (from a in pubs.Stores where a.stor_id == "6380" select a.stor_name).FirstOrDefault();
                Console.WriteLine(q2);

                Console.WriteLine("____射影");
                var q3 = (from a in pubs.Stores where a.state == "CA" 
                            select new StoresOverView { 
                                state = a.state,
                                stor_name = a.stor_name
                            }).ToList();

                foreach (var store in q3.ToList())
                {
                    Console.WriteLine( $"{store.state}:{store.stor_name}");
                }

                Console.WriteLine("____JOIN");
                var q4 = from a in pubs.Stores
                         join b in pubs.Sales on a.stor_id equals b.stor_id
                         where a.state == "CA"
                         select new StoresOverView
                         {
                             state = a.state,
                             stor_name = a.stor_name,
                             qty = b.qty
                         };

                foreach (var store in q4.ToList())
                {
                    Console.WriteLine($"{store.state}:{store.qty}:{store.stor_name}");
                }
            }

            var opeFlag = false;
            using (var pubs = new PubsDbContext())
            {
                if (opeFlag)
                {

                    Console.WriteLine("____データを更新（単）");
                    var a1 = pubs.Authors.Where(x => x.au_id == "172-32-1176").FirstOrDefault();
                    if (a1 != null)
                    {
                        a1.au_lname = a1.au_lname + "_add";
                    }

                    Console.WriteLine("____データを削除（単）");
                    var a2 = pubs.Authors.Where(x => x.au_id == "213-46-8915").FirstOrDefault();
                    if (a2 != null)
                    {
                        pubs.Authors.Remove(a2);
                    }

                    Console.WriteLine("____データを追加（単）");
                    pubs.Authors.Add(
                        new Author
                        {
                            au_id = "123-45-6789",
                            au_lname = "test",
                            au_fname = "test",
                            phone = "1234567890",
                            address = "test",
                            city = "test",
                            state = "CA",
                            zip = "12345",
                            bit = true
                        });

                    try
                    {
                        pubs.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }


            Console.WriteLine("\n________efcore end");
            Console.Write("press any key to exit...");
            Console.ReadLine();
        }
    }
}
