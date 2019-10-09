using System;
using System.Text;
using System.Text.RegularExpressions;

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

            const string pattern = @"\bn";//查找以n开头的字
            const string pattern2 = @"ion\b";//查找以ion结尾的字
            const string pattern3 = @"\ba\S*ion\b";//以字母a开头，以序列ion结尾的所有字（序列\S*表示任意个不是空白字符的字符，*为限定符，其含义是前面的字符可以重复任意次）

        Find1();
        Console.ReadLine();
    }
    static void Find1()
    {
        const string text = @"XML has made a major impact in almost every aspect of 
            software development. Designed as an open, extensible, self-describing 
            language, it has become the standard for data and document delivery on 
            the web. The panoply of XML-related technologies continues to develop 
            at breakneck speed, to enable validation, navigation, transformation, 
            linking, querying, description, and messaging of data.";
        const string pattern = @"\bn\S*ion\b";
        MatchCollection matches = Regex.Matches(text, pattern,
           RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace |
           RegexOptions.ExplicitCapture);
        WriteMatches(text, matches);
    }

    static void Find2()
    {
        const string text = @"XML has made a major impact in almost every aspect of 
            software development. Designed as an open, extensible, self-describing 
            language, it has become the standard for data and document delivery on 
            the web. The panoply of XML-related technologies continues to develop 
            at breakneck speed, to enable validation, navigation, transformation, 
            linking, querying, description, and messaging of data.";
        const string pattern = @"\bn";
        MatchCollection matches = Regex.Matches(text, pattern,
          RegexOptions.IgnoreCase);
        WriteMatches(text, matches);
    }
    static void WriteMatches(string text,MatchCollection matches)
    {
        Console.WriteLine("Original text was: \n\n" + text + "\n");
        Console.WriteLine("No. of matches: " + matches.Count);
        foreach(Match nextMatch in matches)
        {
            int index = nextMatch.Index;
            string result = nextMatch.ToString();
            int charsBefore = (index < 5) ? index : 5;
            int fromEnd = text.Length - index - result.Length;
            int charsAfter = (fromEnd < 5) ? fromEnd : 5;
            int charsToDisplay = charsBefore + charsAfter + result.Length;

            Console.WriteLine("Index: {0}, \tString: {1}, \t{2}",
               index, result,
               text.Substring(index - charsBefore, charsToDisplay));
        }
    }
    }

