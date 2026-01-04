using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Birthday", "FullName" },
                values: new object[,]
                {
                    { 1, "American writer and humorist", new DateTime(1835, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "Mark Twain" },
                    { 2, "English novelist known for her realism", new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Jane Austen" },
                    { 3, "English novelist and essayist", new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), "George Orwell" },
                    { 4, "British author, best known for Harry Potter series", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "J.K. Rowling" },
                    { 5, "American novelist and short story writer", new DateTime(1896, 9, 24, 0, 0, 0, 0, DateTimeKind.Utc), "F. Scott Fitzgerald" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "80 Strand, London", "Penguin Books", "https://www.penguin.co.uk" },
                    { 2, "195 Broadway, New York", "HarperCollins", "https://www.harpercollins.com" },
                    { 3, "50 Bedford Square, London", "Bloomsbury", "https://www.bloomsbury.com" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "PageCount", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "9780142437179", 366, new DateTime(1884, 12, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Adventures of Huckleberry Finn" },
                    { 2, 1, "9780143039563", 274, new DateTime(1876, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "The Adventures of Tom Sawyer" },
                    { 3, 2, "9780141439518", 279, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Pride and Prejudice" },
                    { 4, 2, "9780141439587", 474, new DateTime(1815, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Emma" },
                    { 5, 3, "9780451524935", 328, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), 2, "1984" },
                    { 6, 3, "9780451526342", 112, new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Animal Farm" },
                    { 7, 4, "9780747532699", 223, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Harry Potter and the Philosopher's Stone" },
                    { 8, 4, "9780747538493", 251, new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Harry Potter and the Chamber of Secrets" },
                    { 9, 4, "9780747542155", 317, new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Harry Potter and the Prisoner of Azkaban" },
                    { 10, 5, "9780743273565", 180, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), 1, "The Great Gatsby" },
                    { 11, 5, "9780684801544", 317, new DateTime(1934, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Tender Is the Night" },
                    { 12, 5, "9780743273565", 305, new DateTime(1920, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), 2, "This Side of Paradise" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
