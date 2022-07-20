using Microsoft.EntityFrameworkCore.Migrations;

namespace xss.ComplianceManagementBackEnd.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileTypeId",
                schema: "Eth",
                table: "ComplianceFieldType");

            migrationBuilder.AlterColumn<bool>(
                name: "RequiresCompliance",
                schema: "Eth",
                table: "ComplianceSourceTypes",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "RequiresCompliance",
                schema: "Eth",
                table: "ComplianceSourceTypes",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "FileTypeId",
                schema: "Eth",
                table: "ComplianceFieldType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
