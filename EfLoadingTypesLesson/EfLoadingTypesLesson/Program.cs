using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfLoadingTypesLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            using(var context = new DataContext())
            {
                //books = context.Books.ToList();
                //var author = books.FirstOrDefault().Author;
                var author = context.Authors.FirstOrDefault();
                context.Entry(author).Collection("Books").Load();
            }
        }
    }
}
