using System;

namespace TeamProject
{
    internal class Article : ICloneable
    {
        public Person Author { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        // Конструктор с параметрами
        public Article(string title, double rating, Person author)
        {
            Author = author;
            Title = title;
            Rating = rating;
        }

        // Конструктор без параметров с значениями по умолчанию
        public Article()
        {
            Author = new Person();
            Title = "Untitled Article";
            Rating = 0.0;
        }

        // Перегруженная версия метода ToString()
        public override string ToString()
        {
            return $"Article Title: {Title}, Rating: {Rating}, Author: {Author}";
        }

        // Метод для глубокого копирования
        public object Clone()
        {
            return new Article(Title, Rating, (Person)Author.DeepCopy());
        }

        // Метод для глубокого копирования
        public Article DeepCopy()
        {
            return new Article(Title, Rating, (Person)Author.DeepCopy());
        }
    }
}
