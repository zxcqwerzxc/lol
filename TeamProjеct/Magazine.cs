using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjеct
{
    internal class Magazine
    {
        private string name;
    //    private Frequency frequency;
        private DateTime releaseDate;
        private int circulation;
        private Article[] articles;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //public Frequency Frequency
        //{
        //    get { return frequency; }
        //    set { frequency = value; }
        //}

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public int Circulation
        {
            get { return circulation; }
            set { circulation = value; }
        }

        public Article[] Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public double AverageRating
        {
            get
            {
                if (articles == null || articles.Length == 0)
                    return 0.0;
                return articles.Average(article => article.Rating);
            }
        }

        //public bool this[Frequency frequency]
        //{
        //    get { return frequency == frequency; }
        //}

        //public Magazine(string name, Frequency frequency, DateTime releaseDate, int circulation)
        //{
        //    Name = name;
        //    // frequency = frequency;
        //    ReleaseDate = releaseDate;
        //    Circulation = circulation;
        //    Articles = new Article[0];
        //}

        public Magazine()
        {
            name = "Default Magazine";
          //  frequency = Frequency.Monthly;
            releaseDate = DateTime.Now;
            circulation = 1000;
            articles = new Article[0];
        }

        public void AddArticles(params Article[] articles)
        {
            Articles = articles.Concat(articles).ToArray();
        }

        //public override string ToString()
        //{
        //    string articlesInfo = string.Join("\n", articles.Select(article => article.ToString()));
        //    return $"Name: {name}, Frequency: {frequency}, Release Date: {releaseDate}, Circulation: {circulation}\nArticles:\n{articlesInfo}";
        //}

        //public virtual string ToShortString()
        //{
        //    return $"Name: {name}, Frequency: {frequency}, Release Date: {releaseDate}, Circulation: {circulation}, Average Rating: {AverageRating}";
        //}
    }
}
