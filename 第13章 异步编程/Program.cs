using System;
using System.Threading;
using System.Threading.Tasks;

namespace 第13章_异步编程
{
    /*public class SearchItemResult : BindableBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { SetProperty(ref url, value); }
        }

        private string thumbnailUrl;
        public string ThumbnailUrl
        {
            get { return thumbnailUrl; }
            set { SetProperty(ref thumbnailUrl, value); }
        }

        private string source;
        public string Source
        {
            get { return source; }
            set { SetProperty(ref source, value); }
        }
    }
    public class SearchInfo : BindableBase
    {
        public SearchInfo()
        {
            list = new ObservableCollection<SearchItemResult>();
            list.CollectionChanged += delegate { OnPropertyChanged("List"); };
        }

        private string searchTerm;

        public string SearchTerm
        {
            get { return searchTerm; }
            set { SetProperty(ref searchTerm, value); }
        }

        private ObservableCollection<SearchItemResult> list;
        public ObservableCollection<SearchItemResult> List
        {
            get
            {
                return list;
            }
        }
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static string Greeting(string name)
        {
            Console.WriteLine("running greeting in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            Thread.Sleep(3000);
            return string.Format("Hello, {0}", name);
        }
        static Task<string> GreetingAsync(string name)
        {
            return Task.Run<string>(() =>
            {
                Console.WriteLine("running greetingasync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
                return Greeting(name);
            });
        }
        //asyc修饰符只能用于返回Task和void的方法，它不能用于程序的入口点，即Main方法不能使用async修饰符，await只能用于返回Task的方法
        private async static void CallerWithAsync()
        {
            Console.WriteLine("started CallerWithAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            string result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
            Console.WriteLine("finished GreetingAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        private async static void CallerWithAsync2()
        {
            Console.WriteLine("started CallerWithAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            Console.WriteLine(await GreetingAsync("Stephanie"));
            Console.WriteLine("finished GreetingAsync in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }
        //Task类的ContinueWith方法定义了任务完成后就调用的代码
        private static void CallerWithContinuationTask()
        {
            Console.WriteLine("started CallerWithContinuationTask in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);

            var t1 = GreetingAsync("Stephanie");


            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);
                Console.WriteLine("finished CallerWithContinuationTask in thread {0} and task {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            });

        }
        //按顺序调用异步方法
        private async static void MultipleAsyncMethods()
        {
            string s1 = await GreetingAsync("Stephanie");
            string s2 = await GreetingAsync("Matthias");
            Console.WriteLine("Finished both methods.\n Result 1: {0}\n Result 2: {1}", s1, s2);
        }
        //Task.WhenAll组合器方法
        private async static void MultipleAsyncMethodsWithCombinators1()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            await Task.WhenAll(t1, t2);
            Console.WriteLine("Finished both methods.\n Result 1: {0}\n Result 2: {1}", t1.Result, t2.Result);
        }
        //WhenAll方法返回的Task，是在其中一个传入方法的任务完成了就会返回Task
        private async static void MultipleAsyncMethodsWithCombinators2()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            Task<string> t2 = GreetingAsync("Matthias");
            string[] result = await Task.WhenAll(t1, t2);
            Console.WriteLine("Finished both methods.\n Result 1: {0}\n Result 2: {1}", result[0], result[1]);
        }
        private static Func<string, string> greetingInvoker = Greeting;

        static IAsyncResult BeginGreeting(string name, AsyncCallback callback, object state)
        {
            return greetingInvoker.BeginInvoke(name, callback, state);
        }

        static string EndGreeting(IAsyncResult ar)
        {
            return greetingInvoker.EndInvoke(ar);
        }
        private static async void ConvertingAsyncPattern()
        {
            string r = await Task<string>.Factory.FromAsync<string>(BeginGreeting, EndGreeting, "Angela", null);
            Console.WriteLine(r);
        }
        static async Task ThrowAfter(int ms, string message)
        {
            await Task.Delay(ms);
            throw new Exception(message);
        }
        //异步方法的异常处理
        private static async void HandleOneError()
        {
            try
            {
                await ThrowAfter(2000, "first");
            }
            catch (Exception ex)
            {
                Console.WriteLine("handled {0}", ex.Message);
            }
        }
        //多个异步方法的异常处理
        private static async void StartTwoTasks()
        {
            try
            {
                await ThrowAfter(2000, "first");
                await ThrowAfter(1000, "second"); // the second call is not invoked because the first method throws an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine("handled {0}", ex.Message);
            }
        }
        //WhenAll不管任务是否抛出异常，都会等到两个任务完成
        private async static void StartTwoTasksParallel()
        {
            Task t1 = null;
            try
            {
                t1 = ThrowAfter(2000, "first");
                Task t2 = ThrowAfter(1000, "second");
                await Task.WhenAll(t1, t2);
            }
            catch (Exception ex)
            {
                // just display the exception information of the first task that is awaited within WhenAll
                Console.WriteLine("handled {0}", ex.Message);
            }
        }
        //Exception属性的AggregateException类型定义InnerExceptions属性
        private static async void ShowAggregatedException()
        {
            Task taskResult = null;
            try
            {
                Task t1 = ThrowAfter(2000, "first");
                Task t2 = ThrowAfter(1000, "second");
                await (taskResult = Task.WhenAll(t1, t2));
            }
            catch (Exception ex)
            {
                // just display the exception information of the first task that is awaited within WhenAll
                Console.WriteLine("handled {0}", ex.Message);
                foreach (var ex1 in taskResult.Exception.InnerExceptions)
                {
                    Console.WriteLine("inner exception {0} from task {1}", ex1.Message, ex1.Source);
                }
            }
        }
    }
}
