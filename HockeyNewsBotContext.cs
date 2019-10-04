using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HockeyNewsBot
{
    public class HockeyNewsBotContext : DbContext
    {
        public HockeyNewsBotContext() : base()
        {
            Database.EnsureCreated();
        }
        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=hockeynewsbot.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasIndex(a => a.UuId)
                .IsUnique();
        }
    }

    public class Article
    {
        [Key]
        public string ArticleId { get; set; }
        public string UuId { get; set; }
        public string Headline { get; set; }
        public string Source { get; set; }
        public string PublishedOn { get; set; }
        public string Value { get; internal set; }
    }
}