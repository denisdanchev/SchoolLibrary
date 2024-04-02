using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolLibrary.Infrastructure.Migrations
{
    public partial class InfrastructureModelsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
