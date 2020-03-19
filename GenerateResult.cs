using System;
using System.IO;

namespace TestTask
{
    class GenerateResult
    {
        public static async void OpenFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path, true))
                    {
                        var line = "";
                        while ((line = await sr.ReadLineAsync()) != null)
                            PrintResult(line);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed {0}", ex.ToString());
                }
            }
        }

        private static void PrintResult(string expression)
        {
            var result = string.Format("Expression: {0} Result: {1}", expression, CheckExpression.IsCorrect(expression));
            Console.WriteLine(result);
            WriteToFile(result);
        }

        private static async void WriteToFile(string result)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Configuration.GetOutputPath(), true))
                    await sw.WriteLineAsync(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed {0}", ex.ToString());
            }
        }

    }
}
