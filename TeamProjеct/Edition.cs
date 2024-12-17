using System;
using TeamProjеct;

namespace TeamProject
{
    class Edition : IRateAndCopy
    {
        // Поля
        protected string title;
        protected DateTime releaseDate;
        protected int circulation;

        // Конструктор с параметрами
        public Edition(string title, DateTime releaseDate, int circulation)
        {
            this.title = title;
            this.releaseDate = releaseDate;
            this.circulation = circulation; // Используем свойство для проверки
        }

        // Конструктор по умолчанию
        public Edition()
        {
            title = "Untitled";
            releaseDate = DateTime.Now;
            circulation = 0;
        }

        // Свойства
        public string Title
        {
            get { return title; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Заголовок не может быть пустым");
                }
                else
                { title = value; }
            }

        }

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentException("Дата выхода не может быть в прошлом.");
                }
                releaseDate = value;
            }
        }


        public int Circulation
        {
            get { return circulation; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Тираж не может быть отрицательным. Допустимые значения: 0 и выше.");
                circulation = value;
            }
        }

        // Виртуальный метод для глубокого копирования
        public virtual object DeepCopy()
        {
            return new Edition(this.title, this.releaseDate, this.circulation);
        }

        // Переопределение метода Equals
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            Edition other = (Edition)obj;
            return title == other.title && releaseDate == other.releaseDate && circulation == other.circulation;
        }

        // Переопределение операций == и !=
        public static bool operator ==(Edition e1, Edition e2)
        {
            if (ReferenceEquals(e1, e2))
                return true;
            if (ReferenceEquals(e1, null) || ReferenceEquals(e2, null))
                return false;
            return e1.Equals(e2);
        }

        public static bool operator !=(Edition e1, Edition e2)
        {
            return !(e1 == e2);
        }

        // Переопределение метода GetHashCode
        public override int GetHashCode()
        {
            return (title, releaseDate, circulation).GetHashCode();
        }

        // Переопределенная версия метода ToString
        public override string ToString()
        {
            return $"Title: {title}, Release Date: {releaseDate.ToShortDateString()}, Circulation: {circulation}";
        }

        // Виртуальный метод ToShortString
        public virtual string ToShortString()
        {
            return $"Title: {title}, Release Date: {releaseDate.ToShortDateString()}, Circulation: {circulation}";
        }

        // Свойство Rating из интерфейса IRateAndCopy
        public double Rating { get; }

        // Метод DeepCopy из интерфейса IRateAndCopy
        object IRateAndCopy.DeepCopy()
        {
            return this.DeepCopy();
        }
    }
}
