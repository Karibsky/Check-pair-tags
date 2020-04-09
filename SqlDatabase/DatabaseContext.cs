using SqlDatabase.Models;
using System.Data.Entity;

namespace SqlDatabase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("BracketsConnectionString") { }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Text> Texts { get; set; }
    }
}
