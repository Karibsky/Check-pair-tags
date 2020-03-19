using System;
using System.IO;

namespace TestTask
{
    class GenerateResult
    {
        public static void GetResult(string filename)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

            try
            {
                using (StreamReader sr = new StreamReader(path))
                    while (sr.Peek() > 0)
                    {
                        var expression = sr.ReadToEnd();
                        Console.WriteLine(expression + " " + CheckExpression.IsCorrect(expression, new Brackets()));
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed {0}", ex.ToString());
            }

            Console.ReadKey();
        }

    }
}
