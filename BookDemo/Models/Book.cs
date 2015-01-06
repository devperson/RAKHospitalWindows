using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookDemo.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public virtual double Price { get; set; }

        public override bool Equals(object obj)
        {
            var b = obj as Book;

            return this.ISBN == b.ISBN;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
