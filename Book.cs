using System;
using System.Collections.Generic;
using System.Text;

namespace Library.V2
{
    public class Book
    {
        public string Summary;
        public string Author;
      
        public int LogOfTime { get; set; }
        public string LastPerson { get; set; }


        public Book(string summary, string author)
        {
            this.Summary = summary;
            this.Author = author;
        }

        
    }
}
