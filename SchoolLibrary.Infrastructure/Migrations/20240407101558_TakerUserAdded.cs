using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class TakerUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_UserId",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "TakerId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Book taker identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Book taker identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "443c82e9-82ad-4f45-ae12-cb3cf64b7033", "AQAAAAEAACcQAAAAEFHNcaaT0X4cwfDpmHTo1WXM8ZPMImHk7tDC6iuzqQtyTrNxkJGZf1lHEfn3rJaSgw==", "b84321be-0afb-43cc-a418-5362dce22f10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82223eb9-3921-461a-8942-40a04734d0f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb6e32c-724c-447e-a11e-9a39bf3f73ff", "AQAAAAEAACcQAAAAEIDxgDc6U8CcFI81mUhm0YbztFEcoafBa88/INw0lPWyUUu1CP4nCtLjxbtDdVsRlg==", "24a2c5b1-1587-4083-aab6-85afa9702d1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8af160da-8fe8-4090-9ce4-20af431bea10", "AQAAAAEAACcQAAAAEA6jqBC4g2bXlqb6WjhYAek0+whbl/ZL4vwzWboVnZCtdRHamN2NHD3brb9m5dL5ZQ==", "d93a14a8-31aa-4c96-b0b1-6ae0f8abf5e9" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_TakerId",
                table: "Books",
                column: "TakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_TakerId",
                table: "Books",
                column: "TakerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_TakerId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_TakerId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_UserId",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "TakerId",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Book taker identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "Book taker identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad503f2d-7416-4bad-a918-45af07e2a2e2", "AQAAAAEAACcQAAAAEM5wTZHUUOh4vz5t9JzroGocKTEfz4RrLRrt6Uwf2+ekSCnFH8qTu5DW9we4qoha7g==", "fca73e52-6a91-4d61-999c-d9628d042fe8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82223eb9-3921-461a-8942-40a04734d0f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cee07fb5-dc8d-48d3-8362-888d6c7f2950", "AQAAAAEAACcQAAAAENdph3UrR+oapSD7hpzO/8P+ybQRVILgUDGcLMiqsLk/TFf1CC0SqXIXg7cCqt/vfg==", "602d8dab-4324-40a4-84b7-95a3cbf72bf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8ec5953-3026-4147-88e6-09b23ec3ba68", "AQAAAAEAACcQAAAAED8Z4lBYBvGgM5M8qON/jKUu/21pjOcT9pK/KP5h2srTiLSFFKe291429F9HbjCRMw==", "cacc53a8-5693-4809-bae5-c7edc9509490" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                column: "UserId");
        }
    }
}
