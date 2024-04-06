using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "653a02a8-dd67-4456-8df4-31630383a112", "", "", "AQAAAAEAACcQAAAAEAfGKZTYh7zrm+7xWSvHOhg69AcmCcXIWzLJXe8ECWt1sZf0NNo+7ygztPZsCotRtw==", "8c39624c-68eb-4178-8a51-2adb0f6f69de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb769d37-5cce-452b-b45f-3db20fe407e2", "", "", "AQAAAAEAACcQAAAAEBJhZRP+ChPwNTo6Ra2irBHkNN5OMRwaXogYRy6HRsbH9DYUrIYHsZeZwTvjtBMJag==", "e7701fc4-dd7a-4a9d-b5a7-29f30787317b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "222f6fbc-5788-4795-b4ea-bae9fcb3b80f", "AQAAAAEAACcQAAAAEJAgOe3YAzlBuYoelxn9fj939T/sSxDROO8is5Sr1PGZ1BkvST6iNmOI0e/vzgpDzg==", "2b4dafa5-0ccf-43ee-a02b-583e684e75d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cde46f3-febd-42e4-a3b7-5a0dbcdf1793", "AQAAAAEAACcQAAAAEJ27+t8Kj1y3M8KYn6wUyBe8N/Mc9o1z62NEkmn8RmyL4+5nm8BJwtYe+L984IeOnw==", "9e4b3da4-757a-4ba2-8b75-4770600f92fc" });
        }
    }
}
