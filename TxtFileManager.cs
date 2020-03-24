using System;
using System.IO;

namespace TestTask
{
    public class TxtFileManager : FileManager
    {
        private class TxtFileSource : ISource
        {
            public string ReadFromSource(string path)
            {
                var result = "";

                try
                {
                    using (StreamReader sr = new StreamReader(path, true))
                        while (sr.Peek() > 0)
                            result = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed {0}", ex.Message);
                }

                return result;
            }

            public void WriteToDestination(string path, string text)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                        sw.WriteLine(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed {0}", ex.Message);
                }
            }
        }

        public override ISource CreateStorage()
        {
            return new TxtFileSource();
        }
    }
}
