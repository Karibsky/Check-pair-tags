using System;
using System.Collections.Generic;
using System.Linq;
using SqlDatabase;
using SqlDatabase.Models;

namespace Brackets.Data
{
    public static class BracketsDataService
    {
        public static IEnumerable<LogDto> GetChecksHistoryList()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var viewModel = db.Logs.AsEnumerable().Select(x => new LogDto
                {
                    LogID = x.LogID,
                    Time = x.Time,
                    Result = x.Result
                });

                return viewModel.ToList();
            }
        }

        public static string GetTextByID(int id)
        {
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

        public static void SaveResultToDatabase(bool result)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Log log = new Log { Result = result, Time = DateTime.Now };
                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
    }
}
