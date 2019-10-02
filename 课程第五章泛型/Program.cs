using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace 课程第五章泛型
{
    /*public class ArrayList
    {
        public void Add(int zhengshu)
        {

        }
    }*/
    public class LLNode<T>//创建链表的泛型版本
    {
        public LLNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }
        public LLNode<T> Next { get; internal set; }
        public LLNode<T> Prev { get; internal set; }
    }
    public class LList<T>: IEnumerable<T>
    {

        public LLNode<T> First { get; private set; }
        public LLNode<T> Last { get; private set; }

        public LLNode<T> AddLast(T node)
        {
            var newNode = new LLNode<T>(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            return newNode;
        }
        public IEnumerator<T> GetEnumerator()
        {
            LLNode<T> current = First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
             return GetEnumerator();
        }      
    }
    public class DocumentManager<TDocument>where TDocument:IDocument
    {
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();
        public void AddDocument(TDocument doc)
        {
            lock(this)
            {
                documentQueue.Enqueue(doc);
            }
        }
        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }
        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);
            lock(this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
            
        }
        public void DispalyAllDocuments()
        {
            foreach(TDocument doc in documentQueue)
            {
                //Console.WriteLine(((IDocument)doc).Title);
                Console.WriteLine(doc.Title);
            }
        }
    }
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }
    public class Document:IDocument
    {    
        public Document()
        {

        }
        public Document(string title,string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public abstract class Calc<T>
    {
        public abstract T Add(T x, T y);
        public abstract T Sub(T x, T y);
    }
    public class IntCalc:Calc<int>//派生一个泛型类
    {
        public override int Add(int x, int y)
        {
            return x + y;
        }
        public override int Sub(int x, int y)
        {
            return x - y;
        }
    }
    public class StaticDemo<T>
    {
        public static int x;
    }
    public interface IComparable<in T>
    {
        int CompareTO(T other);
    }
    /*public class Person:IComparable
    {
        public object LastName { get; private set; }

        public int CopareTo(object obj)
        {
            Person other = obj as Person;
            return this.LastName.CompareTo(other.LastName);
        }
    }
    //实现泛型版本时，不再需要将object的类型强制转换为Person：
    public class Person:IComparable<Person>
    {
        public int CompareTo(Person other)
        {
            return this.Lastname.CompareTo(other.LastName);
        }
    }*/
    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override string ToString()
        {
            return String.Format("Width: {0}, Height: {1}", Width, Height);
        }
    }
    public class Rectangle:Shape
    {

    }
    public interface IIndex<out T>
    {
        T this[int index] { get; }
        int Count { get; }
    }
    public class RectangleCollection : IIndex<Rectangle>
    {
        private Rectangle[] data = new Rectangle[3]
            {
                new Rectangle{Height=2,Width=5},
                new Rectangle{Height=3,Width=7},
                new Rectangle{Height=4.5,Width=2.9}
            };
        private static RectangleCollection coll;
        public static RectangleCollection GetRectangle()
        {
            return coll ?? ( coll=new RectangleCollection());
        }
        public Rectangle this[int index]
        {
            get
            {
                if (index < 0 || index > data.Length)
                throw new ArgumentOutOfRangeException("index");
                return data[index];
            }
        }
        public int Count
        {
            get
            {
                return data.Length;
            }
        }
    }
    public interface IDisplay <in T>
    {
        void Show(T item);
    }
    public class ShapeDisplay:IDisplay<Shape>
    { 
        public void Show(Shape s)
        {
            Console.WriteLine("{0} Width: {1}, Height: {2}", s.GetType().Name, s.Width, s.Height);
        }
    }
    public struct Nullable<T> where T:struct
    {
        public Nullable (T value)
        {
            this.hasValue = true;
            this.value = value;
        }
        private bool hasValue;
        public bool HasValue
        {
            get
            {
                return hasValue;
            }
        }
        private T value;
        public T Value
        {
            get
            {
                if(!hasValue)
                {
                    throw new InvalidOperationException("no value");
                }
                return value;
            }
        }
        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }
        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }
        public override string ToString()
        {
            if (!HasValue)
                return String.Empty;
            return this.value.ToString();
        }
    }
    public static class Algorithm
    {
        public static decimal AccumulateSimple(IEnumerable <Account> source)
        {
            decimal sum = 0;
            foreach(Account a in source)
            {
                sum += a.Balance;
            }
            return sum;
        }
    }

    public class Account
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public Account(string name,decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }
    //带约束的泛型方法
    /*public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source)
        where TAccount : IAccount
    {
        decimal sum = 0;

        foreach (TAccount a in source)
        {
            sum += a.Balance;
        }
        return sum;
    }
    public interface IAccount
    {
        decimal Balance { get; }
        string Name { get; }
    }
    public class Account : IAccount
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }

        public Account(string name, Decimal balance)
        {
            this.Name = name;
            this.Balance = balance;
        }
    }*/
    /*public static T2 Accumulate<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action)
    {
        T2 sum = default(T2);
        foreach (T1 item in source)
        {
            sum = action(item, sum);
        }
        return sum;
    }*/
    public class MethodOverloads
    {
        public void Foo<T>(T obj)
        {
            Console.WriteLine("Foo<T>(T obj), obj type: {0}", obj.GetType().Name);
        }
        public void Foo(int x)
        {
            Console.WriteLine("Foo(int x)");
        }
        public void Bar<T>(T obj)
        {
            Foo(obj);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*var list = new ArrayList();//前者是装拆箱后者是泛型var list = new List<int>();
            list.Add(44);
            int il = (int)list[0];//前者是装拆箱后者是泛型int i1=list[0];
            foreach (int i2 in list)
            {
                Console.WriteLine(i2);
            }*/
            /*var list1 = new LList();
            list1.AddLast(2);
            list1.AddLast(4);
            list1.AddLast("6");

            foreach (int i in list1)
            {
                Console.WriteLine(i);
            }

            var list1 = new LList();
            list1.AddLast(2);
            list1.AddLast(4);
            list1.AddLast("6");

            foreach (int i in list1)
            {
                Console.WriteLine(i);
            }

            var list2 = new LList<int>();
            list2.AddLast(1);
            list2.AddLast(3);
            list2.AddLast(5);

            foreach (int i in list2)
            {
              Console.WriteLine(i);
            }

            var list3 = new LList<string>();
            list3.AddLast("2");
            list3.AddLast("four");
            list3.AddLast("foo");

            foreach (string s in list3)
            {
               Console.WriteLine(s);
            }*/

            /*var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A", "Sample A"));
            dm.AddDocument(new Document("Title B", "Sample B"));
            dm.DispalyAllDocuments();
            if(dm.IsDocumentAvailable)
            {
                Document d = dm.GetDocument();
                Console.WriteLine(d.Content);
            }*/

            StaticDemo<string>.x = 4;
            StaticDemo<int>.x = 5;
            Console.WriteLine(StaticDemo<int>.x);

            var r = new Rectangle { Width = 5, Height = 2.5 };
            Console.WriteLine( r.ToString());
//协变：把返回值赋予IIndex<Rectangle>类型的变量rectangle，因为协变，所以可以把值赋予IIndex<Shape>类型的变量
            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangle();
            IIndex<Shape> shapes = rectangles;
            for(int i=0;i<shapes.Count;i++)
            {
                Console.WriteLine(shapes[i]);
            }
//抗变：IDisplay<T>是抗变的，可以把结果赋予IDisplay<Rectangle>
            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            IDisplay<Rectangle> rectangleDisplay = shapeDisplay;
            rectangleDisplay.Show(rectangles[0]);

            var accounts = new List<Account>()
            {
                new Account("Christian",1500),
                new Account("Stephanie",2200),
                new Account("Angela",1800),
                new Account("Matthias",2400),
            };
            decimal amount = Algorithm.AccumulateSimple(accounts);
            Console.WriteLine(amount);

            //decimal Amount = Algorithm.Accumulate<Account>(accounts);
            //decimal Amount = Algorithm.Accumulate<Account, decimal>(accounts, (item, sum) => sum += item.Balance);

            var test = new MethodOverloads();
            test.Foo(33);
            test.Foo("abc");
            test.Bar(44);
        }
    }
}
