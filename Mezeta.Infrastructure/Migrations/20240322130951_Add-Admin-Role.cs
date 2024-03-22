using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mezeta.Infrastructure.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab1d787-7a94-4813-845f-27aea5ac4c74", "11671235-5267-4e73-830b-bea2485dedb4", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab1d787-7a94-4813-845f-27aea5ac4c74");
        }
    }
}
