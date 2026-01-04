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

                authorAwardEntity.ToTable("AuthorAwardBridge");

                // Primarni kljuc
                authorAwardEntity.HasKey(authorAward => new { authorAward.AuthorId, authorAward.AwardId });

                // Veza ka Author
                authorAwardEntity.HasOne(authorAward => authorAward.Author)
                                 .WithMany(author => author.AuthorAwards)
                                 .HasForeignKey(authorAward => authorAward.AuthorId)
                                 .OnDelete(DeleteBehavior.Cascade);


                // Veza ka Award
                authorAwardEntity.HasOne(authorAward => authorAward.Award)
                                 .WithMany(award => award.AuthorAwards)
                                 .HasForeignKey(authorAward => authorAward.AwardId)
                                 .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Author>()
            .Property(authorEntity => authorEntity.DateOfBirth)
            .HasColumnName("Birthday");

            modelBuilder.Entity<Book>()
            .HasOne(bookEntity => bookEntity.Publisher)
            .WithMany(publisherEntity => publisherEntity.Books)
            .HasForeignKey(bookEntity => bookEntity.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, FullName = "Mark Twain", Biography = "American writer and humorist", DateOfBirth = new DateTime(1835, 11, 30, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 2, FullName = "Jane Austen", Biography = "English novelist known for her realism", DateOfBirth = new DateTime(1775, 12, 16, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 3, FullName = "George Orwell", Biography = "English novelist and essayist", DateOfBirth = new DateTime(1903, 6, 25, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 4, FullName = "J.K. Rowling", Biography = "British author, best known for Harry Potter series", DateOfBirth = new DateTime(1965, 7, 31, 0, 0, 0, DateTimeKind.Utc) },
            new Author { Id = 5, FullName = "F. Scott Fitzgerald", Biography = "American novelist and short story writer", DateOfBirth = new DateTime(1896, 9, 24, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Izdavači
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Books", Address = "80 Strand, London", Website = "https://www.penguin.co.uk" },
                new Publisher { Id = 2, Name = "HarperCollins", Address = "195 Broadway, New York", Website = "https://www.harpercollins.com" },
                new Publisher { Id = 3, Name = "Bloomsbury", Address = "50 Bedford Square, London", Website = "https://www.bloomsbury.com" }
            );

            // Knjige
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Adventures of Huckleberry Finn", PageCount = 366, PublishedDate = new DateTime(1884, 12, 10, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780142437179", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "The Adventures of Tom Sawyer", PageCount = 274, PublishedDate = new DateTime(1876, 6, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780143039563", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 3, Title = "Pride and Prejudice", PageCount = 279, PublishedDate = new DateTime(1813, 1, 28, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780141439518", AuthorId = 2, PublisherId = 1 },
                new Book { Id = 4, Title = "Emma", PageCount = 474, PublishedDate = new DateTime(1815, 12, 23, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780141439587", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 5, Title = "1984", PageCount = 328, PublishedDate = new DateTime(1949, 6, 8, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780451524935", AuthorId = 3, PublisherId = 2 },
                new Book { Id = 6, Title = "Animal Farm", PageCount = 112, PublishedDate = new DateTime(1945, 8, 17, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780451526342", AuthorId = 3, PublisherId = 2 },
                new Book { Id = 7, Title = "Harry Potter and the Philosopher's Stone", PageCount = 223, PublishedDate = new DateTime(1997, 6, 26, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780747532699", AuthorId = 4, PublisherId = 3 },
                new Book { Id = 8, Title = "Harry Potter and the Chamber of Secrets", PageCount = 251, PublishedDate = new DateTime(1998, 7, 2, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780747538493", AuthorId = 4, PublisherId = 3 },
                new Book { Id = 9, Title = "Harry Potter and the Prisoner of Azkaban", PageCount = 317, PublishedDate = new DateTime(1999, 7, 8, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780747542155", AuthorId = 4, PublisherId = 3 },
                new Book { Id = 10, Title = "The Great Gatsby", PageCount = 180, PublishedDate = new DateTime(1925, 4, 10, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780743273565", AuthorId = 5, PublisherId = 1 },
                new Book { Id = 11, Title = "Tender Is the Night", PageCount = 317, PublishedDate = new DateTime(1934, 4, 12, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780684801544", AuthorId = 5, PublisherId = 2 },
                new Book { Id = 12, Title = "This Side of Paradise", PageCount = 305, PublishedDate = new DateTime(1920, 3, 26, 0, 0, 0, DateTimeKind.Utc), ISBN = "9780743273565", AuthorId = 5, PublisherId = 2 }
            );

            // Nagrade
            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "Pulitzer Prize", Description = "Prestigious American literary award", Year = 1917 },
                new Award { Id = 2, Name = "Nobel Prize in Literature", Description = "International literary award", Year = 1901 },
                new Award { Id = 3, Name = "Man Booker Prize", Description = "British literary award", Year = 1969 },
                new Award { Id = 4, Name = "National Book Award", Description = "American literary award", Year = 1950 }
            );

            // AuthorAwardBridge (15 zapisa)
            modelBuilder.Entity<AuthorAward>().HasData(
                new AuthorAward { AuthorId = 1, AwardId = 1, YearAwarded = 1885 },
                new AuthorAward { AuthorId = 1, AwardId = 2, YearAwarded = 1900 },
                new AuthorAward { AuthorId = 1, AwardId = 4, YearAwarded = 1886 },
                new AuthorAward { AuthorId = 2, AwardId = 1, YearAwarded = 1813 },
                new AuthorAward { AuthorId = 2, AwardId = 3, YearAwarded = 1814 },
                new AuthorAward { AuthorId = 2, AwardId = 4, YearAwarded = 1816 },
                new AuthorAward { AuthorId = 3, AwardId = 1, YearAwarded = 1949 },
                new AuthorAward { AuthorId = 3, AwardId = 2, YearAwarded = 1950 },
                new AuthorAward { AuthorId = 3, AwardId = 3, YearAwarded = 1951 },
                new AuthorAward { AuthorId = 4, AwardId = 1, YearAwarded = 1999 },
                new AuthorAward { AuthorId = 4, AwardId = 3, YearAwarded = 1997 },
                new AuthorAward { AuthorId = 4, AwardId = 4, YearAwarded = 1998 },
                new AuthorAward { AuthorId = 5, AwardId = 2, YearAwarded = 1926 },
                new AuthorAward { AuthorId = 5, AwardId = 3, YearAwarded = 1930 },
                new AuthorAward { AuthorId = 5, AwardId = 4, YearAwarded = 1935 }
            );
        }
    }
}