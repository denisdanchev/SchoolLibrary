using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Book description",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Book description");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Book image URL");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "de8c6638-15a1-4561-b980-ac0fc5fa6b4b", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAECq4139G22ukAbjRTGxXRTdtuQXVfZOTcIBk5FNdg0EbTRqj1G2MNKnwiO9T8XQFDw==", null, false, "bab3750f-ec41-4d85-a85d-9abe297d7059", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "baa74c55-02d1-4c5b-9bf2-b944eb1c60ba", "author@mail.com", false, false, null, "author@mail.com", "author@mail.com", "AQAAAAEAACcQAAAAECMVubTGQbhprSEg7aBOUUfKGphH+4Pn/8ZU59hOujpLBW0lV7T6f6rVdArWshdORg==", null, false, "3dbef1f3-fad7-4e9e-b177-4ec57d8582c7", false, "author@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Horror" },
                    { 3, "Romantic" },
                    { 4, "History" },
                    { 5, "Mystery" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorName", "UserId" },
                values: new object[] { 1, "Bram Stoker", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookPages", "BookTitle", "Description", "GenreId", "ImageUrl", "PositionInLibrary", "TakerId" },
                values: new object[] { 1, 1, 180, "Dracula", "Jonathan Harker visits Transylvania to help Count Dracula with the purchase of a London house", 2, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1387151694i/17245.jpg", "2C", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookPages", "BookTitle", "Description", "GenreId", "ImageUrl", "PositionInLibrary", "TakerId" },
                values: new object[] { 2, 1, 120, "The Lady of the Shroud", "Some intereseing book to read.", 3, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1347813983i/35820.jpg", "1G", "" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookPages", "BookTitle", "Description", "GenreId", "ImageUrl", "PositionInLibrary", "TakerId" },
                values: new object[] { 3, 1, 160, "The Man", "Squire Stephen Norman is lord of the manor in Normanstead.", 2, "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1347816010i/6363980.jpg", "3C", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

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
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Book description",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Book description");
        }
    }
}
