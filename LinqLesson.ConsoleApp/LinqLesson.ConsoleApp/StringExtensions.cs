using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLesson.ConsoleApp
{
    public static class StringExtensions
    {
        public static int GetLength(this string data)
        {
            return data.Length;
        }
    }
}
