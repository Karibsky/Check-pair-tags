using System;
using System.IO;

namespace TestTask
{
    class WorkWithFiles : ISource
    {
        public async void ReadFromSource(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    GenerateResult generateResult = new GenerateResult();
                    using (StreamReader sr = new StreamReader(path, true))
                    {
                        while (sr.Peek() > 0)
                            generateResult.PrintResult(await sr.ReadToEndAsync());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed {0}", ex.ToString());
                }
            }
        }

        public async void WriteToSource(string result)
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
