using System;

namespace 课程第七章运算符和类型强制转换
{
    public class SomeClass
    {

    }
    struct Vector
    {
        public double x, y, z;
        public Vector(double x,double y,double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector (Vector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }
        public override string ToString()
        {
            return (x+","+y+","+z);
        }
        public static Vector operator + (Vector lhs, Vector rhs)
        {
            Vector result = new Vector(lhs);
            result.x += rhs.x;
            result.y += rhs.y;
            result.z += rhs.z;
            return result;
        }
        public static Vector operator * (double lhs,Vector rhs)
        {
            return new Vector(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static double operator *(Vector  lhs, Vector rhs)
        {
            return lhs.x * rhs.x+ lhs.y * rhs.y+lhs.z * rhs.z;
        }
        public static Vector  operator *(Vector lhs, double rhs)
        {
            return rhs * lhs;
        }
        public static bool operator == (Vector lhs,Vector rhs)
        {
            if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
                return true;
            else
                return false;
        }
        public static bool operator !=(Vector lhs, Vector rhs)
        {
            return !(lhs == rhs);
        }

    }
    struct Currency
    {
        public uint Dollars;
        public ushort Cents;
        public Currency (uint dollars,ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }
        public override string ToString()
        {
            return string.Format("${0},{1,-2:00}",Dollars,Cents);
        }
        public static implicit operator float (Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }//隐式转换
        public static explicit operator Currency(float value)
        {
            uint dollars = (uint)value;
            ushort cents = (ushort)((value - dollars) * 100);
            return new Currency(dollars, cents);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;//条件运算符 condition ? true_value:false_value
            string s = x + " ";
            s += (x == 1 ? "man" : "men");
            Console.WriteLine(s);

            /*byte b = 255;//代码块标记为checked，CLR就会执行溢出检查
            checked
            {
                b++;
            }
            Console.WriteLine(b.ToString());*/
            byte b = 255;//不会抛出异常，但会丢失数据，因为byte数据类型不能包含256
            unchecked
            {
                b++;
            }
            Console.WriteLine(b.ToString());

            int i = 10;//is 运算符
            if(i is object)
            {
                Console.WriteLine("i is an object");
            }

            object o1 = "some String";//as 运算符
            object o2 = 5;
            string s1 = o1 as string;
            string s2 = o2 as string;
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            int? c = null;//可控类型和运算符
            int? d = -5;
            if (c >= d)
                Console.WriteLine("c>=d");
            else
                Console.WriteLine("a<b");

            int? e = null;//空合并运算符
            int f;
            f = e ?? 10;
            Console.WriteLine(f);
            e = 3;
            f = e ?? 10;
            Console.WriteLine(f);

            long val = 30000;
            int j = (int)val;
            Console.WriteLine(j);
            double price = 25.30;
            int Price = (int)(price + 0.5);
            Console.WriteLine(Price);
            /*ushort z = 43;
            char symbol = (char)c;
            Console.WriteLine(symbol);*/

            string k = "100";//预定义值
            int K = int.Parse(k);
            Console.WriteLine(K + 50);

            int myIntNumber = 20;
            object myobject = myIntNumber;//装箱
            int mySecondNumber = (int)myobject;//拆箱
            Console.WriteLine(mySecondNumber);
//ReferenceEquals()方法
            SomeClass p, q;
            p = new SomeClass();
            q = new SomeClass();
            bool B1 = ReferenceEquals(null, null);
            bool B2 = ReferenceEquals(null, p);
            bool B3 = ReferenceEquals(p, q);//因为x和y指向了不同的objec类
            Console.WriteLine("B1判定:{0},B2判定:{1},B3判定:{2}",B1,B2,B3);
            //虚拟的Equals()方法
            //静态的Equals()方法   
            //比较运算符（==）

            int myInt = 3;
            uint myUInt = 2;
            double myDouble = 4.0;
            long myLong = myInt + myUInt;
            double myOtherDouble = myDouble + myInt;
            Console.WriteLine("myLong的值:{0},myOtherDouble的值:{1}", myLong, myOtherDouble);

            Vector vect1, vect2, vect3;
            vect1 = new Vector(3.0, 3.0, 1.0);
            vect2 = new Vector(2.0, -4.0, -4.0);
            vect3 = vect1 + vect2;
            Console.WriteLine("vect1 = " + vect1.ToString());
            Console.WriteLine("vect2 = " + vect2.ToString());
            Console.WriteLine("vect3 = " + vect3.ToString());
            Console.WriteLine("2*vect3=" + 2 * vect3);
            vect3 += vect2;
            Console.WriteLine("返回vect3 += vect2 gives的值为" + vect3);
            vect3 = 2*vect1;
            Console.WriteLine("返回vect3 = 2*vect1的值为：" + vect3);
            double dot = vect1 * vect3;
            Console.WriteLine("返回dot = vect1 * vect3;的值为：" + dot);

            Vector vect4, vect5, vect6;
            vect4 = new Vector(3.0, 3.0, -10.0);
            vect5 = new Vector(3.0, 3.0, -10.0);
            vect6 = new Vector(2.0, 3.0, 6.0);
            Console.WriteLine("vect4==vect5 returns:  " + (vect4 == vect5));
            Console.WriteLine("vect4==vect6 returns:  " + (vect4 == vect6));
            Console.WriteLine("vect5==vect6 returns:  " + (vect5 == vect6));   
            Console.WriteLine("vect4!=vect6 returns:  " + (vect4 != vect6));

            Console.WriteLine();
            Currency balance = new Currency(10, 50);
            float bal = balance;
            Console.WriteLine(bal);
            float amount = 45.63f;
            Currency amount2 = (Currency)amount;
            Console.WriteLine(amount2);


        }
        /*static void Main()
        {
            try
            {
                Currency balance = new Currency(50, 35);
                Console.WriteLine(balance);
                Console.WriteLine("balance is " + balance);
                Console.WriteLine("balance is (using ToString()) " + balance.ToString());
                float balance2 = balance;
                Console.WriteLine("转换成浮点型后：" + balance2);
                balance = (Currency)balance2;
                Console.WriteLine("强制转换后：" + balance);
                Console.WriteLine("Now attempt to convert out of range value of"+"-￥50.50 to a Currency;");
                checked
                {
                    balance = (Currency)(-50.50);
                    Console.WriteLine("Result is" + balance.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
            }
        }*/
    }
}
