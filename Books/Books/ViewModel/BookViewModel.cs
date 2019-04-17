using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace Books
{
    public class BookViewModel : BaseViewModel
    {
        private string name;
        public string Name
        {
            get {return name; }
            set { SetValue(ref name, value); }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { SetValue(ref author, value); }
        }

        private string desc;
        public string Description
        {
            get { return desc; }
            set { SetValue(ref desc, value); }
        }

        private string publish;
        public string PublishDate
        {
            get { return publish; }
            set { SetValue(ref publish, value); }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set { SetValue(ref category, value); }
        }

        private string price;
        public string Price
        {
            get { return price; }
            set { SetValue(ref price, value); }
        }


        public BookViewModel() { }

        public BookViewModel(string name, string autor, string desc, string publish, string category, string price)
        {
            this.Name = name;
            this.Author = autor;
            this.Description = desc;
            this.PublishDate = publish;
            this.Category = category;
            this.Price = price;
        }

        public static ObservableCollection<BookViewModel> ReadBooksListData()
        {
            ObservableCollection<BookViewModel> myList = new ObservableCollection<BookViewModel>();
            string jsonText;

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                Console.WriteLine(path);
                string fileName = Path.Combine(path, Utils._FILE);
                using (var reader = new StreamReader(fileName))
                {
                    jsonText = reader.ReadToEnd();
                }

            }
            catch
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("Books.Data.Books.txt");
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();

                }
            }
            myList = JsonConvert.DeserializeObject<ObservableCollection<BookViewModel>>(jsonText);
            return myList;
        }

        public static void SaveBooksList(ObservableCollection<BookViewModel> saveList)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileName = Path.Combine(path, Utils._FILE);

            using (var writer = new StreamWriter(fileName, false))
            {
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }
    }
}
