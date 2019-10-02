using System;
using System.Drawing;

namespace 课程第三章
{
    //3.3.1类方法
    class MathTest
    {
        public int value;
        public int GetSquare()
        {
            return value * value;
        }
        public static int GetSquareOf(int x)
        {
            return x * x;
        }
        public static double GetPi()
        {
            return 3.14159;
        }
    }
    class Parame
    {
        public static void SomeFunction(int[] ints, ref int i)//ref迫使参数通过引用传送给方法
        {
            ints[0] = 100;
            i = 100;
        }
        public static void AnyFunction(out int j)//使用out关键字来初始化
        {
            j = 100;
        }
    }
    class Prefer
    {
        public static readonly Color BackColor;
        static Prefer()
        {
            DateTime now = DateTime.Now;
            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
                BackColor = Color.Green;
            else
                BackColor = Color.Red;
        }

    }
    class Car
    {
        private string ziduan1;
        private int ziduan2;
        public Car(string ziduan1, int ziduan2)
        {
            this.ziduan1 = ziduan1;
            this.ziduan2 = ziduan2;
        }
        public Car(string ziduan1)
        {
            this.ziduan1 = ziduan1;
            this.ziduan2 = 4;
        }
        //public Car (string ziduan1):this(ziduan2,4){...}
    }
    struct zhengfang
    {
        public double Length;
        public double Width;
        public zhengfang(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public double demo
        {
            get
            {
                return Math.Sqrt(Length * Length + Width * Width);
            }
        }
        
    }
    public class Money//3.9 object类
    {
        private decimal amount;
        public decimal Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
        public override string ToString()
        {
            return "$" + Amount.ToString();
        }       
    }
    public static class MoneyExtension//3.10扩展方法
    {
        public static void AddToAmount(this Money money, decimal amountToAdd)
        {
            money.Amount += amountToAdd;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //3.3.1类方法
            /*Console.WriteLine("Pi is " + MathTest.GetPi());
            int x = MathTest.GetSquareOf(5);
            Console.WriteLine("Square of 5 is " + x);
            MathTest math = new MathTest();
            math.value = 30;
            Console.WriteLine("Value field of math variable contains " + math.value);
            Console.WriteLine("Square of 30 is " + math.GetSquare());*/

            /*int i = 0;
            int[] ints = { 0, 1, 2, 4, 8 };
            Console.WriteLine("i= " + i);
            Console.WriteLine("ints[0]= " + ints[0]);
            Console.WriteLine("Calling SomeFunction.");

            Parame.SomeFunction(ints, ref i);
            Console.WriteLine("i= " + i);
            Console.WriteLine("ints[0]= " + ints[0]);

            int j;
            Parame.AnyFunction(out j);
            Console.WriteLine(j);

            Console.WriteLine("User-prefer:BackColor is: " + Prefer.BackColor.ToString());

            zhengfang point = new zhengfang();
            point.Length = 3;
            point.Width = 6;


            //3.6弱引用           
            WeakReference maths = new WeakReference(new MathTest());
            MathTest math;
            if (maths.IsAlive)
            {
                math = maths.Target as MathTest;
                math.value = 30;
                Console.WriteLine("Value field of math variable contains " + math.value);
                Console.WriteLine("Square of 30 is " + math.GetSquare());
            }
            else
            {
                Console.WriteLine("Reference is not available.");
            }
            GC.Collect();
            if (maths.IsAlive)
            {
                math = maths.Target as MathTest;
            }
            else
            {
                Console.WriteLine("Reference is not available.");               
            }*/

            //3.9 object类
            int i = 50;
            string str = i.ToString();
            Console.WriteLine(str);

            //3.9.2 ToString方法
            Money cash1 = new Money();
            cash1.Amount = 40;
            Console.WriteLine("cash1.ToString() returns: " + cash1.ToString());
            cash1.AddToAmount(60);
            Console.WriteLine("用了扩展方法加了60：" + cash1.ToString());
        }
    }
}
