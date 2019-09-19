using System;

namespace 开发课程
{
    /*class bianliang
    {
        static int j = 20;
    }*/
    class lei
    {
        public int value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            Console.ReadLine();
            return;*/

            /*int d=10;//2.3.2变量的推断
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

            /* for (int i=0;i<10;i++)//2.3.3.变量的作用域
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
             }
             int j = 30;
             Console.WriteLine(j);*/
            //Console.WriteLine(bianliang.j);

            //const int a = 100;//const是用来定义其值在使用过程中不会发生变化的变量

            lei x,y;//2.4.1值类型和引用类型
            x = new lei();
            x.value = 30;
            y = x;
            Console.WriteLine(y.value);
            y.value = 50;
            Console.WriteLine(x.value);


        }
    }
}
