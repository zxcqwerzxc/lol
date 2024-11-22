using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjеct
{
    internal class Article
    {
        //класс персон public Person Author { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        // Конструктор с параметрами
        public Article(string title, double rating)//Person author,
        {
            //       Author = author;
            Title = title;
            Rating = rating;
        }

        // Конструктор без параметров с значениями по умолчанию
        public Article()
        {
            //      Author = new Person("Unknown Author", 0);
            Title = "Untitled Article";
            Rating = 0.0;
        }

        // Перегруженная версия метода ToString()
        public override string ToString()
        {
            return $"Article Title: {Title}  Rating: {Rating}";//Author: {Author}
        }
    }
}
