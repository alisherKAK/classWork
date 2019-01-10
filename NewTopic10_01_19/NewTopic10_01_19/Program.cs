using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTopic10_01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //тип имя = new Конструктор(параметры) -- формула создания объекта
            Article article = new Article();

            article.SetManyAuthors("Admin", "Moderator");

            string numberAsString = "k";
            int number;

            if (int.TryParse(numberAsString, out number))
            {
                //Если получилось работает
            }

            int[] numbers = { 1, 2, 3, 4, 5 };
            Array.Resize(ref numbers, 10);
        }
    }

    public partial class Article
    {
        public string ReturnMainData()
        {
            return $"{_title} {_text}";
        }

        public void SetManyAuthors(params string[] authorsNames)
        {
            foreach(var author in authorsNames)
            {
                _author += " " + author;
            }
            //_author = string.Join(" ", authorsNames);
            //_author.Trim();
        }

        public bool IsTitleSet(ref string title)
        {
            if(string.IsNullOrEmpty(_title))
            {
                title = "";
                return false;
            }
            title = _title;
            return true;
        }
    }
}
