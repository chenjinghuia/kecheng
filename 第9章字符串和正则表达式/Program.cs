using System;
using System.Text;

namespace 第9章字符串和正则表达式
{
    interface IFormattable
    {
        string Tostring(string format, IFormatProvider formatProvider);
    }
    /*struct Vector : IFormattable
    {
        public double x, y, z;
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public double Norm()
        {
            return x * x + y * y + z * z;
        }
        public override string ToString()
        {
            return "( " + x + " , " + y + " , " + z + " )";
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                return ToString();
            }
            string formatUpper = format.ToUpper();
            switch (formatUpper)
            {
                case "N":
                    return "|| " + Norm() + " ||";
                case "VE":
                    return String.Format("( {0:E}, {1:E}, {2:E} )", x, y, z);
                case "IJK":
                    StringBuilder sb = new StringBuilder(x.ToString(), 30);
                    sb.Append(" i + ");
                    sb.Append(y.ToString());
                    sb.Append(" j + ");
                    sb.Append(z.ToString());
                    sb.Append(" k");
                    return sb.ToString();
                default:
                    return ToString();
            }
        }
    }*/
}
    class Program
    {
        static void Main(string[] args)
        {
            string message1 = "Hello";
            message1 += ",There";
            string message2 = message1 + "xixixi";
            Console.WriteLine(message2);
            for (int i = 'z'; i >= 'a'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                message1 = message1.Replace(old1, new1);              
            }
            Console.WriteLine(message1);
            for(int i = 'Z'; i >= 'A'; i--)
            {
                char old1 = (char)i;
                char new1 = (char)(i + 1);
                message2 = message2.Replace(old1, new1);
            }
            Console.WriteLine(message2);

            Console.WriteLine();
            StringBuilder greetingBuilder =
            new StringBuilder("Hello from all the guys at Wrox Press. ", 150);
            greetingBuilder.Append("We do hope you enjoy this book as much as we enjoyed writing it");
            for (int i = 'z'; i >= 'a'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(Old, New);
            }

            for (int i = 'Z'; i >= 'A'; i--)
            {
                char Old = (char)i;
                char New = (char)(i + 1);
                greetingBuilder = greetingBuilder.Replace(Old, New);
            }
            Console.WriteLine("Encoded:\n" + greetingBuilder);

            StringBuilder sb = new StringBuilder("Hello");
            //StringBuilder sb = new StringBuilder(20);给定的容量创建一个空的类
            StringBuilder SB = new StringBuilder(100,500);
            SB.Capacity = 90;
        }
    }

