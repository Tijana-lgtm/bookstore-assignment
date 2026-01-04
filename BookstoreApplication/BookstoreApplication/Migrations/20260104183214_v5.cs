using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Description", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Prestigious American literary award", "Pulitzer Prize", 1917 },
                    { 2, "International literary award", "Nobel Prize in Literature", 1901 },
                    { 3, "British literary award", "Man Booker Prize", 1969 },
                    { 4, "American literary award", "National Book Award", 1950 }
                });

            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "AuthorId", "AwardId", "YearAwarded" },
                values: new object[,]
                {
                    { 1, 1, 1885 },
                    { 1, 2, 1900 },
                    { 1, 4, 1886 },
                    { 2, 1, 1813 },
                    { 2, 3, 1814 },
                    { 2, 4, 1816 },
                    { 3, 1, 1949 },
                    { 3, 2, 1950 },
                    { 3, 3, 1951 },
                    { 4, 1, 1999 },
                    { 4, 3, 1997 },
                    { 4, 4, 1998 },
                    { 5, 2, 1926 },
                    { 5, 3, 1930 },
                    { 5, 4, 1935 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
