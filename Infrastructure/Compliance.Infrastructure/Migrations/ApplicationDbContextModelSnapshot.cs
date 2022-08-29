﻿// <auto-generated />
using System;
using Compliance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Compliance.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceDistributorData", b =>
                {
                    b.Property<int>("ComplianceDistributorDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplianceDistributorDataId"), 1L, 1);

                    b.Property<int>("ComplianceSourceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((99))");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("DistributorId")
                        .HasColumnType("int");

                    b.Property<string>("FieldData")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("((1))");

                    b.Property<byte>("Status2")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Status3")
                        .HasColumnType("tinyint");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date");

                    b.HasKey("ComplianceDistributorDataId");

                    b.HasIndex("ComplianceSourceTypeId");

                    b.ToTable("ComplianceDistributorData", "Eth");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceDistributorDataLogs", b =>
                {
                    b.Property<int>("ComplianceDistributorLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplianceDistributorLogId"), 1L, 1);

                    b.Property<int>("ComplianceDistributorDataId")
                        .HasColumnType("int");

                    b.Property<string>("ComplianceDistributorLogData")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ComplianceDistributorLogMessage")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((99))");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date");

                    b.HasKey("ComplianceDistributorLogId")
                        .HasName("PK__Complian__914C46BF57A8EE80");

                    b.HasIndex("ComplianceDistributorDataId");

                    b.ToTable("ComplianceDistributorDataLogs", "Eth");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceFieldType", b =>
                {
                    b.Property<int>("ComplianceFieldTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplianceFieldTypeId"), 1L, 1);

                    b.Property<string>("ComplianceFieldTypeName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("ComplianceFileSizeKb")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((99))");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("FieldPath")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FileResourceTypeId")
                        .HasColumnType("int");

                    b.Property<short?>("HeightPx")
                        .HasColumnType("smallint");

                    b.Property<int>("InputBehaviourId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("TranslationKey")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date");

                    b.Property<short?>("WidthPx")
                        .HasColumnType("smallint");

                    b.HasKey("ComplianceFieldTypeId");

                    b.HasIndex("FileResourceTypeId");

                    b.HasIndex("InputBehaviourId");

                    b.ToTable("ComplianceFieldType", "Eth");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceSource", b =>
                {
                    b.Property<int>("ComplianceSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplianceSourceId"), 1L, 1);

                    b.Property<string>("ComplianceSourceName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((99))");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date");

                    b.HasKey("ComplianceSourceId");

                    b.ToTable("ComplianceSource", "Eth");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceSourceTypeMarkets", b =>
                {
                    b.Property<int>("ComplianceSourceTypeMarketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplianceSourceTypeMarketId"), 1L, 1);

                    b.Property<int>("ComplianceSourceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((99))");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("MarketId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date");

                    b.HasKey("ComplianceSourceTypeMarketId")
                        .HasName("PK_ComplianceSourceTypeMarket_ComplianceSourceTypeMarketId");

                    b.HasIndex("ComplianceSourceTypeId");

                    b.ToTable("ComplianceSourceTypeMarkets", "eth");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceSourceTypes", b =>
                {
                    b.Property<int>("ComplianceSourceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplianceSourceTypeId"), 1L, 1);

                    b.Property<int>("ComplianceFieldTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ComplianceFileSizeKb")
                        .HasColumnType("int");

                    b.Property<int>("ComplianceSourceId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((99))");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("DistributorId")
                        .HasColumnType("int");

                    b.Property<short?>("HeightPx")
                        .HasColumnType("smallint");

                    b.Property<bool>("RequiresCompliance")
                        .HasColumnType("bit");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date");

                    b.Property<short?>("WidthPx")
                        .HasColumnType("smallint");

                    b.HasKey("ComplianceSourceTypeId")
                        .HasName("PK__Complian__C74CA0CF50690A2E");

                    b.HasIndex("ComplianceFieldTypeId");

                    b.HasIndex("ComplianceSourceId");

                    b.ToTable("ComplianceSourceTypes", "Eth");
                });

            modelBuilder.Entity("Compliance.Domain.Models.FileResourceExtension", b =>
                {
                    b.Property<int>("FileResourceExtensionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileResourceExtensionId"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FileResourceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("FileResourceExtensionId");

                    b.HasIndex("FileResourceTypeId");

                    b.ToTable("FileResourceExtension");
                });

            modelBuilder.Entity("Compliance.Domain.Models.FileResourceType", b =>
                {
                    b.Property<int>("FileResourceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileResourceTypeId"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MaxSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TranslationKey")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("FileResourceTypeId");

                    b.ToTable("FileResourceType");
                });

            modelBuilder.Entity("Compliance.Domain.Models.InputBehaviour", b =>
                {
                    b.Property<int>("InputBehaviourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InputBehaviourId"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((99))");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("InputBehaviourName")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<byte>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("date");

                    b.HasKey("InputBehaviourId");

                    b.ToTable("InputBehaviour", "Gbl");
                });

            modelBuilder.Entity("Compliance.Domain.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AutoshipSubscriptionType")
                        .HasColumnType("int");

                    b.Property<int?>("Companyaddressid")
                        .HasColumnType("int")
                        .HasColumnName("COMPANYADDRESSID");

                    b.Property<string>("Companycode")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("COMPANYCODE");

                    b.Property<string>("Companyemail")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("COMPANYEMAIL");

                    b.Property<string>("Companyphone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("COMPANYPHONE");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("CurrencySymbol")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasDefaultValueSql("('')");

                    b.Property<string>("DefaultCultureInfo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasDefaultValueSql("('')");

                    b.Property<short?>("Isnfr")
                        .HasColumnType("smallint")
                        .HasColumnName("ISNFR");

                    b.Property<string>("MarketCurrency")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("('')");

                    b.Property<string>("MarketDescription")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("('')");

                    b.Property<string>("MarketName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short?>("MaxamountNfr")
                        .HasColumnType("smallint")
                        .HasColumnName("MAXAMOUNT_NFR");

                    b.Property<decimal?>("MaxamountlimitNfr")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MAXAMOUNTLIMIT_NFR");

                    b.Property<short?>("MaxcurrencyNfr")
                        .HasColumnType("smallint")
                        .HasColumnName("MAXCURRENCY_NFR");

                    b.Property<decimal?>("MaxcurrencylimitNfr")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MAXCURRENCYLIMIT_NFR");

                    b.Property<short?>("MaxvolumeNfr")
                        .HasColumnType("smallint")
                        .HasColumnName("MAXVOLUME_NFR");

                    b.Property<decimal?>("MaxvolumelimitNfr")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("MAXVOLUMELIMIT_NFR");

                    b.Property<string>("MerchantCurrency")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<byte?>("MinAge")
                        .HasColumnType("tinyint")
                        .HasColumnName("MIN_AGE");

                    b.Property<string>("Nfrcompanycode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NFRCOMPANYCODE");

                    b.Property<string>("Nfrcurrency")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NFRCURRENCY");

                    b.Property<int?>("OrderSubscriptionType")
                        .HasColumnType("int");

                    b.Property<int?>("Primarywarehouse")
                        .HasColumnType("int")
                        .HasColumnName("PRIMARYWAREHOUSE");

                    b.Property<int?>("Secondarywarehouse")
                        .HasColumnType("int")
                        .HasColumnName("SECONDARYWAREHOUSE");

                    b.Property<short?>("Setcompanydetail")
                        .HasColumnType("smallint")
                        .HasColumnName("SETCOMPANYDETAIL");

                    b.Property<short?>("Settaxintegration")
                        .HasColumnType("smallint")
                        .HasColumnName("SETTAXINTEGRATION");

                    b.Property<string>("Shippingcurrency")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("SHIPPINGCURRENCY");

                    b.Property<bool?>("ShowFlagStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<short?>("StageNfr")
                        .HasColumnType("smallint")
                        .HasColumnName("STAGE_NFR");

                    b.Property<short>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValueSql("((1))");

                    b.Property<short?>("TimeZone")
                        .HasColumnType("smallint");

                    b.Property<string>("TranslationKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceDistributorData", b =>
                {
                    b.HasOne("Compliance.Domain.Models.ComplianceSourceTypes", "ComplianceSourceType")
                        .WithMany("ComplianceDistributorData")
                        .HasForeignKey("ComplianceSourceTypeId")
                        .IsRequired()
                        .HasConstraintName("Fk_ComplianceDistributorData_ComplianceSourceTypeId");

                    b.Navigation("ComplianceSourceType");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceDistributorDataLogs", b =>
                {
                    b.HasOne("Compliance.Domain.Models.ComplianceDistributorData", "ComplianceDistributorData")
                        .WithMany("ComplianceDistributorDataLogs")
                        .HasForeignKey("ComplianceDistributorDataId")
                        .IsRequired()
                        .HasConstraintName("Fk_ComplianceDistributorDataLogs_ComplianceDistributorDataId");

                    b.Navigation("ComplianceDistributorData");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceFieldType", b =>
                {
                    b.HasOne("Compliance.Domain.Models.FileResourceType", "FileResourceType")
                        .WithMany("ComplianceFieldTypes")
                        .HasForeignKey("FileResourceTypeId")
                        .IsRequired()
                        .HasConstraintName("Fk_ComplianceFieldType_FileesourceTypeId");

                    b.HasOne("Compliance.Domain.Models.InputBehaviour", "InputBehaviour")
                        .WithMany("ComplianceFieldType")
                        .HasForeignKey("InputBehaviourId")
                        .IsRequired()
                        .HasConstraintName("Fk_ComplianceFieldType_InputBehaviourId");

                    b.Navigation("FileResourceType");

                    b.Navigation("InputBehaviour");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceSourceTypeMarkets", b =>
                {
                    b.HasOne("Compliance.Domain.Models.ComplianceSourceTypes", "ComplianceSourceType")
                        .WithMany("ComplianceSourceTypeMarkets")
                        .HasForeignKey("ComplianceSourceTypeId")
                        .IsRequired()
                        .HasConstraintName("FK_ComplianceSourceTypeMarkets_ComplianceSourceType");

                    b.Navigation("ComplianceSourceType");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceSourceTypes", b =>
                {
                    b.HasOne("Compliance.Domain.Models.ComplianceFieldType", "ComplianceFieldType")
                        .WithMany("ComplianceSourceTypes")
                        .HasForeignKey("ComplianceFieldTypeId")
                        .IsRequired()
                        .HasConstraintName("Fk_ComplianceSourceTypes_ComplianceFieldTypeId");

                    b.HasOne("Compliance.Domain.Models.ComplianceSource", "ComplianceSource")
                        .WithMany("ComplianceSourceTypes")
                        .HasForeignKey("ComplianceSourceId")
                        .IsRequired()
                        .HasConstraintName("Fk_ComplianceSource_ComplianceSourceId");

                    b.Navigation("ComplianceFieldType");

                    b.Navigation("ComplianceSource");
                });

            modelBuilder.Entity("Compliance.Domain.Models.FileResourceExtension", b =>
                {
                    b.HasOne("Compliance.Domain.Models.FileResourceType", "FileResourceType")
                        .WithMany("FileResourceExtension")
                        .HasForeignKey("FileResourceTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__FileResou__FileR__4C57E14D");

                    b.Navigation("FileResourceType");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceDistributorData", b =>
                {
                    b.Navigation("ComplianceDistributorDataLogs");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceFieldType", b =>
                {
                    b.Navigation("ComplianceSourceTypes");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceSource", b =>
                {
                    b.Navigation("ComplianceSourceTypes");
                });

            modelBuilder.Entity("Compliance.Domain.Models.ComplianceSourceTypes", b =>
                {
                    b.Navigation("ComplianceDistributorData");

                    b.Navigation("ComplianceSourceTypeMarkets");
                });

            modelBuilder.Entity("Compliance.Domain.Models.FileResourceType", b =>
                {
                    b.Navigation("ComplianceFieldTypes");

                    b.Navigation("FileResourceExtension");
                });

            modelBuilder.Entity("Compliance.Domain.Models.InputBehaviour", b =>
                {
                    b.Navigation("ComplianceFieldType");
                });
#pragma warning restore 612, 618
        }
    }
}
