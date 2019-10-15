using System;
using System.Collections.Generic;
using System.Linq;

namespace 第11章LINQ
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public Racer(string firstName, string lastName, string country, int starts, int wins)
            : this(firstName, lastName, country, starts, wins, null, null)
        {

        }
        public Racer(string firstName, string lastName, string country, int starts, int wins,IEnumerable<int> years,IEnumerable<string> cars)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Starts = starts;
            this.Wins = wins;
            this.Years = new List<int>(years);
            this.Cars = new List<string>(cars);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; }
        public int Starts { get; set; }
        public IEnumerable<string> Cars { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public override string ToString()
        {
            return String.Format("{0} {1}",FirstName,LastName);
        }
        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            return string.Compare(this.LastName, other.LastName);
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public string ToString(string format,IFormatProvider formatProvider)
        {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Starts.ToString();
                case "W":
                    return Wins.ToString();
                case "A":
                    return String.Format("{0} {1}, {2}; starts: {3}, wins: {4}",
                          FirstName, LastName, Country, Starts, Wins);
                default:
                    throw new FormatException(string.Format("Format {0} not supported", format));
            }
        }
    }
    public class Team
    {
        public Team(string name,params int[] years)
        {
            this.Name = name;
            this.Years = new List<int>(years);
        }
        public string Name { get; private set; }
        public IEnumerable<int> Years { get; private set; }

    }
    public static class Formulal
    {
        private static List<Racer> racers;
        public static IList<Racer> GetChampions()
        {
            if(racers==null)
            {
                racers = new List<Racer>(40);
                racers.Add(new Racer("Nino", "Farina", "Italy", 33, 5, new int[] { 1950 }, new string[] { "Alfa Romeo" }));
                racers.Add(new Racer("Alberto", "Ascari", "Italy", 32, 10, new int[] { 1952, 1953 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Juan Manuel", "Fangio", "Argentina", 51, 24, new int[] { 1951, 1954, 1955, 1956, 1957 }, new string[] { "Alfa Romeo", "Maserati", "Mercedes", "Ferrari" }));
                racers.Add(new Racer("Mike", "Hawthorn", "UK", 45, 3, new int[] { 1958 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("John", "Surtees", "UK", 111, 6, new int[] { 1964 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Jim", "Clark", "UK", 72, 25, new int[] { 1963, 1965 }, new string[] { "Lotus" }));
                racers.Add(new Racer("Jack", "Brabham", "Australia", 125, 14, new int[] { 1959, 1960, 1966 }, new string[] { "Cooper", "Brabham" }));
                racers.Add(new Racer("Denny", "Hulme", "New Zealand", 112, 8, new int[] { 1967 }, new string[] { "Brabham" }));
                racers.Add(new Racer("Graham", "Hill", "UK", 176, 14, new int[] { 1962, 1968 }, new string[] { "BRM", "Lotus" }));
                racers.Add(new Racer("Jochen", "Rindt", "Austria", 60, 6, new int[] { 1970 }, new string[] { "Lotus" }));
                racers.Add(new Racer("Jackie", "Stewart", "UK", 99, 27, new int[] { 1969, 1971, 1973 }, new string[] { "Matra", "Tyrrell" }));
                racers.Add(new Racer("Emerson", "Fittipaldi", "Brazil", 143, 14, new int[] { 1972, 1974 }, new string[] { "Lotus", "McLaren" }));
                racers.Add(new Racer("James", "Hunt", "UK", 91, 10, new int[] { 1976 }, new string[] { "McLaren" }));
                racers.Add(new Racer("Mario", "Andretti", "USA", 128, 12, new int[] { 1978 }, new string[] { "Lotus" }));
                racers.Add(new Racer("Jody", "Scheckter", "South Africa", 112, 10, new int[] { 1979 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Alan", "Jones", "Australia", 115, 12, new int[] { 1980 }, new string[] { "Williams" }));
                racers.Add(new Racer("Keke", "Rosberg", "Finland", 114, 5, new int[] { 1982 }, new string[] { "Williams" }));
                racers.Add(new Racer("Niki", "Lauda", "Austria", 173, 25, new int[] { 1975, 1977, 1984 }, new string[] { "Ferrari", "McLaren" }));
                racers.Add(new Racer("Nelson", "Piquet", "Brazil", 204, 23, new int[] { 1981, 1983, 1987 }, new string[] { "Brabham", "Williams" }));
                racers.Add(new Racer("Ayrton", "Senna", "Brazil", 161, 41, new int[] { 1988, 1990, 1991 }, new string[] { "McLaren" }));
                racers.Add(new Racer("Nigel", "Mansell", "UK", 187, 31, new int[] { 1992 }, new string[] { "Williams" }));
                racers.Add(new Racer("Alain", "Prost", "France", 197, 51, new int[] { 1985, 1986, 1989, 1993 }, new string[] { "McLaren", "Williams" }));
                racers.Add(new Racer("Damon", "Hill", "UK", 114, 22, new int[] { 1996 }, new string[] { "Williams" }));
                racers.Add(new Racer("Jacques", "Villeneuve", "Canada", 165, 11, new int[] { 1997 }, new string[] { "Williams" }));
                racers.Add(new Racer("Mika", "Hakkinen", "Finland", 160, 20, new int[] { 1998, 1999 }, new string[] { "McLaren" }));
                racers.Add(new Racer("Michael", "Schumacher", "Germany", 287, 91, new int[] { 1994, 1995, 2000, 2001, 2002, 2003, 2004 }, new string[] { "Benetton", "Ferrari" }));
                racers.Add(new Racer("Fernando", "Alonso", "Spain", 177, 27, new int[] { 2005, 2006 }, new string[] { "Renault" }));
                racers.Add(new Racer("Kimi", "Räikkönen", "Finland", 148, 17, new int[] { 2007 }, new string[] { "Ferrari" }));
                racers.Add(new Racer("Lewis", "Hamilton", "UK", 90, 17, new int[] { 2008 }, new string[] { "McLaren" }));
                racers.Add(new Racer("Jenson", "Button", "UK", 208, 12, new int[] { 2009 }, new string[] { "Brawn GP" }));
                racers.Add(new Racer("Sebastian", "Vettel", "Germany", 81, 21, new int[] { 2010, 2011 }, new string[] { "Red Bull Racing" }));
            }
            return racers;
        }
    }
    public static class StringExtension
    {
        public static void Foo(this string s)//扩展方法，第一个参数要使用this关键字
        {
            Console.WriteLine("F00 invoked for {0}", s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinqQuery();
            Console.WriteLine();
            string s = "Hello";
            s.Foo();
            StringExtension.Foo(s);
            Console.WriteLine();
            ExtensionMethods();
            Console.WriteLine();
            DeferredQuery();
            Console.WriteLine();
            var racers = from r in Formulal.GetChampions()
                         where r.Wins > 15 &&
                         (r.Country == "Brazil" || r.Country == "Austria")
                         select r;
            var Racers = Formulal.GetChampions().
                Where(R => R.Wins > 15 && (R.Country == "Brazil" || R.Country == "Austria")).
                Select(R => R);
            Console.WriteLine("方法1：LINQ查询语法完成");
            foreach (var r in racers)
            {
                Console.WriteLine("{0:A}", r);
            }
            Console.WriteLine();
            Console.WriteLine("方法2：扩展方法Where（）和Select（）完成：");
            foreach (var R in Racers)
            {
                Console.WriteLine("{0:A}", R);
            }

            Console.WriteLine();
            var racer = Formulal.GetChampions().
                Where((r, index) => r.LastName.StartsWith("A") && index % 2 != 0);
            foreach (var r in racer)
            {
                Console.WriteLine("{0:A}", r);
            }

            Console.WriteLine();
            object[] data = { "one", 2, 3, "four", "five", 6 };
            var query = data.OfType<string>();
            foreach (var S in query)
            {
                Console.WriteLine(S);
            }

            Console.WriteLine();
            Console.WriteLine("方法1：使用复合的from子句");
            var ferrariDrivers = from r in Formulal.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r.FirstName + " " + r.LastName;
            foreach (var d in ferrariDrivers)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine();
            Console.WriteLine("方法二：把复合的from字句和LINQ查询转换为SelectMany（）扩展方法");
            var FerrariDrivers = Formulal.GetChampions().
                SelectMany(r => r.Cars,
                (r, c) => new { Racer = r, car = c }).
                Where(r => r.car == "Ferrari").
                OrderBy(r => r.Racer.LastName).
                Select(r => r.Racer.FirstName + " " + r.Racer.LastName);
            foreach (var d in ferrariDrivers)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine();
            Console.WriteLine("方法1：");
            var paixu = (from r in Formulal.GetChampions()
                         orderby r.Country, r.LastName, r.FirstName
                         select r).Take(10);
            foreach (var r in paixu)
            {
                Console.WriteLine(r.Country + ":" + r.LastName + "," + r.FirstName);
            }
            Console.WriteLine();
            Console.WriteLine("方法2：");
            var Paixu = Formulal.GetChampions().
                OrderBy(r => r.Country).
                ThenBy(r => r.LastName).
                ThenBy(r => r.FirstName).
                Take(10);
            foreach (var r in paixu)
            {
                Console.WriteLine(r.Country + ":" + r.LastName + "," + r.FirstName);
            }

            Console.WriteLine();
            Console.WriteLine("方法1：");
            var countries = from r in Formulal.GetChampions()
                            group r by r.Country into g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count()
                            };
            foreach (var item in countries)
            {
                Console.WriteLine("{0, -10} {1}", item.Country, item.Count);
            }
            Console.WriteLine();
            Console.WriteLine("方法2：");
            var Countries = Formulal.GetChampions().
                GroupBy(r => r.Country).
                OrderByDescending(g => g.Count()).
                ThenBy(g => g.Key).
                Where(g => g.Count() >= 2).
                Select(g => new {Country= g.Key, Count = g.Count()});
            foreach (var item in Countries)
            {
                Console.WriteLine("{0, -10} {1}", item.Country, item.Count);
            }
        }
        private static void LinqQuery()
        {
            var query = from r in Formulal.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;
            foreach(Racer r in query)
            {
                Console.WriteLine("{0:A}", r);
            }

        }
        static void ExtensionMethods()
        {
            var champions = new List<Racer>(Formulal.GetChampions());
            IEnumerable<Racer> brazilChampions =
                champions.Where(r => r.Country == "Brazil").
                OrderByDescending(r => r.Wins).
                Select(r => r);
            foreach(Racer r in brazilChampions)
            {
                Console.WriteLine("{0:A}", r);
            }   
        }
        static void DeferredQuery()
        {
            var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };
            var namesWithJ=from n in names
                           where n.StartsWith("J")
                           orderby n
                           select n;
            /*var namesWithJ = (from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n).ToList();*///保持两次迭代之间输出不变，改变集合中的值
            Console.WriteLine("第一次迭代： ");
            foreach(string name in namesWithJ)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            names.Add("John");
            names.Add("Jim");
            names.Add("Jack");
            names.Add("Denny");
            Console.WriteLine("第二次迭代： ");
            foreach (string name in namesWithJ)
            {
                Console.WriteLine(name);
            }

        }
    }
}
