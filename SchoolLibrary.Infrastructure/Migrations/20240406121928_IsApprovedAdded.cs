using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is book approved by admin");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Books");

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
    }
}
