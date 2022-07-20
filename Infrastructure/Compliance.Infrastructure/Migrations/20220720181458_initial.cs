using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compliance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Eth");

            migrationBuilder.EnsureSchema(
                name: "eth");

            migrationBuilder.EnsureSchema(
                name: "Gbl");

            migrationBuilder.CreateTable(
                name: "ComplianceSource",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceSourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceSourceName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceSource", x => x.ComplianceSourceId);
                });

            migrationBuilder.CreateTable(
                name: "FileResourceType",
                columns: table => new
                {
                    FileResourceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TranslationKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaxSize = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileResourceType", x => x.FileResourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "InputBehaviour",
                schema: "Gbl",
                columns: table => new
                {
                    InputBehaviourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputBehaviourName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputBehaviour", x => x.InputBehaviourId);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarketDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    MarketCurrency = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('')"),
                    CurrencySymbol = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, defaultValueSql: "('')"),
                    PRIMARYWAREHOUSE = table.Column<int>(type: "int", nullable: true),
                    SECONDARYWAREHOUSE = table.Column<int>(type: "int", nullable: true),
                    TimeZone = table.Column<short>(type: "smallint", nullable: true),
                    DefaultCultureInfo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, defaultValueSql: "('')"),
                    SHIPPINGCURRENCY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MerchantCurrency = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: true),
                    COMPANYCODE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ISNFR = table.Column<short>(type: "smallint", nullable: true),
                    SETTAXINTEGRATION = table.Column<short>(type: "smallint", nullable: true),
                    MAXAMOUNT_NFR = table.Column<short>(type: "smallint", nullable: true),
                    MAXAMOUNTLIMIT_NFR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MAXVOLUME_NFR = table.Column<short>(type: "smallint", nullable: true),
                    MAXVOLUMELIMIT_NFR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MAXCURRENCY_NFR = table.Column<short>(type: "smallint", nullable: true),
                    MAXCURRENCYLIMIT_NFR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NFRCOMPANYCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NFRCURRENCY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    STAGE_NFR = table.Column<short>(type: "smallint", nullable: true),
                    SETCOMPANYDETAIL = table.Column<short>(type: "smallint", nullable: true),
                    COMPANYPHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    COMPANYADDRESSID = table.Column<int>(type: "int", nullable: true),
                    COMPANYEMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MIN_AGE = table.Column<byte>(type: "tinyint", nullable: true),
                    OrderSubscriptionType = table.Column<int>(type: "int", nullable: true),
                    AutoshipSubscriptionType = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    ShowFlagStatus = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    TranslationKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FileResourceExtension",
                columns: table => new
                {
                    FileResourceExtensionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileResourceExtension", x => x.FileResourceExtensionId);
                    table.ForeignKey(
                        name: "FK__FileResou__FileR__4C57E14D",
                        column: x => x.FileResourceTypeId,
                        principalTable: "FileResourceType",
                        principalColumn: "FileResourceTypeId");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceFieldType",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceFieldTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceFieldTypeName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    TranslationKey = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    FieldPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ComplianceFileSizeKb = table.Column<int>(type: "int", nullable: true),
                    HeightPx = table.Column<short>(type: "smallint", nullable: true),
                    WidthPx = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    InputBehaviourId = table.Column<int>(type: "int", nullable: false),
                    FileResourceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceFieldType", x => x.ComplianceFieldTypeId);
                    table.ForeignKey(
                        name: "Fk_ComplianceFieldType_FileesourceTypeId",
                        column: x => x.FileResourceTypeId,
                        principalTable: "FileResourceType",
                        principalColumn: "FileResourceTypeId");
                    table.ForeignKey(
                        name: "Fk_ComplianceFieldType_InputBehaviourId",
                        column: x => x.InputBehaviourId,
                        principalSchema: "Gbl",
                        principalTable: "InputBehaviour",
                        principalColumn: "InputBehaviourId");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceSourceTypes",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceSourceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceSourceId = table.Column<int>(type: "int", nullable: false),
                    ComplianceFieldTypeId = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    RequiresCompliance = table.Column<bool>(type: "bit", nullable: false),
                    ComplianceFileSizeKb = table.Column<int>(type: "int", nullable: true),
                    HeightPx = table.Column<short>(type: "smallint", nullable: true),
                    WidthPx = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complian__C74CA0CF50690A2E", x => x.ComplianceSourceTypeId);
                    table.ForeignKey(
                        name: "Fk_ComplianceSourceTypes_ComplianceFieldTypeId",
                        column: x => x.ComplianceFieldTypeId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceFieldType",
                        principalColumn: "ComplianceFieldTypeId");
                    table.ForeignKey(
                        name: "Fk_ComplianceSource_ComplianceSourceId",
                        column: x => x.ComplianceSourceId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceSource",
                        principalColumn: "ComplianceSourceId");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceDistributorData",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceDistributorDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceSourceTypeId = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    FieldData = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceDistributorData", x => x.ComplianceDistributorDataId);
                    table.ForeignKey(
                        name: "Fk_ComplianceDistributorData_ComplianceSourceTypeId",
                        column: x => x.ComplianceSourceTypeId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceSourceTypes",
                        principalColumn: "ComplianceSourceTypeId");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceSourceTypeMarkets",
                schema: "eth",
                columns: table => new
                {
                    ComplianceSourceTypeMarketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceSourceTypeId = table.Column<int>(type: "int", nullable: false),
                    MarketId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceSourceTypeMarket_ComplianceSourceTypeMarketId", x => x.ComplianceSourceTypeMarketId);
                    table.ForeignKey(
                        name: "FK_ComplianceSourceTypeMarkets_ComplianceSourceType",
                        column: x => x.ComplianceSourceTypeId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceSourceTypes",
                        principalColumn: "ComplianceSourceTypeId");
                    table.ForeignKey(
                        name: "FK_ComplianceSourceTypeMarkets_Market",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ComplianceDistributorDataLogs",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceDistributorLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceDistributorLogMessage = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    ComplianceDistributorLogData = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    ComplianceDistributorDataId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complian__914C46BF57A8EE80", x => x.ComplianceDistributorLogId);
                    table.ForeignKey(
                        name: "Fk_ComplianceDistributorDataLogs_ComplianceDistributorDataId",
                        column: x => x.ComplianceDistributorDataId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceDistributorData",
                        principalColumn: "ComplianceDistributorDataId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDistributorData_ComplianceSourceTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                column: "ComplianceSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDistributorDataLogs_ComplianceDistributorDataId",
                schema: "Eth",
                table: "ComplianceDistributorDataLogs",
                column: "ComplianceDistributorDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceFieldType_FileResourceTypeId",
                schema: "Eth",
                table: "ComplianceFieldType",
                column: "FileResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceFieldType_InputBehaviourId",
                schema: "Eth",
                table: "ComplianceFieldType",
                column: "InputBehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypeMarkets_ComplianceSourceTypeId",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets",
                column: "ComplianceSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypeMarkets_MarketId",
                schema: "eth",
                table: "ComplianceSourceTypeMarkets",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypes_ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceSourceTypes",
                column: "ComplianceFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypes_ComplianceSourceId",
                schema: "Eth",
                table: "ComplianceSourceTypes",
                column: "ComplianceSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_FileResourceExtension_FileResourceTypeId",
                table: "FileResourceExtension",
                column: "FileResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Market_Status",
                table: "Market",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplianceDistributorDataLogs",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "ComplianceSourceTypeMarkets",
                schema: "eth");

            migrationBuilder.DropTable(
                name: "FileResourceExtension");

            migrationBuilder.DropTable(
                name: "ComplianceDistributorData",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "ComplianceSourceTypes",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "ComplianceFieldType",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "ComplianceSource",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "FileResourceType");

            migrationBuilder.DropTable(
                name: "InputBehaviour",
                schema: "Gbl");
        }
    }
}
