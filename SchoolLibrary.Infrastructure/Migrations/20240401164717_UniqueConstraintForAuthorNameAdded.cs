using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class UniqueConstraintForAuthorNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "595f7351-63e8-48fe-9bf7-d346a590921d", "AQAAAAEAACcQAAAAEK6DnP0KPRDCeBaT4YJP9haHoBliYyv5bh8kwXfnWu4UU65drFICsnxp4Jd2Ule37Q==", "8d8cc563-e6cb-4e49-b94d-59e850f0a37b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7de6aea1-7eaf-4b63-b07c-d2db55e682a7", "AQAAAAEAACcQAAAAELv09AO5DvStzkfACeedtnK2if9e1B8EL1Ka/Vmv2PCY3rblCyw05jojiU45KI28oQ==", "7ff137c4-2653-47a9-ad18-b8b73fa63257" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorName",
                table: "Authors",
                column: "AuthorName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_AuthorName",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de8c6638-15a1-4561-b980-ac0fc5fa6b4b", "AQAAAAEAACcQAAAAECq4139G22ukAbjRTGxXRTdtuQXVfZOTcIBk5FNdg0EbTRqj1G2MNKnwiO9T8XQFDw==", "bab3750f-ec41-4d85-a85d-9abe297d7059" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "baa74c55-02d1-4c5b-9bf2-b944eb1c60ba", "AQAAAAEAACcQAAAAECMVubTGQbhprSEg7aBOUUfKGphH+4Pn/8ZU59hOujpLBW0lV7T6f6rVdArWshdORg==", "3dbef1f3-fad7-4e9e-b177-4ec57d8582c7" });
        }
    }
}
