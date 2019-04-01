using System;

namespace Hotel.Sevices
{
    public static class CodeGenerator
    {
        public static string Code { get; set; }

        public static void GenerateCode()
        {
            Random random = new Random();

            Code = (random.Next(0, 9).ToString() + random.Next(0, 9).ToString() +
                        random.Next(0, 9).ToString() + random.Next(0, 9).ToString());
        }
    }
}
