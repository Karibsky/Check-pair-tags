using SqlDatabase.Models;
using System.Collections.Generic;
using System.Linq;

namespace SqlDatabase
{
    public static class BracketsDataService
    {
        public static IEnumerable<Log> GetChecksHistoryList()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Logs.ToList();
            }
        }
    }
}
