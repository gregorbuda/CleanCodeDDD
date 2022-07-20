using Microsoft.EntityFrameworkCore.Migrations;

namespace xss.ComplianceManagementBackEnd.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_ComplianceDistributorData_ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData");

            migrationBuilder.DropIndex(
                name: "IX_ComplianceDistributorData_ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData");

            migrationBuilder.DropColumn(
                name: "ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData");

            migrationBuilder.AddColumn<int>(
                name: "ComplianceSourceTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDistributorData_ComplianceSourceTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                column: "ComplianceSourceTypeId");

            migrationBuilder.AddForeignKey(
                name: "Fk_ComplianceDistributorData_ComplianceSourceTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                column: "ComplianceSourceTypeId",
                principalSchema: "Eth",
                principalTable: "ComplianceSourceTypes",
                principalColumn: "ComplianceSourceTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_ComplianceDistributorData_ComplianceSourceTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData");

            migrationBuilder.DropIndex(
                name: "IX_ComplianceDistributorData_ComplianceSourceTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData");

            migrationBuilder.DropColumn(
                name: "ComplianceSourceTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData");

            migrationBuilder.AddColumn<int>(
                name: "ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDistributorData_ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                column: "ComplianceFieldTypeId");

            migrationBuilder.AddForeignKey(
                name: "Fk_ComplianceDistributorData_ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                column: "ComplianceFieldTypeId",
                principalSchema: "Eth",
                principalTable: "ComplianceFieldType",
                principalColumn: "ComplianceFieldTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
