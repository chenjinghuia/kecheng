using System;

namespace 第12章动态语言扩展
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GetFullName()
        {
            return string.Concat(FirstName, " ", LastName);
        }
    }
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
            var staticPerson = new Person();
            dynamic dynamicPerson = new Person();
            //staticPerson.GetFullName("John","Smith");
            //dynamicPerson.GetFullName("John", "Smith");  
            Dongtai();
            Houtai();
        }
        static void Dongtai()
        {
            dynamic dyn = 100;
            Console.WriteLine(dyn.GetType());
            Console.WriteLine(dyn);
            dyn = "This is a string";
            Console.WriteLine(dyn.GetType());
            Console.WriteLine(dyn);
            dyn = new Person() { FirstName = "Bugs", LastName = "Bunny" };
            Console.WriteLine(dyn.GetType());
            Console.WriteLine("{0} {1}",dyn.FirstName,dyn.LastName);
        }
        static void Houtai()
        {
            StaticClass staticObject = new StaticClass();
            DynamicClass dynamicObject = new DynamicClass();
            Console.WriteLine(staticObject.IntValue);
            Console.WriteLine(dynamicObject.DynValue);

        }
        class StaticClass
        {
            public int IntValue = 100;
        }
        class DynamicClass
        {
            public dynamic DynValue = 100;
        }
    }
}
