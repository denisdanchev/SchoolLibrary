using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class AdminPasswordFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "045da284-ec0e-4bd1-a729-80df46079b6f", "AQAAAAEAACcQAAAAEOM//OW8BCmfQN6Ss2PArNapUjT44nnBR+eVjxOaotHT+c5U/MW7ZrCdOpup357YVQ==", "35028c77-c0ae-42a2-9a37-c2a634756229" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82223eb9-3921-461a-8942-40a04734d0f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62b02a63-c0cf-4334-b73f-142bff39fa61", "AQAAAAEAACcQAAAAEJ0S40+VTGzrt2fka8oRqAbRIAV08vabosNo43iX+aKk3aLSPnSjLxK786rwljjStQ==", "f9051f1a-8fc8-4fa8-bf97-614e385b9354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78429504-a88a-4432-be07-0802ff3b67ba", "AQAAAAEAACcQAAAAEEbPiHtnNd+OD2De2+nzKvUHfXxuGa00vOheeLld0NeDqP1WS0MtyAdrKWd7ju5tDQ==", "8bd85e8d-4514-4896-8c6c-8a3da28b7534" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b025dd70-a5a0-4394-b5ce-cfdc7261f7c3", "AQAAAAEAACcQAAAAEOvmo+2jOyx0qOA9YoxmcgPi8YRaAHUafG8NODP2R8V1hsiMk2Tow3CT6CzYQefEgw==", "01cbd2e3-6fcd-468b-a9e9-d2b6a7312a65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82223eb9-3921-461a-8942-40a04734d0f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ece82c07-9ba6-4daf-a964-f671407a6509", null, "f0ca8c22-ebda-47e5-9331-e05af5fc6861" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64334642-6950-4b33-98ce-51df47ee716b", "AQAAAAEAACcQAAAAEI3W4fKGoGWzYP1WfQlyi5EIgIcljl0Y3HToFovD1OF3DC005mELHED0b5DyUqhi1w==", "a1aaf916-4b82-4f31-ac57-74d92af5af2b" });
        }
    }
}
