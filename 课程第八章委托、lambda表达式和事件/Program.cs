﻿using System;

namespace 课程第八章委托_lambda表达式和事件
{
    public delegate string GetAString();
    struct Currency
    {
        public uint Dollars;
        public ushort Cents;
        public Currency(uint dollors,ushort cents)
        {
            this.Dollars = dollors;
            this.Cents = cents;
        }
        public override string ToString()
        {
            return string.Format("${0}.{1,2:00}",Dollars,Cents);
        }
        public static string GetCurrencyUnit()
        {
            return "Dollar";
        }
        public static explicit operator Currency (float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }
        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }
        public static implicit operator Currency(uint value)
        {
            return new Currency(value, 0);
        }
        public static implicit operator uint (Currency value)
        {
            return value.Dollars;
        }
    }
    class MathOperations
    {
        public static double MultiplyByTwo(double value)
        {
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }
    }
    delegate double DoubleOp(double x);//定义委托
   
    class Program
    {
        static void Main(string[] args)
        {
            int x = 40;
            GetAString firstStringMethod = new GetAString(x.ToString);
            Console.WriteLine(firstStringMethod());
            Console.WriteLine(x.ToString());//等同于firstStringMethod()
            Console.WriteLine();
            GetAString FirstStringMethod = x.ToString;
            Console.WriteLine(FirstStringMethod());
            Currency balance = new Currency(34, 50);
            FirstStringMethod = balance.ToString;
            Console.WriteLine(FirstStringMethod());
            FirstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine(FirstStringMethod());
            Console.WriteLine();
            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };//把委托的事例放在数组中
            for(int i=0;i<operations .Length;i++)
            {
                Console.WriteLine("Using operations[{0}]:", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }
        }
        static void ProcessAndDisplayNumber(DoubleOp action,double value)//把一个委托作为其第一个参数
        {
            double result = action(value);//调用ProcessAndDisplayNumber方法
            Console.WriteLine("value is {0},result of operation is {1}", value, result);
        }
    }
}
