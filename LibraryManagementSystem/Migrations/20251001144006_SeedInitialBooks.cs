using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "ISBN", "IsAvailable", "Stock", "Title" },
                values: new object[,]
                {
                    { 2, "Paulo Coelho", "9780062315007", true, 3, "The Alchemist" },
                    { 3, "Harper Lee", "9780061120084", true, 4, "To Kill a Mockingbird" },
                    { 4, "J.D. Salinger", "9780316769488", true, 4, "The Catcher in the Rye" },
                    { 5, "Yuval Noah Harari", "9780062316097", true, 6, "Sapiens: A Brief History of Humankind" },
                    { 6, "F. Scott Fitzgerald", "9780743273565", true, 3, "The Great Gatsby" },
                    { 7, "Tara Westover", "9780399590504", true, 5, "Educated" },
                    { 8, "Daniel Kahneman", "9780374533557", true, 4, "Thinking, Fast and Slow" },
                    { 9, "Eckhart Tolle", "9781577314806", true, 2, "The Power of Now" },
                    { 10, "J.R.R. Tolkien", "9780547928227", true, 7, "The Hobbit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);
        }
    }
}
