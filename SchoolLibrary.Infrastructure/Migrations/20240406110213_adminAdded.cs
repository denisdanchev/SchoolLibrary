using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class adminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b025dd70-a5a0-4394-b5ce-cfdc7261f7c3", "Guest", "Guestov", "AQAAAAEAACcQAAAAEOvmo+2jOyx0qOA9YoxmcgPi8YRaAHUafG8NODP2R8V1hsiMk2Tow3CT6CzYQefEgw==", "01cbd2e3-6fcd-468b-a9e9-d2b6a7312a65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64334642-6950-4b33-98ce-51df47ee716b", "Agent", "Agentov", "AQAAAAEAACcQAAAAEI3W4fKGoGWzYP1WfQlyi5EIgIcljl0Y3HToFovD1OF3DC005mELHED0b5DyUqhi1w==", "a1aaf916-4b82-4f31-ac57-74d92af5af2b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "82223eb9-3921-461a-8942-40a04734d0f4", 0, "ece82c07-9ba6-4daf-a964-f671407a6509", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", null, null, false, "f0ca8c22-ebda-47e5-9331-e05af5fc6861", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorName", "UserId" },
                values: new object[] { 3, "Stone Heck", "82223eb9-3921-461a-8942-40a04734d0f4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82223eb9-3921-461a-8942-40a04734d0f4");

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
    }
}
