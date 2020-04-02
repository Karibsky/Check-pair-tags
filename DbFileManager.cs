using System;
using TestTask.Models;

namespace TestTask
{
    class DbFileManager : FileManager
    {
        private class DbFileSource : ISource
        {
            public string ReadFromSource(string id)
            {
                DatabaseContext db = new DatabaseContext();

                return db.Texts.Find(int.Parse(id)).TextSource;
            }

            public void WriteToDestination(bool result, string path)
            {
                using(DatabaseContext db = new DatabaseContext())
                {
                    Log log = new Log 
                    { 
                        Time = DateTime.Now, 
                        Result = result 
                    };

                    db.Logs.Add(log);
                    db.SaveChanges();
                }
            }
        }

        public override ISource CreateStorage()
        {
            return new DbFileSource();
        }
    }
}
