using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var db = new BloggingContext())
            {
                // create
                db.Add(new Blog() { Url = "http://blos.msdn.com/adonet" });
                db.SaveChanges();

                // read
                var blog = db.Blogs.OrderBy(a => a.BlogId).First();
                Console.WriteLine(blog.Url);

                // update
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(new Post { Title="hello world", Content = "i wrote an app using EF Core."});
                db.SaveChanges();
                Console.WriteLine(blog.Url);

                //delete 
                db.Remove(blog);
                db.SaveChanges();

            }
            Console.WriteLine("any key to exit...");
            Console.ReadLine();
        }
    }
}
