using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

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
        private static List<Team> teams;
        public static IList<Team> GetContructorChampions()
        {
            if (teams == null)
            {
                teams = new List<Team>()
                {
                    new Team("Vanwall", 1958),
                    new Team("Cooper", 1959, 1960),
                    new Team("Ferrari", 1961, 1964, 1975, 1976, 1977, 1979, 1982, 1983, 1999, 2000, 2001, 2002, 2003, 2004, 2007, 2008),
                    new Team("BRM", 1962),
                    new Team("Lotus", 1963, 1965, 1968, 1970, 1972, 1973, 1978),
                    new Team("Brabham", 1966, 1967),
                    new Team("Matra", 1969),
                    new Team("Tyrrell", 1971),
                    new Team("McLaren", 1974, 1984, 1985, 1988, 1989, 1990, 1991, 1998),
                    new Team("Williams", 1980, 1981, 1986, 1987, 1992, 1993, 1994, 1996, 1997),
                    new Team("Benetton", 1995),
                    new Team("Renault", 2005, 2006 ),
                    new Team("Brawn GP", 2009),
                    new Team("Red Bull Racing", 2010, 2011)
                };
            }
            return teams;
        }

        private static List<Championship> championships;
        public static IEnumerable<Championship> GetChampionships()
        {
            if (championships == null)
            {
                championships = new List<Championship>();
                championships.Add(new Championship
                {
                    Year = 1950,
                    First = "Nino Farina",
                    Second = "Juan Manuel Fangio",
                    Third = "Luigi Fagioli"
                });
                championships.Add(new Championship
                {
                    Year = 1951,
                    First = "Juan Manuel Fangio",
                    Second = "Alberto Ascari",
                    Third = "Froilan Gonzalez"
                });
                championships.Add(new Championship
                {
                    Year = 1952,
                    First = "Alberto Ascari",
                    Second = "Nino Farina",
                    Third = "Piero Taruffi"
                });
                championships.Add(new Championship
                {
                    Year = 1953,
                    First = "Alberto Ascari",
                    Second = "Juan Manuel Fangio",
                    Third = "Nino Farina"
                });
                championships.Add(new Championship
                {
                    Year = 1954,
                    First = "Juan Manuel Fangio",
                    Second = "Froilan Gonzalez",
                    Third = "Mike Hawthorn"
                });
                championships.Add(new Championship
                {
                    Year = 1955,
                    First = "Juan Manuel Fangio",
                    Second = "Stirling Moss",
                    Third = "Eugenio Castellotti"
                });
                championships.Add(new Championship
                {
                    Year = 1956,
                    First = "Juan Manuel Fangio",
                    Second = "Stirling Moss",
                    Third = "Peter Collins"
                });
                championships.Add(new Championship
                {
                    Year = 1957,
                    First = "Juan Manuel Fangio",
                    Second = "Stirling Moss",
                    Third = "Luigi Musso"
                });
                championships.Add(new Championship
                {
                    Year = 1958,
                    First = "Mike Hawthorn",
                    Second = "Stirling Moss",
                    Third = "Tony Brooks"
                });
                championships.Add(new Championship
                {
                    Year = 1959,
                    First = "Jack Brabham",
                    Second = "Tony Brooks",
                    Third = "Stirling Moss"
                });
                championships.Add(new Championship
                {
                    Year = 1960,
                    First = "Jack Brabham",
                    Second = "Bruce McLaren",
                    Third = "Stirling Moss"
                });
                championships.Add(new Championship
                {
                    Year = 1961,
                    First = "Phil Hill",
                    Second = "Wolfgang von Trips",
                    Third = "Stirling Moss"
                });
                championships.Add(new Championship
                {
                    Year = 1962,
                    First = "Graham Hill",
                    Second = "Jim Clark",
                    Third = "Bruce McLaren"
                });
                championships.Add(new Championship
                {
                    Year = 1963,
                    First = "Jim Clark",
                    Second = "Graham Hill",
                    Third = "Richie Ginther"
                });
                championships.Add(new Championship
                {
                    Year = 1964,
                    First = "John Surtees",
                    Second = "Graham Hill",
                    Third = "Jim Clark"
                });
                championships.Add(new Championship
                {
                    Year = 1965,
                    First = "Jim Clark",
                    Second = "Graham Hill",
                    Third = "Jackie Stewart"
                });
                championships.Add(new Championship
                {
                    Year = 1966,
                    First = "Jack Brabham",
                    Second = "John Surtees",
                    Third = "Jochen Rindt"
                });
                championships.Add(new Championship
                {
                    Year = 1967,
                    First = "Dennis Hulme",
                    Second = "Jack Brabham",
                    Third = "Jim Clark"
                });
                championships.Add(new Championship
                {
                    Year = 1968,
                    First = "Graham Hill",
                    Second = "Jackie Stewart",
                    Third = "Dennis Hulme"
                });
                championships.Add(new Championship
                {
                    Year = 1969,
                    First = "Jackie Stewart",
                    Second = "Jackie Ickx",
                    Third = "Bruce McLaren"
                });
                championships.Add(new Championship
                {
                    Year = 1970,
                    First = "Jochen Rindt",
                    Second = "Jackie Ickx",
                    Third = "Clay Regazzoni"
                });
                championships.Add(new Championship
                {
                    Year = 1971,
                    First = "Jackie Stewart",
                    Second = "Ronnie Peterson",
                    Third = "Francois Cevert"
                });
                championships.Add(new Championship
                {
                    Year = 1972,
                    First = "Emerson Fittipaldi",
                    Second = "Jackie Stewart",
                    Third = "Dennis Hulme"
                });
                championships.Add(new Championship
                {
                    Year = 1973,
                    First = "Jackie Stewart",
                    Second = "Emerson Fittipaldi",
                    Third = "Ronnie Peterson"
                });
                championships.Add(new Championship
                {
                    Year = 1974,
                    First = "Emerson Fittipaldi",
                    Second = "Clay Regazzoni",
                    Third = "Jody Scheckter"
                });
                championships.Add(new Championship
                {
                    Year = 1975,
                    First = "Niki Lauda",
                    Second = "Emerson Fittipaldi",
                    Third = "Carlos Reutemann"
                });
                championships.Add(new Championship
                {
                    Year = 1976,
                    First = "James Hunt",
                    Second = "Niki Lauda",
                    Third = "Jody Scheckter"
                });
                championships.Add(new Championship
                {
                    Year = 1977,
                    First = "Niki Lauda",
                    Second = "Jody Scheckter",
                    Third = "Mario Andretti"
                });
                championships.Add(new Championship
                {
                    Year = 1978,
                    First = "Mario Andretti",
                    Second = "Ronnie Peterson",
                    Third = "Carlos Reutemann"
                });
                championships.Add(new Championship
                {
                    Year = 1979,
                    First = "Jody Scheckter",
                    Second = "Gilles Villeneuve",
                    Third = "Alan Jones"
                });
                championships.Add(new Championship
                {
                    Year = 1980,
                    First = "Alan Jones",
                    Second = "Nelson Piquet",
                    Third = "Carlos Reutemann"
                });
                championships.Add(new Championship
                {
                    Year = 1981,
                    First = "Nelson Piquet",
                    Second = "Carlos Reutemann",
                    Third = "Alan Jones"
                });
                championships.Add(new Championship
                {
                    Year = 1982,
                    First = "Keke Rosberg",
                    Second = "Didier Pironi",
                    Third = "John Watson"
                });
                championships.Add(new Championship
                {
                    Year = 1983,
                    First = "Nelson Piquet",
                    Second = "Alain Prost",
                    Third = "Rene Arnoux"
                });
                championships.Add(new Championship
                {
                    Year = 1984,
                    First = "Niki Lauda",
                    Second = "Alain Prost",
                    Third = "Elio de Angelis"
                });
                championships.Add(new Championship
                {
                    Year = 1985,
                    First = "Alain Prost",
                    Second = "Michele Alboreto",
                    Third = "Keke Rosberg"
                });
                championships.Add(new Championship
                {
                    Year = 1986,
                    First = "Alain Prost",
                    Second = "Nigel Mansell",
                    Third = "Nelson Piquet"
                });
                championships.Add(new Championship
                {
                    Year = 1987,
                    First = "Nelson Piquet",
                    Second = "Nigel Mansell",
                    Third = "Ayrton Senna"
                });
                championships.Add(new Championship
                {
                    Year = 1988,
                    First = "Ayrton Senna",
                    Second = "Alain Prost",
                    Third = "Gerhard Berger"
                });
                championships.Add(new Championship
                {
                    Year = 1989,
                    First = "Alain Prost",
                    Second = "Ayrton Senna",
                    Third = "Riccardo Patrese"
                });
                championships.Add(new Championship
                {
                    Year = 1990,
                    First = "Ayrton Senna",
                    Second = "Alain Prost",
                    Third = "Nelson Piquet"
                });
                championships.Add(new Championship
                {
                    Year = 1991,
                    First = "Ayrton Senna",
                    Second = "Nigel Mansell",
                    Third = "Riccardo Patrese"
                });
                championships.Add(new Championship
                {
                    Year = 1992,
                    First = "Nigel Mansell",
                    Second = "Riccardo Patrese",
                    Third = "Michael Schumacher"
                });
                championships.Add(new Championship
                {
                    Year = 1993,
                    First = "Alain Prost",
                    Second = "Ayrton Senna",
                    Third = "Damon Hill"
                });
                championships.Add(new Championship
                {
                    Year = 1994,
                    First = "Michael Schumacher",
                    Second = "Damon Hill",
                    Third = "Gerhard Berger"
                });
                championships.Add(new Championship
                {
                    Year = 1995,
                    First = "Michael Schumacher",
                    Second = "Damon Hill",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 1996,
                    First = "Damon Hill",
                    Second = "Jacques Villeneuve",
                    Third = "Michael Schumacher"
                });
                championships.Add(new Championship
                {
                    Year = 1997,
                    First = "Jacques Villeneuve",
                    Second = "Heinz-Harald Frentzen",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 1998,
                    First = "Mika Hakkinen",
                    Second = "Michael Schumacher",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 1999,
                    First = "Mika Hakkinen",
                    Second = "Eddie Irvine",
                    Third = "Heinz-Harald Frentzen"
                });
                championships.Add(new Championship
                {
                    Year = 2000,
                    First = "Michael Schumacher",
                    Second = "Mika Hakkinen",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 2001,
                    First = "Michael Schumacher",
                    Second = "David Coulthard",
                    Third = "Rubens Barrichello"
                });
                championships.Add(new Championship
                {
                    Year = 2002,
                    First = "Michael Schumacher",
                    Second = "Rubens Barrichello",
                    Third = "Juan Pablo Montoya"
                });
                championships.Add(new Championship
                {
                    Year = 2003,
                    First = "Michael Schumacher",
                    Second = "Kimi Räikkönen",
                    Third = "Juan Pablo Montoya"
                });
                championships.Add(new Championship
                {
                    Year = 2004,
                    First = "Michael Schumacher",
                    Second = "Rubens Barrichello",
                    Third = "Jenson Button"
                });
                championships.Add(new Championship
                {
                    Year = 2005,
                    First = "Fernando Alonso",
                    Second = "Kimi Räikkönen",
                    Third = "Michael Schumacher"
                });
                championships.Add(new Championship
                {
                    Year = 2006,
                    First = "Fernando Alonso",
                    Second = "Michael Schumacher",
                    Third = "Felipe Massa"
                });
                championships.Add(new Championship
                {
                    Year = 2007,
                    First = "Kimi Räikkönen",
                    Second = "Lewis Hamilton",
                    Third = "Fernando Alonso"
                });
                championships.Add(new Championship
                {
                    Year = 2008,
                    First = "Lewis Hamilton",
                    Second = "Felipe Massa",
                    Third = "Kimi Raikkonen"
                });
                championships.Add(new Championship
                {
                    Year = 2009,
                    First = "Jenson Button",
                    Second = "Sebastian Vettel",
                    Third = "Rubens Barrichello"
                });
                championships.Add(new Championship
                {
                    Year = 2010,
                    First = "Sebastian Vettel",
                    Second = "Fernando Alonso",
                    Third = "Mark Webber"
                });
                championships.Add(new Championship
                {
                    Year = 2011,
                    First = "Sebastian Vettel",
                    Second = "Jenson Button",
                    Third = "Mark Webber"
                });
            }
            return championships;
        }


        private static IList<Racer> moreRacers;
        private static IList<Racer> GetMoreRacers()
        {
            if (moreRacers == null)
            {
                moreRacers = new List<Racer>();
                moreRacers.Add(new Racer("Luigi", "Fagioli", "Italy", starts: 7, wins: 1));
                moreRacers.Add(new Racer("Jose Froilan", "Gonzalez", "Argentina", starts: 26, wins: 2));
                moreRacers.Add(new Racer("Piero", "Taruffi", "Italy", starts: 18, wins: 1));
                moreRacers.Add(new Racer("Stirling", "Moss", "UK", starts: 66, wins: 16));
                moreRacers.Add(new Racer("Eugenio", "Castellotti", "Italy", starts: 14, wins: 0));
                moreRacers.Add(new Racer("Peter", "Collins", "UK", starts: 32, wins: 3));
                moreRacers.Add(new Racer("Luigi", "Musso", "Italy", starts: 24, wins: 1));
                moreRacers.Add(new Racer("Tony", "Brooks", "UK", starts: 38, wins: 6));
                moreRacers.Add(new Racer("Bruce", "McLaren", "New Zealand", starts: 100, wins: 4));
                moreRacers.Add(new Racer("Wolfgang von", "Trips", "Germany", starts: 27, wins: 2));
                moreRacers.Add(new Racer("Richie", "Ginther", "USA", starts: 52, wins: 1));
                moreRacers.Add(new Racer("Jackie", "Ickx", "Belgium", starts: 116, wins: 8));
                moreRacers.Add(new Racer("Clay", "Regazzoni", "Switzerland", starts: 132, wins: 5));
                moreRacers.Add(new Racer("Ronnie", "Peterson", "Sweden", starts: 123, wins: 10));
                moreRacers.Add(new Racer("Francois", "Cevert", "France", starts: 46, wins: 1));
                moreRacers.Add(new Racer("Carlos", "Reutemann", "Argentina", starts: 146, wins: 12));
                moreRacers.Add(new Racer("Gilles", "Villeneuve", "Canada", starts: 67, wins: 6));
                moreRacers.Add(new Racer("Didier", "Pironi", "France", starts: 70, wins: 3));
                moreRacers.Add(new Racer("John", "Watson", "UK", starts: 152, wins: 5));
                moreRacers.Add(new Racer("Rene", "Arnoux", "France", starts: 149, wins: 7));
                moreRacers.Add(new Racer("Elio", "de Angelis", "Italy", starts: 108, wins: 2));
                moreRacers.Add(new Racer("Michele", "Alboreto", "Italy", starts: 194, wins: 5));
                moreRacers.Add(new Racer("Gerhard", "Berger", "Austria", starts: 210, wins: 10));
                moreRacers.Add(new Racer("Riccardo", "Patrese", "Italy", starts: 256, wins: 6));
                moreRacers.Add(new Racer("David", "Coulthard", "UK", starts: 246, wins: 13));
                moreRacers.Add(new Racer("Heinz-Harald", "Frentzen", "Germany", starts: 156, wins: 3));
                moreRacers.Add(new Racer("Eddie", "Irvine", "UK", starts: 147, wins: 4));
                moreRacers.Add(new Racer("Rubens", "Barrichello", "Brazil", starts: 322, wins: 11));
                moreRacers.Add(new Racer("Juan Pablo", "Montoya", "Columbia", starts: 94, wins: 7));
                moreRacers.Add(new Racer("Felipe", "Massa", "Brazil", starts: 152, wins: 11));
                moreRacers.Add(new Racer("Mark", "Webber", "Australia", starts: 176, wins: 7));
            }
            return moreRacers;
        }
    }
    public static class StringExtension
    {
        public static void Foo(this string s)//扩展方法，第一个参数要使用this关键字
        {
            Console.WriteLine("F00 invoked for {0}", s);
        }
        public static string FirstName(this string name)
        {
            int ix = name.LastIndexOf(' ');
            return name.Substring(0, ix);
        }
        public static string LastName(this string name)
        {
            int ix = name.LastIndexOf(' ');
            return name.Substring(ix+1);
        }
    }
    public class Championship
    {
        public int Year { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
    }
    public class RacerInfo
    {
        public int Year { get; set; }
        public int Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
                Select(g => new { Country = g.Key, Count = g.Count() });
            foreach (var item in Countries)
            {
                Console.WriteLine("{0, -10} {1}", item.Country, item.Count);
            }

            Console.WriteLine();
            var country = from r in Formulal.GetChampions()
                          group r by r.Country into g
                          orderby g.Count() descending, g.Key
                          where g.Count() >= 2
                          select new
                          {
                              Country = g.Key,
                              Count = g.Count(),
                              Racers = from r1 in g
                                       orderby r1.LastName
                                       select r1.FirstName + " " + r1.LastName
                          };
            foreach (var item in country)
            {
                Console.WriteLine("{0, -10} {1}", item.Country, item.Count);
                foreach (var name in item.Racers)
                {
                    Console.Write("{0}; ", name);
                }
                Console.WriteLine();
            }
            //11.2.8 左外链接
            Console.WriteLine();
            var cheshou = from r in Formulal.GetChampions()
                          from y in r.Years
                          select new
                          {
                              Year = y,
                              Name = r.FirstName + " " + r.LastName
                          };

            var teams = from t in Formulal.GetContructorChampions()
                        from y in t.Years
                        select new
                        {
                            Year = y,
                            Name = t.Name
                        };
            var racersAndTeams =
                  (from r in cheshou
                   join t in teams on r.Year equals t.Year
                   select new
                   {
                       r.Year,
                       Champion = r.Name,
                       Constructor = t.Name
                   }).Take(10);
            Console.WriteLine("Year  World Champion\t   Constructor Title");
            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0}: {1,-20} {2}",
                   item.Year, item.Champion, item.Constructor);
            }
            //11.2.9 左外连接(返回左边序列中的全部元素，即使他们在右边的序列中并没有匹配的元素，左外连接用join子句和DefaultIfEmpty方法定义，如果查询的左侧（赛车手）没有匹配的车队冠军，那么久使用DefaultIfEmpty方法定义其右侧的默认值)
            Console.WriteLine();
            var RacersAndTeams =
                (from r in cheshou
                 join t in teams on r.Year equals t.Year into rt
                 from t in rt.DefaultIfEmpty()
                 orderby r.Year
                 select new
                 {
                     Year = r.Year,
                     Champion = r.Name,
                     Constructor = t == null ? "no constructor championship" : t.Name
                 }).Take(10);
            foreach (var item in RacersAndTeams)
            {
                Console.WriteLine("{0}: {1,-20} {2}",
                   item.Year, item.Champion, item.Constructor);
            }




            Console.WriteLine();
            Conect();
            Console.WriteLine();
            //Jihe();
            Console.WriteLine();
            SetOperations();
            Console.WriteLine();
            ZipOperation();
            Console.WriteLine();
            Fenqu();
            Console.WriteLine();
            Aggregate();
            Console.WriteLine();
            Aggregate2();
            Console.WriteLine();
            change();
            Console.WriteLine();
            change2();
            Console.WriteLine();
            Range();
            Console.WriteLine();
            Console.WriteLine();
            Expression<Func<Racer, bool>> expression = r => r.Country == "Brazil" && r.Wins > 6;
            DisplayTree(0, "Lambda", expression);
        }
        private static void LinqQuery()
        {
            var query = from r in Formulal.GetChampions()
                        where r.Country == "Brazil"
                        orderby r.Wins descending
                        select r;
            foreach (Racer r in query)
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
            foreach (Racer r in brazilChampions)
            {
                Console.WriteLine("{0:A}", r);
            }
        }
        static void DeferredQuery()
        {
            var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };
            var namesWithJ = from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n;
            /*var namesWithJ = (from n in names
                             where n.StartsWith("J")
                             orderby n
                             select n).ToList();*///保持两次迭代之间输出不变，改变集合中的值
            Console.WriteLine("第一次迭代： ");
            foreach (string name in namesWithJ)
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
        private static void Conect()
        {
            var racers = Formulal.GetChampionships().SelectMany(cs => new List<RacerInfo>()
               {
                 new RacerInfo {
                   Year = cs.Year,
                   Position = 1,
                   FirstName = cs.First.FirstName(),
                   LastName = cs.First.LastName()
                 },
                 new RacerInfo {
                   Year = cs.Year,
                   Position = 2,
                   FirstName = cs.Second.FirstName(),
                   LastName = cs.Second.LastName()
                 },
                 new RacerInfo {
                   Year = cs.Year,
                   Position = 3,
                   FirstName = cs.Third.FirstName(),
                   LastName = cs.Third.LastName()
                 }
               });
            var q = (from r in Formulal.GetChampions()
                     join r2 in racers on
                     new
                     {
                         FirstName = r.FirstName,
                         LastName = r.LastName
                     }
                     equals
                     new
                     {
                         FirstName = r2.FirstName,
                         LastName = r2.LastName
                     }
                     into yearResults
                     select new
                     {
                         FirstName = r.FirstName,
                         LastName = r.LastName,
                         Wins = r.Wins,
                         Starts = r.Starts,
                         Results = yearResults
                     });

            foreach (var r in q)
            {
                Console.WriteLine("{0} {1}", r.FirstName, r.LastName);
                foreach (var results in r.Results)
                {
                    Console.WriteLine("{0} {1}", results.Year, results.Position);
                }
            }
        }
        static void Jihe()
        {
            var ferrariDrivers = from r in Formulal.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r;
            foreach (var racer in ferrariDrivers)
            {
                Console.WriteLine(racer);
            }

        }
        static void SetOperations()
        {
            Func<string, IEnumerable<Racer>> racersByCar =
                car => from r in Formulal.GetChampions()
                       from c in r.Cars
                       where c == car
                       orderby r.LastName
                       select r;
            Console.WriteLine("World champion with Ferrari and McLaren");
            foreach (var racer in racersByCar("Ferrari").Intersect(racersByCar("McLaren")))
            {
                Console.WriteLine(racer);
            }
        }
        static void ZipOperation()
        {
            var racerNames = from r in Formulal.GetChampions()
                             where r.Country == "Italy"
                             orderby r.Wins descending
                             select new
                             {
                                 Name = r.FirstName + " " + r.LastName
                             };

            var racerNamesAndStarts = from r in Formulal.GetChampions()
                                      where r.Country == "Italy"
                                      orderby r.Wins descending
                                      select new
                                      {
                                          LastName = r.LastName,
                                          Starts = r.Starts
                                      };


            var racers = racerNames.Zip(racerNamesAndStarts, (first, second) => first.Name + ", starts: " + second.Starts);
            foreach (var r in racers)
            {
                Console.WriteLine(r);
            }

        }
        static void Fenqu()
        {
            int pageSize = 5;

            int numberPages = (int)Math.Ceiling(Formulal.GetChampions().Count() /
                  (double)pageSize);

            for (int page = 0; page < numberPages; page++)
            {
                Console.WriteLine("Page {0}", page);

                var racers =
                   (from r in Formulal.GetChampions()
                    orderby r.LastName, r.FirstName
                    select r.FirstName + " " + r.LastName).
                   Skip(page * pageSize).Take(pageSize);

                foreach (var name in racers)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }

        }
        static void Aggregate()//返回冠军次数超过3次的赛车手
        {
            var query = from r in Formulal.GetChampions()
                        let numberYears = r.Years.Count()
                        where numberYears >= 3
                        orderby numberYears descending, r.LastName
                        select new
                        {
                            Name = r.FirstName + " " + r.LastName,
                            TimesChampion = numberYears
                        };

            foreach (var r in query)
            {
                Console.WriteLine("{0} {1}", r.Name, r.TimesChampion);
            }
        }
        static void Aggregate2()//计算一个国家赢得比赛的总次数
        {
            var countries = (from c in
                                 from r in Formulal.GetChampions()
                                 group r by r.Country into c
                                 select new
                                 {
                                     Country = c.Key,
                                     Wins = (from r1 in c
                                             select r1.Wins).Sum()
                                 }
                             orderby c.Wins descending, c.Country
                             select c).Take(5);

            foreach (var country in countries)
            {
                Console.WriteLine("{0} {1}", country.Country, country.Wins);
            }

        }
        static void change()
        {
            List<Racer> racers = (from r in Formulal.GetChampions()
                                  where r.Starts > 150
                                  orderby r.Starts descending
                                  select r).ToList();
            foreach(var racer in racers)
            {
                Console.WriteLine("{0} {0:S}", racer);
            }
        }
        static void change2()
        {
            var racers = (from r in Formulal.GetChampions()
                          from c in r.Cars
                          select new
                          {
                              Car = c,
                              Racer = r
                          }).ToLookup(cr => cr.Car, cr => cr.Racer);//ToLookup()方法的一个重载版本传递一个键和一个元素选择器
            if(racers.Contains("Williams"))
            {
                foreach (var WilliamsRacer in racers["Williams"])
                {
                    Console.WriteLine(WilliamsRacer);
                }
            }
            
        }
        static void Range()
        {
            var values = Enumerable.Range(1, 20);
            foreach(var item in values)
            {
                Console.Write("{0} ", item);
            }
            var values2 = Enumerable.Range(1, 20).Select(n => n * 3);
            foreach(var n in values2)
            {
                Console.Write("{0} ",n);
            }
        }

        static IEnumerable<int> SampleData()
        {
            const int arraySize = 100000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();

        }
        static void Cancellation()//11.3.3 取消
        {
            var data = SampleData();

            Console.WriteLine("filled array");
            var sum1 = (from x in data
                        where Math.Log(x) < 4
                        select x).Average();
            Console.WriteLine("sync result {0}", sum1);

            var cts = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                try
                {
                    var res = (from x in data.AsParallel().WithCancellation(cts.Token)
                               where Math.Log(x) < 4
                               select x).Average();
                    Console.WriteLine("query finished, result: {0}", res);
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            Console.WriteLine("query started");
            Console.Write("cancel? ");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                cts.Cancel();
                Console.WriteLine("sent a cancel");
            }

            Console.WriteLine("press return to exit");
            Console.ReadLine();
        }

        private static void DisplayTree(int indent, string message, Expression expression)
        {
            string output = String.Format("{0} {1} ! NodeType: {2}; Expr: {3} ",
                  "".PadLeft(indent, '>'), message, expression.NodeType, expression);

            indent++;
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    Console.WriteLine(output);
                    LambdaExpression lambdaExpr = (LambdaExpression)expression;
                    foreach (var parameter in lambdaExpr.Parameters)
                    {
                        DisplayTree(indent, "Parameter", parameter);
                    }
                    DisplayTree(indent, "Body", lambdaExpr.Body);
                    break;
                case ExpressionType.Constant:
                    ConstantExpression constExpr = (ConstantExpression)expression;
                    Console.WriteLine("{0} Const Value: {1}", output, constExpr.Value);
                    break;
                case ExpressionType.Parameter:
                    ParameterExpression paramExpr = (ParameterExpression)expression;
                    Console.WriteLine("{0} Param Type: {1}", output, paramExpr.Type.Name);
                    break;
                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                case ExpressionType.GreaterThan:
                    BinaryExpression binExpr = (BinaryExpression)expression;
                    if (binExpr.Method != null)
                    {
                        Console.WriteLine("{0} Method: {1}", output, binExpr.Method.Name);
                    }
                    else
                    {
                        Console.WriteLine(output);
                    }
                    DisplayTree(indent, "Left", binExpr.Left);
                    DisplayTree(indent, "Right", binExpr.Right);
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression memberExpr = (MemberExpression)expression;
                    Console.WriteLine("{0} Member Name: {1}, Type: {2}", output,
                       memberExpr.Member.Name, memberExpr.Type.Name);
                    DisplayTree(indent, "Member Expr", memberExpr.Expression);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("{0} {1}", expression.NodeType, expression.Type.Name);
                    break;
            }
        }
    }
}
