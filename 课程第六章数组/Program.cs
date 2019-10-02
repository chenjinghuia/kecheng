using System;
using System.Collections;
using System.Collections.Generic;

namespace 课程第六章数组
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return String.Format(FirstName, LastName);
        }
    }

    /*public class People:IComparable<People>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return String.Format(FirstName, LastName);
        }
        public int ComepareTo(People other)
        {
            if (other == null) return 1;
            int result = string.Compare(this.LastName, other.LastName);
            if(result==0)
            {
                result = string.Compare(this.FirstName, other.FirstName);
            }
            return result;
        }
    }
    public enum PeopleCompareType
    {
        FirstName,
        LastName
    }
    public class PeopleComparer:IComparer<People>
    {
        private PeopleCompareType compareType;
        public PeopleComparer(PeopleCompareType compareType)
        {
            this.compareType = compareType;
        }
        public int Compare(Person x,Person y)
        {
            if (x = null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            switch(compareType)
            {
                case PeopleCompareType.FirstName:
                    return x.FirstName.CompareTo(y.FirstName);
                case PeopleCompareType.LastName:
                    return x.LastName.CompareTo(y.LastName);
                default:
                    throw new ArgumentException(
                          "unexpected compare type");
            }
        }
    }*/  
    /*static Person[] GetPeoples()//声明为返回类型
    {
        return new Person[]
            {
                new Person {FirstName ="Damon",LastName="Hill"},
                new Person {FirstName ="Niki",LastName="Lauda"},
                new Person {FirstName ="Ayrton",LastName="Sonna"},
                new Person {FirstName ="Graham",LastName="Hill"},
            };
        static void DisplayPeoples(Person[] persons)//声明为参数，把数组传递给方法
        {

        }

    }*/
   public class HelloCollection
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Hello";
            yield return "world";
        }
        public IEnumerator getEnumerator()
        {
            return new Enumerator(0);
        }
        public class Enumerator:IEnumerator<string>,IEnumerator,IDisposable
        {
            private int state;
            private string current;
            public Enumerator(int state)
            {
                this.state = state;
            }
            bool System.Collections.IEnumerator.MoveNext()
            {
                switch(state)
                {
                    case 0:
                        current = "Hello";
                        state = 1;
                        return true;
                    case 1:
                        current = "World";
                        state = 2;
                        return true;
                    case 2:
                        break;
                }
                return false;
            }
            void System.Collections.IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }
            string System.Collections.Generic.IEnumerator<string>.Current
            {
                get
                {
                    return current;
                }
            }
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return current;
                }
            }
            void IDisposable.Dispose()
            {

            }
        }
    }
    public class MusicTitles
    {
        string[] names = {
              "Tubular Bells", "Hergest Ridge",
              "Ommadawn", "Platinum" };
        public IEnumerator<string> GetEnumerator()
        {
            for(int i=0;i<4;i++)
            {
                yield return names[i];
            }
        }
        public IEnumerable<string> Reverse()
        {
            for(int i=3;i>=0;i--)
            {
                yield return names[i];
            }
        }
        public IEnumerable <string> Subset(int index,int length)
        {
            for(int i=index;i<index+length;i++)
            {
                yield return names[i];
            }
        }
    }
    public class GameMoves
    {
        private IEnumerator cross;
        private IEnumerator circle;
        public GameMoves()
        {
            cross = Cross();
            circle = Circle();
        }
        private int move = 0;
        const int MaxMoves = 9;
        public IEnumerator Cross()
        {
            while(true)
            {
                Console.WriteLine("Cross, move {0}", move);
                if (++move >= MaxMoves)
                    yield break;
                yield return circle;
            }
        }
        public IEnumerator Circle()
        {
            while (true)
            {
                Console.WriteLine("Circle, move {0}", move);
                if (++move >= MaxMoves)
                    yield break;
                yield return cross;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*int[] myArray1 = new int[4] { 4, 7, 11, 2 };
            int[] myArray2 = new int[] { 4, 7, 11, 2 };
            int[] myArray3 = { 4, 7, 11, 2 };
            int v1 = myArray1[0];//通过索引器传递元素编号，就可以访问数组
            myArray3[3] = 44;
            for(int i=0;i<myArray3.Length;i++)
            {
                Console.Write(myArray3[i]);
            }
            Console.WriteLine();
            foreach(var yuyaoyao in myArray3)
            {
                Console.WriteLine(yuyaoyao);
            }

            Person[] person = new Person[2];
            person[0] = new Person { FirstName = "cjh", LastName = "yyy" };
            person[1] = new Person { FirstName = "ckx", LastName = "cyx" };
            Person[] persons =
                {
                     new Person { FirstName = "cjh", LastName = "yyy" },
                     new Person { FirstName = "ckx", LastName = "cyx" }
                };

            //二维数组
            int[,] twodim = new int[2, 2];
            twodim[0, 0]= 1;
            twodim[0, 1] = 2;
            twodim[1, 0] = 3;
            twodim[1, 1] = 4;
            int[,] Twodim =
            {
                {1,2},
                {3,4}
            };

            //锯齿数组
            int[][] jag = new int[3][];
            jag[0] = new int[2] { 1, 2 };
            jag[1] = new int[6] { 3, 4, 5, 6, 7, 8 };
            jag[2] = new int[3] { 9, 10, 11 };
            for(int i=0;i<jag.Length; i++)
            {
                for(int j=0;j<jag[i].Length;j++)
                {
                    Console.WriteLine("行： " + i + "列： " + j + "值： " + jag[i][j]);
                }
            }*/

            Array array = Array.CreateInstance(typeof(int), 5);
            for (int i = 0; i < 5; i++)
            {
                array.SetValue(33, i);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(array.GetValue(i));
            }
            int[] array1 = (int[])array;//将已创建的数组强制转换成声明为int[]的数组
            int[] lengths = { 2, 3 };
            int[] lowerBounds = { 1, 10 };
            Array racers = Array.CreateInstance(typeof(Person), lengths, lowerBounds);
            racers.SetValue(new Person { FirstName = "Alain", LastName = "Prost" }, index1: 1, index2: 10);
            racers.SetValue(new Person { FirstName = "Limi", LastName = "John" }, index1: 1, index2: 11);
            racers.SetValue(new Person { FirstName = "Derek", LastName = "Amy" }, index1: 1, index2: 12);
            racers.SetValue(new Person { FirstName = "Shay", LastName = "Funy" }, index1: 2, index2: 10);
            racers.SetValue(new Person { FirstName = "Zang", LastName = "Kang" }, index1: 2, index2: 11);
            racers.SetValue(new Person { FirstName = "Uiny", LastName = "Qing" }, index1: 2, index2: 12);
            Person[,] racers2 = (Person[,])racers;
            Person first = racers2[1, 10];
            Person last = racers2[2, 12];
            Console.WriteLine(first + "  " + last);

            int[] intArray1 = { 1, 2 };//复制数组
            int[] intArray2 = (int[])intArray1.Clone();
            for (int n = 0; n < intArray2.Length; n++)
            {
                Console.WriteLine(intArray2[n]);
            }

            Person[] beatles = {
                new Person{FirstName = "Zang", LastName = "Kang" },
                new Person { FirstName = "Uiny", LastName = "Qing" }
            };//beatles和beatlesClone引用的Person对象是相同的，如果修改beatlesClone中一个元素的属性，就会改变beatles中的对应对象
            Person[] beatlesClone = (Person[])beatles.Clone();

            string[] names = {
                   "Christina Aguilera",
                   "Shakira",
                   "Beyonce",
                   "Gwen Stefani"
                 };

            Array.Sort(names);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            /* People[] peoples =
           {
               new People { FirstName = "Alain", LastName = "Prost" },
               new People { FirstName = "Limi", LastName = "John" },
               new People { FirstName = "Derek", LastName = "Amy" },
               new People { FirstName = "Shay", LastName = "Funy" }
           };
           Array.Sort(peoples);
           foreach(var p in peoples)
           {
               Console.WriteLine(p);
           }

           Array.Sort(peoples, new PeopleComparer(PeopleCompareType.FirstName);
           foreach(var P in peoples)
           {
               Console.WriteLine(P);
           }*/
            
            int[] ar1 = { 1, 4, 5, 11, 13, 18 };
            int[] ar2 = { 3, 4, 5, 18, 21, 27, 33 };
            var segments = new ArraySegment<int>[2]
            {
                new ArraySegment<int>(ar1,0,3),
                new ArraySegment<int>(ar2,3,3)
            };
            var sum = SumOfSqgments(segments);
            Console.WriteLine("sum of all segments: {0}", sum);


            var game = new GameMoves();
            IEnumerator enumerator = game.Cross();
            while(enumerator.MoveNext())
            {
                enumerator = enumerator.Current as IEnumerator;
            }
        }



        static int SumOfSqgments(ArraySegment<int>[] seqments)
        {
            int sum = 0;
            foreach (var segment in seqments)
            {
                for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)//offset为元素的偏移坐标，count为元素的个数
                {
                    sum += segment.Array[i];
                }
            }
            return sum;
        }
        static void HelloWorld()
        {
            var helloCollection = new HelloCollection();
            foreach (var s in helloCollection)
            {
                Console.WriteLine(s);
            }
        }
        static void MusicTitles()
        {
            var titles = new MusicTitles();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();

            Console.WriteLine("reverse");
            foreach (var title in titles.Reverse())
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();

            Console.WriteLine("subset");
            foreach (var title in titles.Subset(2, 2))
            {
                Console.WriteLine(title);
            }

        }

    }
}
