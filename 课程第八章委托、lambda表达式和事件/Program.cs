﻿using System;
using System.Collections.Generic;

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
        //多播委托
        public static void MultiplyBytwo(double value)
        {
            double result = value * 2;
            Console.WriteLine("Multiplying by Moloperations:{0} gives {1}", value, result);
        }
        public static void square(double value)
        {
            double result = value * value;
            Console.WriteLine("Squaring:{0} gives {1}", value, result);
        }
    }
    delegate double DoubleOp(double x);//定义委托

    class BubbleSorter
    {
        static public void Sort<T>(IList<T> sortArray,Func<T,T,bool> comparison)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (comparison(sortArray[i + 1], sortArray[i]))
                    {
                        T temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public override string ToString()
        {
            return string.Format("{0}, {1:C}", Name, Salary);
        }
        public static bool CompareSalary(Employee e1, Employee e2)
        {
            return e1.Salary < e2.Salary;
        }
    }
    public class CarInfoEventArgs : EventArgs
    {
        public string Car { get; private set; }
        public CarInfoEventArgs(string car)
        {
            this.Car = car;
        }
    }
    public class CarDealer
    {
        public event EventHandler<CarInfoEventArgs> NewCarInfo;
        public void NewCar(string car)
        {
            Console.WriteLine("CarDealer,new car {0}", car);
            RaiseNewCarInfo(car);
        }
        protected virtual void RaiseNewCarInfo(string car)
        {
            EventHandler<CarInfoEventArgs> newCarInfo = NewCarInfo;
            if (newCarInfo != null)
            {
                newCarInfo(this, new CarInfoEventArgs(car));
            }
        }
    }
    public class Consumer
    {
        private string name;
        public Consumer(string name)
        {
            this.name = name;
        }
        public void NewCarIsHere(object sender,CarInfoEventArgs e)
        {
            Console.WriteLine("{0}: car {1} is new", name, e.Car);
        }
    }
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
            Func<double, double>[] Operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };
            for (int i=0;i<operations .Length;i++)
            {
                Console.WriteLine("Using operations[{0}]:", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }
            Console.WriteLine();


            Employee[] employees =
            {
            new Employee("Bugs Bunny", 20000),
            new Employee("Elmer Fudd", 10000),
            new Employee("Daffy Duck", 25000),
            new Employee("Wile Coyote", 1000000.38m),
            new Employee("Foghorn Leghorn", 23000),
            new Employee("RoadRunner", 50000)
            };
            BubbleSorter.Sort(employees, Employee.CompareSalary);
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine();
            Action<double> Moloperations = MathOperations.MultiplyBytwo;
            Moloperations += MathOperations.square;
            ProcessAndDisplayNumber3(Moloperations, 2.0);
            ProcessAndDisplayNumber3(Moloperations, 7.94);
            ProcessAndDisplayNumber3(Moloperations, 1.414);
            Console.WriteLine();


            string mid = ",好喜欢,";//lambda表达式
            Func<string, string> lambda = param =>
               {
                   param += mid;
                   param += "于瑶瑶.";
                   return param;
               };
            Console.WriteLine(lambda("陈灰灰"));
            Console.WriteLine();
            Func<string, string> oneParam = s =>
               string.Format("加进去的是：" + s.ToUpper());
            Console.WriteLine(oneParam("定义test参数"));
            Console.WriteLine();
            Func<double, double, double> twoParams = (a, b) => a * b;
            Console.WriteLine(twoParams(3, 2));
            int someVal = 5;
            Func<int, int> f = c => c + someVal;
            Console.WriteLine(f(5));

            /*var values = new List<int> { 10, 20, 30 };
            var funcs = new List<Func<int>> ();
            foreach (var val in values)
            {
                funcs.Add(() => val);
            }
            foreach(var f in funcs)
            {
                Console.WriteLine((f()));
            }*/
            Console.WriteLine();
            var dealer = new CarDealer();
            var michael = new Consumer("Michael");
            dealer.NewCarInfo += michael.NewCarIsHere;
            dealer.NewCar("法拉利");
            var john = new Consumer("John");
            dealer.NewCarInfo += john.NewCarIsHere;
            dealer.NewCar("宝马");
            dealer.NewCarInfo -= michael.NewCarIsHere;
            dealer.NewCar("新车");
            
        }
        static void ProcessAndDisplayNumber(DoubleOp action,double value)//把一个委托作为其第一个参数
        {
            double result = action(value);//调用ProcessAndDisplayNumber方法
            Console.WriteLine("value is {0},result of operation is {1}", value, result);
        }
        static void ProcessAndDisplayNumber2(Func<double,double>action,double value)
        {
            double result = action(value);//调用ProcessAndDisplayNumber方法
            Console.WriteLine("value is {0},result of operation is {1}", value, result);
        }
        static void ProcessAndDisplayNumber3(Action<double> action,double value)
        {
            Console.WriteLine();
            Console.WriteLine("输入的vlaue的值为： " + value);
            action(value);
        }
    }
}
