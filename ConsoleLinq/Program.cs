namespace ConsoleLinq
{

    public class Person
    {
        public string Name { get; set; }
        public int Age{ get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Person> persons = new List<Person>() {
            //    new Person{ Name = "sato2", Age=20 },
            //    new Person{ Name = "sato3", Age=30 },
            //    new Person{ Name = "sato4", Age=40 },
            //    new Person{ Name = "sato5", Age=50 },
            //};

            //// average
            //Console.WriteLine("____average");
            //Console.WriteLine(persons.Average(x => x.Age));

            //// where
            //Console.WriteLine("____where");
            //foreach (var person in persons.Where(x => x.Age > 30)) 
            //{
            //    Console.WriteLine($"{person.Name},{person.Age}");
            //}

            //// select
            //Console.WriteLine("____select");
            //var newPerson =persons.Select(x => new
            //{
            //    Name = x.Name + "_add",
            //    Age = x.Age + 100,
            //});
            //foreach (var person in newPerson)
            //{
            //    Console.WriteLine($"{person.Name},{person.Age}");
            //}


            var s = new EFSample();
            //s.SelectTest();
            //s.Where();
            //s.Select();
            //s.Relation();
            //s.Order();
            //s.Totalling();
            //s.Skip();
            s.Group();



            Console.WriteLine("\r\n____end____");
            Console.ReadLine();
        }
    }
}
