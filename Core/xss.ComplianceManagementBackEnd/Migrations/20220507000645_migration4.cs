using Microsoft.EntityFrameworkCore.Migrations;

namespace xss.ComplianceManagementBackEnd.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "eth");

            migrationBuilder.RenameTable(
                name: "ComplianceSourceTypeMarkets",
                schema: "Gbl",
                newName: "ComplianceSourceTypeMarkets",
                newSchema: "eth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ComplianceSourceTypeMarkets",
                schema: "eth",
                newName: "ComplianceSourceTypeMarkets",
                newSchema: "Gbl");
        }
    }
}
