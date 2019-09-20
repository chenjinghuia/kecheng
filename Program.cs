using System;

namespace 开发课程
{
    /*class bianliang
    {
        static int j = 20;
    }*/
    /*class lei
    {
        public int value;
    }*/
    public enum Day { Morning,Afternoon,Evening };
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

            /*lei x,y;//2.4.1值类型和引用类型
            x = new lei();
            x.value = 30;
            y = x;
            Console.WriteLine(y.value);
            y.value = 50;
            Console.WriteLine(x.value);*/

            /*string s1 = "my love";//2.4.4string类型
            string s2 = s1;
            Console.WriteLine("s1 is:" + s1);
            Console.WriteLine("s2 is:" + s2);
            s1 = "I love";
            Console.WriteLine("s1 is now:" + s1);
            Console.WriteLine("s2 is now:" + s2);*/

            /*Console.WriteLine("请输入你的分数判定等级");//if和else判定
            int input;
            input = int.Parse(Console.ReadLine());//两种方法转换整数类型，int.parse（）或者          
            if (input < 60&&input>=0)
            {
                Console.WriteLine("成绩不合格，请加倍努力！");
            }
            else if (input >= 60 && input < 70)
            {
                Console.WriteLine("成绩合格，再接再厉！");
            }
            else if (input >= 70 && input < 85)
            {
                Console.WriteLine("成绩良好，继续加油哦！");
            }
            else if (input >= 85 && input < 101)
            {
                Console.WriteLine("成绩优秀，继续保持！");
            }
            else
                Console.WriteLine("你的输入有误，请重新输入！");

            Console.WriteLine("请输入你的分数判定等级");//for循环方法                     
            for(int i=0;i<10;i++)
            {   int input; 
                input = int.Parse(Console.ReadLine());           
                switch(input/10)
                {
                    case 10:
                        Console.WriteLine("成绩优秀!");break;
                    case 9:
                        Console.WriteLine("成绩优秀!"); break;
                    case 8:
                        Console.WriteLine("成绩良好!"); break;
                    case 7:
                        Console.WriteLine("成绩合格!"); break;
                    case 6:
                        Console.WriteLine("成绩合格!"); break;
                    default:
                        Console.WriteLine("成绩不合格!"); break;

                }
            }*/

            /*int[] array = new int[] { 0, 1, 1, 3, 4, 6, 8, 10 };//foreach循环
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            int count = 0;
            foreach(int i in array)
            {
                count++;
                Console.WriteLine("array[{0}]:{1}",count,i);
            }*/

            /*int a = 10;//while循环方法
            while(a<20)
            {
                Console.WriteLine("a的值:" + a);
                a++;
            }
            Console.WriteLine();*/
                
            int x = (int)Day.Afternoon;//2.6枚举变量
            int y = (int)Day.Morning;
            Console.WriteLine("Afternoon:" + x);
            Console.WriteLine("Morning:" + y);
        

        }
    }
}
