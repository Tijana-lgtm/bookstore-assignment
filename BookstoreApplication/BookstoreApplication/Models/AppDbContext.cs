using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AuthorAward> AuthorAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorAward>(authorAwardEntity =>
            {
                // Primarni kljuc
                authorAwardEntity.HasKey(authorAward => new { authorAward.AuthorId, authorAward.AwardId });

                // Veza ka Author
                authorAwardEntity.HasOne(authorAward => authorAward.Author)
                                 .WithMany(author => author.AuthorAwards)
                                 .HasForeignKey(authorAward => authorAward.AuthorId);

                // Veza ka Award
                authorAwardEntity.HasOne(authorAward => authorAward.Award)
                                 .WithMany(award => award.AuthorAwards)
                                 .HasForeignKey(authorAward => authorAward.AwardId);
            });
        }
    }
}