using System;

namespace TestTask
{
    class DbFileManager : FileManager
    {
        private class DbFileSource : ISource
        {
            public string ReadFromSource(string id)
            {
                throw new NotImplementedException();
            }

            public void WriteToDestination(string path, string text)
            {
                throw new NotImplementedException();
            }
        }

        public override ISource CreateStorage()
        {
            return new DbFileSource();
        }
    }
}
