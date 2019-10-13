using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace 第10章__集合
{
    public class Racer:IComparable<Racer>,IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { set; get; }
        public string Country { get; set; }
        public int Wins { get; set; }
        public Racer(int id,string firstName,string lastName,string country)
            :this(id,firstName,lastName,country,wins:0)
        {

        }
        public Racer(int id, string firstName, string lastName, string country,int wins)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Wins = wins;
        }
        public override string ToString()
        {
            return String.Format("{0} {1}",FirstName,LastName);
        }
        public string ToString(string format,IFormatProvider formatProvider)
        {
            if (format == null)
                format = "N";
            switch(format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L": 
                    return LastName;
                case "W": 
                    return String.Format("{0}, Wins: {1}", ToString(), Wins);
                case "C": 
                    return String.Format("{0}, Country: {1}", ToString(), Country);
                case "A": 
                    return String.Format("{0}, {1} Wins: {2}", ToString(), Country, Wins);
                default:
                    throw new FormatException(String.Format(formatProvider, "Format {0} is not supported", format));

            }
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public int CompareTo(Racer other)
        {
            if (other == null)
                return -1;
            int compare = string.Compare(this.LastName, other.LastName);
            if(compare==0)
            return string.Compare(this.FirstName, other.FirstName);
            return compare;     
        }
    }
    /*public class List<T>:IList<T>
    {
        private T[] items;
        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            foreach(T item in items)
            {
                action(item);
            }
        }
    }
    public delegate void Action<T>(T obj);
    public void ActionHandler(Racer obj);
    racers.ForEach(Console.WriteLine);
        racers.ForEach(r=>Console.WriteLine("{0:A}",r));*/
    public delegate bool Predicate<T>(T obj);
    public class FindCounty
    {
        private string country;
        public FindCounty(string Country)
        {
            this.country = Country;
        }
        public bool FindCountryPredicate(Racer racer)
        {
            //Contract.Requires<ArgumentNullException>(racer != null);
            return racer.Country == country;
        }
    }
    public class RacerComparer:IComparer<Racer>
    {
        public enum CompareType
        {
            FirstName,
            LastName,
            Country,
            Wins
        }
        private CompareType compareType;
        public RacerComparer(CompareType compareType)
        {
            this.compareType = compareType;
        }
        public int Compare(Racer x,Racer y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            int result;
            switch(compareType)
            {
                case CompareType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case CompareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                case CompareType.Country:
                    result = string.Compare(x.Country, y.Country);
                    if (result == 0)
                        return string.Compare(x.LastName, y.LastName);
                    else
                        return result;
                case CompareType.Wins:
                    return x.Wins.CompareTo(y.Wins);
                default:
                    throw new ArgumentException("Invalid Compare Type");
            }
        }         
    }
    public class Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Document(string title,string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }
    public class DocumentManager
    {
        private readonly Queue<Document> documentQueue = new Queue<Document>();
        public void AddDocument(Document doc)
        {
            lock(this)
            {
                documentQueue.Enqueue(doc);
            }
        }
        public Document GetDocument()
        {
            Document doc = null;
            lock(this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }
        public bool IsDocumentAvailable
        {
            get
            {
                return documentQueue.Count > 0;
            }
        }
    }
    public class ProcessDocuments
    {
        public static void Static(DocumentManager dm)
        {
            Task.Factory.StartNew(new ProcessDocuments(dm).Run);
        }
        protected ProcessDocuments (DocumentManager dm)
        {
            if(dm==null)
            {
                throw new ArgumentNullException("dm");
            }
            documentManager = dm;
        }
        private DocumentManager documentManager;
        protected void Run()
        {
            while(true)
            {
                if(documentManager.IsDocumentAvailable)
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine("Processing document {0}", doc.Title);
                }
                Thread.Sleep(new Random().Next(20));
            }
        }
    }
    //public sealed Delegate TOutput Converter<TInput,TOutout>(TInput from);
    public class Person
        {
            private string name;
            public Person(string name)
            {
                this.name = name;
            }
            public override string ToString()
            {
                return name;
            }
        }
    public class EmployeeIdException:Exception
    {
        public EmployeeIdException(string message) : base(message) { }
    }
    public struct EmployeeId:IEquatable<EmployeeId>
    {
        private readonly char prefix;
        private readonly int number;
        public EmployeeId(string id)
        {
            //Contrace.Requires<ArgumentNullException>(id != null);
            prefix = (id.ToUpper())[0];
            int numlength = id.Length - 1;
            try
            {
                number = int.Parse(id.Substring(1, numlength > 6 ? 6 : numlength));
            }
            catch (FormatException)
            {
                throw new EmployeeIdException("Invaild EmployeeId format");
            }
        }
        public override string ToString()
        {
            return prefix.ToString() + string.Format("{0,6:000000}", number);
        }
        public override int GetHashCode()
        {
            return (number ^ number << 16) * 0x15051505;
        }
        public bool Equals(EmployeeId other)
        {
            if (other == null) return false;

            return (prefix == other.prefix && number == other.number);
        }
        public override bool Equals(object obj)
        {
            return Equals((EmployeeId)obj);
        }
        public static bool operator ==(EmployeeId left, EmployeeId right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(EmployeeId left, EmployeeId right)
        {
            return !(left == right);
        }
    }    public class Employee
    {
        private string name;
        private decimal salary;
        private readonly EmployeeId id;
        public Employee(EmployeeId id, string name, decimal salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
        public override string ToString()
        {
            return String.Format("{0}: {1, -20} {2:C}",
                  id.ToString(), name, salary);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //var intList = new List<int>();
            //var racers = new List<Racer>();
            List<int> intList = new List<int>(10);//创建一个容量为10个元素的集合
            intList.Capacity = 20;//使用Capacity属性可以获取和设置集合的容量
            Console.WriteLine(intList.Count);//只要不把元素添加到列表中，元素个数就是0
            intList.TrimExcess();//如果将元素添加到列表中，且不希望添加更多的元素，就可以调用TrimExcess（）方法，去除不需要的容量

            //1.集合初始值设定项
            var IntList = new List<int>() { 1,2};
            var stringList = new List<string>() { "one", "two" };
            //2.添加元素
            intList.Add(1);
            intList.Add(2);         
            stringList.Add("three");
            stringList.Add("four");
            var jinghui = new Racer(3, "jinghui","chen" ,"China", 14);
            var jiaer = new Racer(9, "jiaer", "hong", "Japan", 14);
            var wudi = new Racer(34, "wudi", "tong", "USA", 12);

            var racers = new List<Racer>(20) { jinghui, jiaer,wudi };//添加到集合中

            racers.Add(new Racer(24, "yaoyao", "yu", "Hongkong", 91));
            racers.Add(new Racer(27, "wenzi", "liu", "Canada", 20));

            racers.AddRange(new Racer[]
            {
                new Racer(14,"niki","li","Austria",25),
                new Racer(21,"guanrong","tong","France",51)
            });//AddRange()方法，可以一次给集合添加多个元素

            //3.插入元素
            racers.Insert(5, new Racer(6, "xinxin", "xie","China",3));//5为指定的位置

            //4.访问元素
            Racer r1 = racers[3];
            for (int i=0;i<racers.Count;i++)
            {
                Console.WriteLine(racers[i]);
            }
            //5.删除元素
            Console.WriteLine();
            racers.RemoveAt(7);//利用索引，传递要删除的元素 
            int index = 5;
            int count = 2;
            racers.RemoveRange(index, count);//第一个参数指定了开始删除的元素索引，第二个参数指定了要删除的元素个数
            foreach (Racer r in racers)
            {
                Console.WriteLine(r);
            }
            //6.搜索元素
            Console.WriteLine();
            int index1 = racers.IndexOf(jinghui);
            Console.WriteLine(index1);
            int index2 = racers.FindIndex(new FindCounty("USA").FindCountryPredicate);
            Console.WriteLine(index2);
            int index3 = racers.FindIndex(r => r.Country == "China");
            Console.WriteLine(index3);
            List<Racer> bigWinners = racers.FindAll(r => r.Wins >= 20);//">="是符合wins大于等于20的人
            foreach(Racer r in bigWinners)
            {
                Console.WriteLine("{0:A}",r);
            }
            //7.排序
            Console.WriteLine();
            racers.Sort(new RacerComparer(RacerComparer.CompareType.Country));
            racers.ForEach(Console.WriteLine);
            //8.类型转换
            List<Person> persons = racers.ConvertAll<Person>(
                r => new Person(r.FirstName + " " + r.LastName));//创建并返回了一个新的Person对象（对FirstName，LastName进行转换）

            /*Console.WriteLine();
            var dm = new DocumentManager();
            ProcessDocuments.Static(dm);
            for (int i = 0; i < 10; i++)
            {
                var doc = new Document("Doc" + i.ToString(), "content");
                dm.AddDocument(doc);
                Console.WriteLine("Added document{0}", doc.Title);
                Thread.Sleep(new Random().Next(20));
            }*/

            Console.WriteLine();
            var zhan = new Stack<char>();
            zhan.Push('a');
            zhan.Push('b');
            zhan.Push('c');
            Console.WriteLine("First diedai:");
            foreach (char r in zhan)
            {
                Console.Write(r);
            }
            Console.WriteLine();
            Console.WriteLine("Second diedai:");
            while(zhan.Count>0)
            {
                Console.Write(zhan.Pop());
            }
            Console.WriteLine();

            Console.WriteLine();
            var books = new SortedList<string, string>();
            books.Add("Professional WPF Programming", "978–0–470–04180–2");
            books.Add("Professional ASP.NET MVC 3", "978–1–1180–7658–3");

            books["Beginning Visual C# 2010"] = "978–0–470-50226-6";
            books["Professional C# 4 and .NET 4"] = "978–0–470–50225–9";
            foreach (KeyValuePair<string, string> book in books)
            {
                Console.WriteLine("{0}, {1}", book.Key, book.Value);
            }
            foreach (string title in books.Keys)//Keys属性返回IList<TKey>
            {
                Console.WriteLine(title);
            }
            foreach (string isbn in books.Values)//Values属性返回IList<TValue>
            {
                Console.WriteLine(isbn);
            }
            {
                string zhis;
                string keys = "Professional C# 7.0";
                if (!books.TryGetValue(keys, out zhis))
                {
                    Console.WriteLine("{0} not found", keys);
                }
            }//调用TryGetValue（）方法，尝试获得指定键的值，如果有该key则返回true，没有则表示指定键对应的值不存在

            Console.WriteLine();
            var employees = new Dictionary<EmployeeId, Employee>(31);

            var idTony = new EmployeeId("C3755");
            var tony = new Employee(idTony, "Tony Stewart", 379025.00m);
            employees.Add(idTony, tony);
            Console.WriteLine(tony);

            var idCarl = new EmployeeId("F3547");
            var carl = new Employee(idCarl, "Carl Edwards", 403466.00m);
            employees.Add(idCarl, carl);
            Console.WriteLine(carl);

            var idKevin = new EmployeeId("C3386");
            var kevin = new Employee(idKevin, "Kevin Harwick", 415261.00m);
            employees.Add(idKevin, kevin);
            Console.WriteLine(kevin);//用Add（）方法创建员工对象和ID

            var idMatt = new EmployeeId("F3323");
            var matt = new Employee(idMatt, "Matt Kenseth", 1589390.00m);
            employees[idMatt] = matt;
            Console.WriteLine(matt);//使用索引器，将键和值添加到字典中

            var idBrad = new EmployeeId("D3234");
            var brad = new Employee(idBrad, "Brad Keselowski", 322295.00m);
            employees[idBrad] = brad;
            Console.WriteLine(brad);
            while(true)
            {
                Console.WriteLine("Enter employee id(x to exit)>");
                var userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
                if (userInput == "X") break;
                EmployeeId id;
                try
                {
                    id = new EmployeeId(userInput);
                    Employee employee;
                    if(!employees.TryGetValue(id,out employee))
                    {
                        Console.WriteLine("Employee with id {0} does not exist", id);
                    }
                    else
                    {
                        Console.WriteLine(employee);
                    }
                }
                catch (EmployeeIdException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
