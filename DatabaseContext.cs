using System.Data.Entity;
using TestTask.Models;

namespace TestTask
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ConnectionString") { }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Text> Texts { get; set; }
    }
}