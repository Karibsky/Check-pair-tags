using System;
using System.Data.SqlClient;
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
                var result = "";
                
                try
                {
                    var id = int.Parse(Configuration.GetDataSourceID());

                    using (DatabaseContext db = new DatabaseContext())
                        result = db.Texts
                                    .FirstOrDefault(t => t.TextID == id)
                                    .TextSource;
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
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
                    throw new Exception(ex.Message);
                }
            }
        }

        public override ISource CreateStorage()
        {
            return new DbFileSource();
        }
    }
}
