using System.IO;

namespace Brackets
{
    public class TxtFileSourceManager : DataSourceManager
    {
        private class TxtFileSource : ISource
        {
            public string ReadData()
            {
                var result = "";

                var path = Configuration.GetInputPath();

                using (StreamReader sr = new StreamReader(path, true))
                    while (sr.Peek() > 0)
                        result = sr.ReadToEnd();

                return result;
            }

            public void WriteResult(bool result)
            {
                var path = Configuration.GetOutputPath();

                using (StreamWriter sw = new StreamWriter(path, true))
                    sw.WriteLine("Result: {0}", result);
            }
        }

        public override ISource CreateStorage()
        {
            return new TxtFileSource();
        }
    }
}
