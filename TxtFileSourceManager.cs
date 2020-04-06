using System;
using System.IO;

namespace Brackets
{
    public class TxtFileSourceManager : DataSourceManager, ISource
    {
        private class TxtFileSource : ISource
        {
            public string ReadData()
            {
                var result = "";

                try
                {
                    var path = Configuration.GetInputPath();

                    using (StreamReader sr = new StreamReader(path, true))
                        while (sr.Peek() > 0)
                            result = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return result;
            }

            public void WriteResult(bool result)
            {
                try
                {
                    var path = Configuration.GetOutputPath();

                    using (StreamWriter sw = new StreamWriter(path, true))
                        sw.WriteLine("Result: {0}", result);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public override ISource CreateStorage()
        {
            return new TxtFileSource();
        }
    }
}
