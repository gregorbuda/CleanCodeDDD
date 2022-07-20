using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xss.ComplianceManagementBackEnd.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Market",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        MarketName = table.Column<string>(maxLength: 50, nullable: false),
            //        MarketDescription = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "('')"),
            //        MarketCurrency = table.Column<string>(unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')"),
            //        CurrencySymbol = table.Column<string>(unicode: false, maxLength: 10, nullable: false, defaultValueSql: "('')"),
            //        PRIMARYWAREHOUSE = table.Column<int>(nullable: true),
            //        SECONDARYWAREHOUSE = table.Column<int>(nullable: true),
            //        TimeZone = table.Column<short>(nullable: true),
            //        DefaultCultureInfo = table.Column<string>(unicode: false, maxLength: 10, nullable: true, defaultValueSql: "('')"),
            //        SHIPPINGCURRENCY = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        MerchantCurrency = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
            //        CountryID = table.Column<int>(nullable: true),
            //        COMPANYCODE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
            //        ISNFR = table.Column<short>(nullable: true),
            //        SETTAXINTEGRATION = table.Column<short>(nullable: true),
            //        MAXAMOUNT_NFR = table.Column<short>(nullable: true),
            //        MAXAMOUNTLIMIT_NFR = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        MAXVOLUME_NFR = table.Column<short>(nullable: true),
            //        MAXVOLUMELIMIT_NFR = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        MAXCURRENCY_NFR = table.Column<short>(nullable: true),
            //        MAXCURRENCYLIMIT_NFR = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
            //        NFRCOMPANYCODE = table.Column<string>(maxLength: 50, nullable: true),
            //        NFRCURRENCY = table.Column<string>(maxLength: 50, nullable: true),
            //        STAGE_NFR = table.Column<short>(nullable: true),
            //        SETCOMPANYDETAIL = table.Column<short>(nullable: true),
            //        COMPANYPHONE = table.Column<string>(maxLength: 50, nullable: true),
            //        COMPANYADDRESSID = table.Column<int>(nullable: true),
            //        COMPANYEMAIL = table.Column<string>(maxLength: 50, nullable: true),
            //        MIN_AGE = table.Column<byte>(nullable: true),
            //        OrderSubscriptionType = table.Column<int>(nullable: true),
            //        AutoshipSubscriptionType = table.Column<int>(nullable: true),
            //        Status = table.Column<short>(nullable: false, defaultValueSql: "((1))"),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        CreatedBy = table.Column<int>(nullable: false),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        UpdatedBy = table.Column<int>(nullable: true),
            //        ShowFlagStatus = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
            //        TranslationKey = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Market", x => x.ID);
            //    });

            migrationBuilder.CreateTable(
                name: "ComplianceSourceTypeMarkets",
                schema: "Gbl",
                columns: table => new
                {
                    ComplianceSourceTypeMarketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceSourceTypeId = table.Column<int>(nullable: false),
                    MarketId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceSourceTypeMarket_ComplianceSourceTypeMarketId", x => x.ComplianceSourceTypeMarketId);
                    table.ForeignKey(
                        name: "FK_ComplianceSourceTypeMarkets_ComplianceSourceType",
                        column: x => x.ComplianceSourceTypeId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceSourceTypes",
                        principalColumn: "ComplianceSourceTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComplianceSourceTypeMarkets_Market",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Market_Status",
            //    table: "Market",
            //    column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypeMarkets_ComplianceSourceTypeId",
                schema: "Gbl",
                table: "ComplianceSourceTypeMarkets",
                column: "ComplianceSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypeMarkets_MarketId",
                schema: "Gbl",
                table: "ComplianceSourceTypeMarkets",
                column: "MarketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplianceSourceTypeMarkets",
                schema: "Gbl");

            //migrationBuilder.DropTable(
            //    name: "Market");
        }
    }
}
