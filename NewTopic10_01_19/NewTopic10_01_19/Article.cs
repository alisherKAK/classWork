using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTopic10_01_19
{
    public partial class Article
    {
        /* * характериситики (поля-fields)/свойства
           * конструктор
           * методы доступа к полям (геттеры и сеттеры)
           * регулярные методы (приватные и публичные) */

        private string _title;
        private string _text;
        private string _author;
        private DateTime _publishedDate;
        private double _rating;
        private Comment[] _comments;

        static Article()
        {
            //работа с static
        }

        public Article() {}
        public Article(string title, string text)
        {
            _title = title;
            _text = text;
            _publishedDate = DateTime.Now;
        }

        #region Методы доступа(Геттеры и Сеттеры)
        // модификатор_доступа возв_тип НазваниеДействия(параметры) {тело; return возвр_тип;}
        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string title)
        {
            _title = title;
        }

        //И тд с другими полями
        #endregion

    }
}
