using System;
using System.IO;

namespace TestTask
{
    class WorkWithFiles
    {
        public static async void OpenFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path, true))
                    {
                        while (sr.Peek() > 0)
                            GenerateResult.PrintResult(await sr.ReadToEndAsync());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed {0}", ex.ToString());
                }
            }
        }

        public static async void WriteToFile(string result)
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
