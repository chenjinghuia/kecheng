using System;

namespace 开发课程
{
    class bianliang
    {
        static int j = 20;
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            Console.ReadLine();
            return;*/

            /*int d=10;
            Console.WriteLine(d);
            var name = "hello world";
            var age = 25;
            var shenme = true;
            Type nametype = name.GetType();
            Type agetype = age.GetType();
            Type shenmetype = shenme.GetType();
            Console.WriteLine("name is type:" + nametype.ToString());
            Console.WriteLine("name is type:" + agetype.ToString())
            Console.WriteLine("name is type:" + shenmetype.ToString());*/

            for (int i=0;i<10;i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            for (int i = 9;i>= 0;i--)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            /*int j=20;
            for(int i=0;i<10;i++)
            {
                int j = 30;
                Console.WriteLine(i + j);
            }*/
            int j = 30;
            Console.WriteLine(j);

        }
    }
}
