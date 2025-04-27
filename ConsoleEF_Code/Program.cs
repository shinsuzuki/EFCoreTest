using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Data.Common;
using System.Runtime.Serialization;
using Microsoft.Data.SqlClient;

namespace ConsoleEF_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("________efcore start\n");

            // 取得
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


            // 更新、削除、追加（SaveChanges）
            var opeFlag1 = false;
            using (var pubs = new PubsDbContext())
            {
                if (opeFlag1)
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
                        // SaveChangesが失敗した場合はロールバックされる
                        Console.WriteLine(ex.ToString());
                    }
                }
            }


            // 更新、削除、追加（トランザクション）
            var opeFlag = false;
            using (var pubs = new PubsDbContext())
            {
                if (opeFlag)
                {

                    using (var tran = pubs.Database.BeginTransaction())
                    {
                        try
                        {

                            Console.WriteLine("____データを更新（単）");
                            var a1 = pubs.Authors.Where(x => x.au_id == "172-32-1176").FirstOrDefault();
                            if (a1 != null)
                            {
                                a1.au_lname = a1.au_lname + "_add";
                            }
                            pubs.SaveChanges();


                            Console.WriteLine("____データを削除（単）");
                            var a2 = pubs.Authors.Where(x => x.au_id == "213-46-8915").FirstOrDefault();
                            if (a2 != null)
                            {
                                pubs.Authors.Remove(a2);
                            }
                            pubs.SaveChanges();

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
                            pubs.SaveChanges();

                            // すべてのコマンドが成功した場合、トランザクションをコミットする。
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }


            // 複数県の更新、削除
            var opeFlag2 = false;
            using (var pubs = new PubsDbContext())
            {
                if (opeFlag2)
                {
                    // 
                    using (var tran = pubs.Database.BeginTransaction())
                    {
                        // 複数の場合はトランザクションが必要
                        try
                        {
                            // データ一括更新
                            pubs.Titles.Where(x => x.type == "business").ExecuteUpdate(s => s.SetProperty(title => title.price, title => title.price + 3));

                            // データ一括削除
                            pubs.Titles.Where(x => x.type == "UNDECIDED").ExecuteDelete();

                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();   
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }


            // FromSql
            using (var pubs = new PubsDbContext())
            {
                Console.WriteLine("____FromSql:文字列補完");
                var state = "CA";
                var contract = true;
                var q1 = pubs.Authors.FromSql<Author>($"select * from authors where state={state} and contract={contract}");

                foreach (var item in q1.ToList())
                {
                    Console.WriteLine(item.au_fname + item.au_fname);
                }


                Console.WriteLine("____FromSqlRaw:パラメータ");
                var sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@state", "CA"));
                sqlParameters.Add(new SqlParameter("@contract", true));

                var q2 = pubs.Authors.FromSqlRaw<Author>($"select * from authors where state=@state and contract=@contract", sqlParameters.ToArray());
                foreach (var item in q2.ToList())
                {
                    Console.WriteLine(item.au_fname + item.au_fname);
                }
            }


            Console.WriteLine("\n________efcore end");
            Console.Write("press any key to exit...");
            Console.ReadLine();
        }
    }
}
