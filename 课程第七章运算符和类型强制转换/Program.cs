using System;

namespace 课程第七章运算符和类型强制转换
{
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

        }
    }
}
