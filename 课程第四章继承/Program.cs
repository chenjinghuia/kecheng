using System;

namespace 第四章继承
{
    abstract class MyBase
    {
        public virtual void Method()
        {
            Console.WriteLine("这是基类的方法");
        }
        public  void YinCang()
        {
            Console.WriteLine("这是隐藏的方法");
        }
        public MyBase(string BaseName)
        {
            Name = BaseName;
        }
        protected string Name;
        virtual public void PrintName()
        {
            Console.WriteLine("MyBase的名字为： " + Name);
        }
        abstract public void chouxiang();
        private string foreName;
        public virtual string ForeName
        {
            get
            {
                return foreName;
            }
            set
            {
                foreName = value;
            }
        }
    }
    public interface IBankAccount
    {
        void PayIn(decimal amount);//存款
        bool Withdraw(decimal amount);//取款
        decimal Balance { get; }//零钱
    }
    public class SaverAccount:IBankAccount
    {
        private decimal balance;
        public void PayIn(decimal amount)
        {
            balance += amount;
        }
        public bool Withdraw(decimal amount)
        {
            if(balance >=amount)
            {
                balance -= amount;
                return true;
            }
            else
            Console.WriteLine("Withdrawa attempt failed(取款失败).");
            return false;
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
        public override string ToString()//??????????????
        {
            return string.Format("Venus Bank Saver:Balance ={0,6:C}", balance);
        }
    }
    public interface ITransferAccount : IBankAccount//派生一个转账的接口
    {
        bool TransferTo(IBankAccount destination, decimal amount);
    }

//定义一个当前Account的类
    public class CurrentAccount:ITransferAccount
    {
        private decimal balance;
        public void PayIn(decimal amount)
        {
            balance += amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return true;
            }
            else
            Console.WriteLine("Withdrawa attempt failed(取款失败).");
            return false;
        }
        public decimal Balance
        {
            get
            {
                return balance;
            }
        }
        public bool TransferTo(IBankAccount destination, decimal amount)
        {
            bool result;
            result = Withdraw(amount);
            if(result)
            {
                destination.PayIn(amount);
            }
            return result;
        }
        public override string ToString()
        {
            return string.Format("Venus Bank Saver:Balance ={0,6:C}", balance);
        }
    }
    
     class MyDiv:MyBase
    {
        public override void  Method()
        {
            Console.WriteLine("这是派生类重写的方法");
        }
        public new void YinCang()
        {
            Console.WriteLine("这是new的一个新的方法");
        }
         override public void chouxiang()
        {
            Console.WriteLine("这是抽象的一个新的方法");
        }
        public MyDiv(string DivName):base(DivName)
        {

        }
        override public void PrintName()
        {
            Console.WriteLine("MyDiv的名字为： " + Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDiv mydiv = new MyDiv("gouzao");
            mydiv.Method();
            mydiv.YinCang();
            mydiv.chouxiang();
            mydiv.PrintName();
//用接口存取款
            SaverAccount caozuo = new SaverAccount();//定义一个接口操作实例
            caozuo.PayIn(200);
            caozuo.Withdraw(100);
            Console.WriteLine(caozuo.ToString());
//接口可以引用任何实现该接口的类，构造接口数组，数组的每个元素都是不同的类。
            IBankAccount[] accounts = new IBankAccount[2];
            accounts[0] = new SaverAccount();
            accounts[0].PayIn(1000);
            accounts[0].Withdraw(500);
            Console.WriteLine(accounts[0].ToString());
//用新建转账接口进行转账，并输出转账账户和被转账账户的余额
            ITransferAccount[] zhuanzhang = new ITransferAccount[2];
            zhuanzhang[0]= new CurrentAccount();
            zhuanzhang[1] = new CurrentAccount();
            zhuanzhang[0].PayIn(500);
            zhuanzhang[1].PayIn(100);
            zhuanzhang[0].TransferTo(zhuanzhang[1], 200);
            Console.WriteLine("zhuanzhang[0]帐号的钱剩余： " + zhuanzhang[0].ToString());
            Console.WriteLine("zhuanzhang[1]帐号的钱剩余： " + zhuanzhang[1].ToString());

        }
    }
}
