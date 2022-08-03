using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compliance.Infrastructure.Migrations
{
    public partial class fixedrelationmarketidThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplianceSourceTypeMarkets_Market_MarketId",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets");

            migrationBuilder.DropIndex(
                name: "IX_ComplianceSourceTypeMarkets_MarketId",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypeMarkets_MarketId",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets",
                column: "MarketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceSourceTypeMarkets_Market_MarketId",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets",
                column: "MarketId",
                principalTable: "Market",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
