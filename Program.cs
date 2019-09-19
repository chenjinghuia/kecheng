using System;

namespace 开发课程
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            Console.ReadLine();
            return;*/
            int d=10;
            Console.WriteLine(d);
            var name = "hello world";
            var age = 25;
            var shenme = true;
            Type nametype = name.GetType();
            Type agetype = age.GetType();
            Type shenmetype = shenme.GetType();
            Console.WriteLine("name is type:" + nametype.ToString());
            Console.WriteLine("name is type:" + nametype.ToString());

        }
    }
}
