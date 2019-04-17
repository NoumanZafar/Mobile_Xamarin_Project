using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public class Book : BaseViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PublishDate { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }

        public Book() { }

        public Book(string name,string autor,string desc,string publish,string category,string price)
        {
            this.Name = name;
            this.Author = autor;
            this.Description = desc;
            this.PublishDate = publish;
            this.Category = category;
            this.Price = price;
        }
    }
}
