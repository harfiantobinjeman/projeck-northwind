using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Persistence.Migrations.Northwind
{
    public partial class AddRoleToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "076cde46-fdd8-4bc8-9ed3-32115ea45789");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92546ad6-aad4-498f-9060-5e36cdb3e4eb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8afd33bf-9962-4c31-a9cd-422645d7da6c", "b3432377-6545-4ca4-8279-c24153737ba5", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ef76162-9591-49ee-97ab-c0828fe09c97", "dff9554a-1baa-4476-b89b-e40b577cd82d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ef76162-9591-49ee-97ab-c0828fe09c97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8afd33bf-9962-4c31-a9cd-422645d7da6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92546ad6-aad4-498f-9060-5e36cdb3e4eb", "3c300a36-be81-447d-9fac-044b77fc1ebe", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "076cde46-fdd8-4bc8-9ed3-32115ea45789", "2300b3a4-8370-45e8-b9e2-d3418355a9f6", "Administrator", "ADMINISTRATOR" });
        }
    }
}
