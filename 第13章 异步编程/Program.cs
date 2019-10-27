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
    }
}
