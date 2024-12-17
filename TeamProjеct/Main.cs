using System;
using System.Diagnostics;
using System.Collections;
using System.Linq;

namespace TeamProject
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                // Создание объекта типа Magazine
                Magazine magazine = new Magazine("Лучший журнал мира", Frequency.Monthly, DateTime.Now, 5000);
                Console.WriteLine(magazine.ToShortString());

                // Присвоение значений всем свойствам и вывод данных с помощью ToString()
                magazine.Name = "Журнал для гениев программирования на C#";
                magazine.Frequency = Frequency.Monthly;
                magazine.ReleaseDate = new DateTime(2024, 11, 22);
                magazine.Circulation = 10000;
                magazine.Articles = new ArrayList
                {
                    new Article("Значение программирования в жизни котов", 4.5, new Person("Алиса", "Котикова", new DateTime(1985, 5, 23))),
                    new Article("Придумайте название сами", 4.8, new Person("Боб", "Кириешков", new DateTime(1990, 8, 12)))
                };
                Console.WriteLine(magazine.ToString());

                // Добавление статей с помощью AddArticles и вывод данных с помощью ToString()
                magazine.AddArticles(
                    new Article("Путешествие до кухни и обратно. 5 способов сделать это проще", 4.9, new Person("Денис", "Кустиков", new DateTime(1975, 3, 15))),
                    new Article("Сила тайги", 4.7, new Person("Даник", "Лепеш", new DateTime(1980, 7, 30)))
                );
                Console.WriteLine(magazine.ToString());

                // Создание двух объектов типа Edition с совпадающими данными
                Edition edition1 = new Edition("Издание 1", new DateTime(2024, 11, 22), 10000);
                Edition edition2 = new Edition("Издание 1", new DateTime(2024, 11, 22), 10000);

                // Проверка, что ссылки на объекты не равны, а объекты равны
                Console.WriteLine($"Ссылки равны: {ReferenceEquals(edition1, edition2)}");
                Console.WriteLine($"Объекты равны: {edition1.Equals(edition2)}");
                Console.WriteLine($"Хэш-код объекта 1: {edition1.GetHashCode()}");
                Console.WriteLine($"Хэш-код объекта 2: {edition2.GetHashCode()}");

                // Присвоение свойству с тиражом издания некорректного значения в блоке try/catch
                try
                {
                    magazine.Circulation = -5000;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }

                // Создание объекта типа Magazine, добавление элементов в списки статей и редакторов журнала и вывод данных объекта Magazine
                Magazine newMagazine = new Magazine("Научный журнал", Frequency.Weekly, new DateTime(2024, 12, 1), 2000);
                newMagazine.AddEditors(
                    new Person("Иван", "Иванов", new DateTime(1970, 1, 1)),
                    new Person("Петр", "Петров", new DateTime(1980, 2, 2))
                );
                newMagazine.AddArticles(
                    new Article("Научные открытия", 5.0, new Person("Анна", "Смирнова", new DateTime(1990, 3, 3))),
                    new Article("Технологии будущего", 4.8, new Person("Сергей", "Сергеев", new DateTime(1985, 4, 4)))
                );
                Console.WriteLine(newMagazine.ToString());

                // Вывод значения свойства типа Edition для объекта типа Magazine
                Console.WriteLine(newMagazine.Edition.ToString());

                // Создание полной копии объекта Magazine с помощью метода DeepCopy()
                Magazine copiedMagazine = (Magazine)newMagazine.DeepCopy();

                // Изменение данных в исходном объекте Magazine и вывод копии и исходного объекта
                newMagazine.Name = "Измененный журнал";
                newMagazine.Circulation = 3000;
                Console.WriteLine("Исходный объект:");
                Console.WriteLine(newMagazine.ToString());
                Console.WriteLine("Копия объекта:");
                Console.WriteLine(copiedMagazine.ToString());

                // Вывод списка всех статей с рейтингом больше заданного значения с помощью итератора
                double ratingThreshold = 4.8;
                Console.WriteLine($"Статьи с рейтингом больше {ratingThreshold}:");
                foreach (Article article in newMagazine.GetArticlesWithRatingAbove(ratingThreshold))
                {
                    Console.WriteLine(article.ToString());
                }

                // Вывод списка статей, в названии которых есть заданная строка, с помощью итератора
                string titleSubstring = "наука";
                Console.WriteLine($"Статьи с названием, содержащим '{titleSubstring}':");
                foreach (Article article in newMagazine.GetArticlesWithTitleContaining(titleSubstring))
                {
                    Console.WriteLine(article.ToString());
                }

                // Сравнение времени выполнения операций с массивами
                int size = 1000; // Размер массива

                // Создание одномерного массива
                Article[] oneDimArray = new Article[size];

                // Создание двумерного прямоугольного массива
                Article[,] twoDimArray = new Article[size, size];

                // Создание двумерного ступенчатого массива
                Article[][] jaggedArray = new Article[size][];
                for (int i = 0; i < size; i++)
                {
                    jaggedArray[i] = new Article[size];
                }

                // Stopwatch — это класс, который используется для измерения времени выполнения операций
                Stopwatch stopwatch = new Stopwatch();

                // Заполнение одномерного массива
                stopwatch.Start(); // начинаем измерение времени
                for (int i = 0; i < size; i++)
                {
                    oneDimArray[i] = new Article();
                }
                stopwatch.Stop(); // конец измерения времени
                Console.WriteLine($"Одномерный массив: {stopwatch.ElapsedMilliseconds} мс");

                // Заполнение двумерного прямоугольного массива
                stopwatch.Restart(); // перезапуск таймера
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        twoDimArray[i, j] = new Article();
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"Двумерный прямоугольный массив: {stopwatch.ElapsedMilliseconds} мс");

                // Заполнение двумерного ступенчатого массива
                stopwatch.Restart();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        jaggedArray[i][j] = new Article();
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"Двумерный ступенчатый массив: {stopwatch.ElapsedMilliseconds} мс");

            }
            finally
            {
                Console.WriteLine("\n");
            }
        }
    }
}
