using System;
using System.Diagnostics;
using TeamProjеct;

public class Program
{
    public static void Main()
    {
        try
        {
            // Создание объекта типа Magazine
            Magazine magazine = new Magazine("Лучший журнал мира", Frequency.Monthly, DateTime.Now, 5000);
            Console.WriteLine(magazine.ToShortString());

            // Вывод значений индексатора для Frequency.Weekly, Frequency.Monthly и Frequency.Yearly
            Console.WriteLine($"Weekly: {magazine[Frequency.Weekly]}");
            Console.WriteLine($"Monthly: {magazine[Frequency.Monthly]}");
            Console.WriteLine($"Yearly: {magazine[Frequency.Yearly]}");

            // Присвоение значений всем свойствам и вывод данных с помощью ToString()
            magazine.Name = "Журнал для гениев программирования на C#";
            magazine.Frequency = Frequency.Monthly;
            magazine.ReleaseDate = new DateTime(2024, 11, 22);
            magazine.Circulation = 10000;
            magazine.Articles = new Article[]
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
            //Stopwatch — это класс, который используется для измерения времени выполнения операций
            Stopwatch stopwatch = new Stopwatch();

            // Заполнение одномерного массива
            stopwatch.Start();//начинаем измерение времени
            for (int i = 0; i < size; i++)
            {
                oneDimArray[i] = new Article();
            }
            stopwatch.Stop();//конец измерения времени. Далее аналогично
            Console.WriteLine($"Одномерный массив: {stopwatch.ElapsedMilliseconds} мс");

            // Заполнение двумерного прямоугольного массива
            stopwatch.Restart();//перезапуск таймера
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
