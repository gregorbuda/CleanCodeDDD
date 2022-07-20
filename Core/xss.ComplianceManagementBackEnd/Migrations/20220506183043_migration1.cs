using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace xss.ComplianceManagementBackEnd.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Eth");

            migrationBuilder.EnsureSchema(
                name: "Gbl");

            migrationBuilder.CreateTable(
                name: "FileResourceType",
                columns: table => new
                {
                    FileResourceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    TranslationKey = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    MaxSize = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileResourceType", x => x.FileResourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceSource",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceSourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceSourceName = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceSource", x => x.ComplianceSourceId);
                });

            migrationBuilder.CreateTable(
                name: "InputBehaviour",
                schema: "Gbl",
                columns: table => new
                {
                    InputBehaviourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputBehaviourName = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputBehaviour", x => x.InputBehaviourId);
                });

            migrationBuilder.CreateTable(
                name: "FileResourceExtension",
                columns: table => new
                {
                    FileResourceExtensionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileResourceTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileResourceExtension", x => x.FileResourceExtensionId);
                    table.ForeignKey(
                        name: "FK__FileResou__FileR__4C57E14D",
                        column: x => x.FileResourceTypeId,
                        principalTable: "FileResourceType",
                        principalColumn: "FileResourceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceFieldType",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceFieldTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceFieldTypeName = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    TranslationKey = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    FieldPath = table.Column<string>(maxLength: 500, nullable: true),
                    ComplianceFileSizeKb = table.Column<int>(nullable: true),
                    HeightPx = table.Column<short>(nullable: true),
                    WidthPx = table.Column<short>(nullable: true),
                    FileTypeId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    InputBehaviourId = table.Column<int>(nullable: false),
                    FileResourceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceFieldType", x => x.ComplianceFieldTypeId);
                    table.ForeignKey(
                        name: "Fk_ComplianceFieldType_FileesourceTypeId",
                        column: x => x.FileResourceTypeId,
                        principalTable: "FileResourceType",
                        principalColumn: "FileResourceTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_ComplianceFieldType_InputBehaviourId",
                        column: x => x.InputBehaviourId,
                        principalSchema: "Gbl",
                        principalTable: "InputBehaviour",
                        principalColumn: "InputBehaviourId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceDistributorData",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceDistributorDataId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceFieldTypeId = table.Column<int>(nullable: false),
                    DistributorId = table.Column<int>(nullable: false),
                    FieldData = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceDistributorData", x => x.ComplianceDistributorDataId);
                    table.ForeignKey(
                        name: "Fk_ComplianceDistributorData_ComplianceFieldTypeId",
                        column: x => x.ComplianceFieldTypeId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceFieldType",
                        principalColumn: "ComplianceFieldTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceSourceTypes",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceSourceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceSourceId = table.Column<int>(nullable: false),
                    ComplianceFieldTypeId = table.Column<int>(nullable: false),
                    DistributorId = table.Column<int>(nullable: false),
                    RequiresCompliance = table.Column<byte>(nullable: false),
                    ComplianceFileSizeKb = table.Column<int>(nullable: true),
                    HeightPx = table.Column<short>(nullable: true),
                    WidthPx = table.Column<short>(nullable: true),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complian__C74CA0CF50690A2E", x => x.ComplianceSourceTypeId);
                    table.ForeignKey(
                        name: "Fk_ComplianceSourceTypes_ComplianceFieldTypeId",
                        column: x => x.ComplianceFieldTypeId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceFieldType",
                        principalColumn: "ComplianceFieldTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_ComplianceSource_ComplianceSourceId",
                        column: x => x.ComplianceSourceId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceSource",
                        principalColumn: "ComplianceSourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceDistributorDataLogs",
                schema: "Eth",
                columns: table => new
                {
                    ComplianceDistributorLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplianceDistributorLogMessage = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ComplianceDistributorLogData = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ComplianceDistributorDataId = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<int>(nullable: false, defaultValueSql: "((99))"),
                    UpdatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complian__914C46BF57A8EE80", x => x.ComplianceDistributorLogId);
                    table.ForeignKey(
                        name: "Fk_ComplianceDistributorDataLogs_ComplianceDistributorDataId",
                        column: x => x.ComplianceDistributorDataId,
                        principalSchema: "Eth",
                        principalTable: "ComplianceDistributorData",
                        principalColumn: "ComplianceDistributorDataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileResourceExtension_FileResourceTypeId",
                table: "FileResourceExtension",
                column: "FileResourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDistributorData_ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceDistributorData",
                column: "ComplianceFieldTypeId");

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
                name: "IX_ComplianceSourceTypes_ComplianceFieldTypeId",
                schema: "Eth",
                table: "ComplianceSourceTypes",
                column: "ComplianceFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceSourceTypes_ComplianceSourceId",
                schema: "Eth",
                table: "ComplianceSourceTypes",
                column: "ComplianceSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileResourceExtension");

            migrationBuilder.DropTable(
                name: "ComplianceDistributorDataLogs",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "ComplianceSourceTypes",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "ComplianceDistributorData",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "ComplianceSource",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "ComplianceFieldType",
                schema: "Eth");

            migrationBuilder.DropTable(
                name: "FileResourceType");

            migrationBuilder.DropTable(
                name: "InputBehaviour",
                schema: "Gbl");
        }
    }
}
