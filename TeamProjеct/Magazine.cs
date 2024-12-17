using System;
using System.Collections;

namespace TeamProject
{
    internal class Magazine : Edition
    {
        private Frequency frequency;
        private ArrayList editors;
        private ArrayList articles;

        public string Name
        {
            get { return Title; }
            set { Title = value; }
        }

        public Frequency Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public ArrayList Editors
        {
            get { return editors; }
            set { editors = value; }
        }

        public ArrayList Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public double AverageRating
        {
            get
            {
                if (articles == null || articles.Count == 0)
                    return 0.0;
                double totalRating = 0.0;
                foreach (Article article in articles)
                {
                    totalRating += article.Rating;
                }
                return totalRating / articles.Count;
            }
        }

        public Magazine(string name, Frequency frequency, DateTime releaseDate, int circulation)
            : base(name, releaseDate, circulation)
        {
            Frequency = frequency;
            Editors = new ArrayList();
            Articles = new ArrayList();
        }

        public Magazine()
            : base()
        {
            frequency = Frequency.Monthly;
            editors = new ArrayList();
            articles = new ArrayList();
        }

        public void AddArticles(params Article[] newArticles)
        {
            articles.AddRange(newArticles);
        }

        public void AddEditors(params Person[] newEditors)
        {
            editors.AddRange(newEditors);
        }

        public override string ToString()
        {
            string articlesInfo = string.Join("\n", articles.Cast<Article>().Select(article => article.ToString()));
            string editorsInfo = string.Join("\n", editors.Cast<Person>().Select(editor => editor.ToString()));
            return $"Name: {Title}, Frequency: {frequency}, Release Date: {ReleaseDate}, Circulation: {Circulation}\nEditors:\n{editorsInfo}\nArticles:\n{articlesInfo}";
        }

        public override string ToShortString()
        {
            return $"Name: {Title}, Frequency: {frequency}, Release Date: {ReleaseDate}, Circulation: {Circulation}, Average Rating: {AverageRating}";
        }

        public override object DeepCopy()
        {
            Magazine copy = (Magazine)this.MemberwiseClone();
            copy.Editors = new ArrayList(editors.Cast<Person>().Select(editor => (Person)editor.DeepCopy()).ToArray());
            copy.Articles = new ArrayList(articles.Cast<Article>().Select(article => (Article)article.DeepCopy()).ToArray());
            return copy;
        }

        public Edition Edition
        {
            get { return new Edition(Title, ReleaseDate, Circulation); }
            set
            {
                Title = value.Title;
                ReleaseDate = value.ReleaseDate;
                Circulation = value.Circulation;
            }
        }

        public IEnumerable GetArticlesWithRatingAbove(double rating)
        {
            foreach (Article article in articles)
            {
                if (article.Rating > rating)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetArticlesWithTitleContaining(string substring)
        {
            foreach (Article article in articles)
            {
                if (article.Title.Contains(substring))
                {
                    yield return article;
                }
            }
        }
    }
}
