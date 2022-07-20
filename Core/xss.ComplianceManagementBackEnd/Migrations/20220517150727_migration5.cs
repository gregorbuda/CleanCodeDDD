using Microsoft.EntityFrameworkCore.Migrations;

namespace xss.ComplianceManagementBackEnd.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValueSql: "((1))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(byte));
        }
    }
}
