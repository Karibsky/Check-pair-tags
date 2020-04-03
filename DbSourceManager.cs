using System;
using System.Data.SqlClient;
using SqlDatabase;
using SqlDatabase.Models;

namespace Brackets
{
    class DbSourceManager : DataSourceManager
    {
        private class DbFileSource : ISource
        {
            public string ReadData()
            {
                var result = "";
                
                try
                {
                    var id = Configuration.GetDataSourceID();

                    using (DatabaseContext db = new DatabaseContext())
                    {
                        result = db.Texts.Find(int.Parse(id)).TextSource;
                        db.Dispose();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }

                return result;
            }

            public void WriteResult(bool result)
            {
                try
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
                catch(SqlException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        public override ISource CreateStorage()
        {
            return new DbFileSource();
        }
    }
}
