using System;
using System.IO;

namespace TestTask
{
    class FileSource : ISource
    {
        public string ReadFromSource(string path)
        {
            var result = "";

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path, true))
                    {
                        while (sr.Peek() > 0)
                            result = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed {0}", ex.ToString());
                }
            }

            return result;
        }

        public void WriteToDestination(string path, string result)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                    sw.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed {0}", ex.ToString());
            }
        }
    }
}
