using System;
using System.Linq;
using SqlDatabase;
using SqlDatabase.Models;

namespace Brackets
{
    public class DbSourceManager : DataSourceManager
    {
        private class DbFileSource : ISource
        {
            public string ReadData()
            {
                var id = int.Parse(Configuration.GetDataSourceID());

                using (DatabaseContext db = new DatabaseContext())
                {
                    var result = db.Texts
                                .FirstOrDefault(t => t.TextID == id);

                    if (result != null)
                        return result.TextSource;
                    else
                        throw new Exception($"Text with id = {id} not found in database");
                }
            }

            public void WriteResult(bool result)
            {
                using (DatabaseContext db = new DatabaseContext())
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
