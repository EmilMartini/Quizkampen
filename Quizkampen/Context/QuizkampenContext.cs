using Microsoft.EntityFrameworkCore;

namespace Quizkampen
{
    public class QuizkampenContext : DbContext
    {
        string accesskey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        string uri = "https://localhost:8081";
        string dbName = "Questions2";

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(uri, accesskey, dbName);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Questions");
            modelBuilder.Entity<Question>().OwnsMany(q => q.Answers);
        }
    }
}