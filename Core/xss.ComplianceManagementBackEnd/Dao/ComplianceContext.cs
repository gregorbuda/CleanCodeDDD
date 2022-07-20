using Microsoft.EntityFrameworkCore;
using xss.ComplianceManagementBackEnd.Entity;

namespace xss.ComplianceManagementBackEnd.Dao
{
    public partial class ComplianceContext : DbContext
    {
        public ComplianceContext()
        {
        }

        public ComplianceContext(DbContextOptions<ComplianceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComplianceDistributorData> ComplianceDistributorData { get; set; }
        public virtual DbSet<ComplianceDistributorDataLogs> ComplianceDistributorDataLogs { get; set; }
        public virtual DbSet<ComplianceFieldType> ComplianceFieldType { get; set; }
        public virtual DbSet<ComplianceSource> ComplianceSource { get; set; }
        public virtual DbSet<ComplianceSourceTypes> ComplianceSourceTypes { get; set; }
        public virtual DbSet<InputBehaviour> InputBehaviour { get; set; }
        public virtual DbSet<FileResourceExtension> FileResourceExtension { get; set; }
        public virtual DbSet<FileResourceType> FileResourceType { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<ComplianceSourceTypeMarkets> ComplianceSourceTypeMarkets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(DbManager.Instance.GetConnectionString());
                optionsBuilder.UseSqlServer("Server=.;Database=Express_Local;Initial Catalog=Express_Local;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplianceDistributorData>(entity =>
            {
                entity.ToTable("ComplianceDistributorData", "Eth");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((99))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FieldData).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.ComplianceSourceType)
                    .WithMany(p => p.ComplianceDistributorData)
                    .HasForeignKey(d => d.ComplianceSourceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ComplianceDistributorData_ComplianceSourceTypeId");
            });

            modelBuilder.Entity<ComplianceDistributorDataLogs>(entity =>
            {
                entity.HasKey(e => e.ComplianceDistributorLogId)
                    .HasName("PK__Complian__914C46BF57A8EE80");

                entity.ToTable("ComplianceDistributorDataLogs", "Eth");

                entity.Property(e => e.ComplianceDistributorLogData)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ComplianceDistributorLogMessage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((99))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.ComplianceDistributorData)
                    .WithMany(p => p.ComplianceDistributorDataLogs)
                    .HasForeignKey(d => d.ComplianceDistributorDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ComplianceDistributorDataLogs_ComplianceDistributorDataId");
            });

            modelBuilder.Entity<ComplianceFieldType>(entity =>
            {
                entity.ToTable("ComplianceFieldType", "Eth");

                entity.Property(e => e.ComplianceFieldTypeName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((99))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FieldPath).HasMaxLength(500);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.TranslationKey)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.InputBehaviour)
                    .WithMany(p => p.ComplianceFieldType)
                    .HasForeignKey(d => d.InputBehaviourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ComplianceFieldType_InputBehaviourId");

                entity.HasOne(d => d.FileResourceType)
                .WithMany(p => p.ComplianceFieldTypes)
                .HasForeignKey(d => d.FileResourceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_ComplianceFieldType_FileesourceTypeId");
            });

            modelBuilder.Entity<ComplianceSource>(entity =>
            {
                entity.ToTable("ComplianceSource", "Eth");

                entity.Property(e => e.ComplianceSourceName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((99))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<ComplianceSourceTypes>(entity =>
            {
                entity.HasKey(e => e.ComplianceSourceTypeId)
                    .HasName("PK__Complian__C74CA0CF50690A2E");

                entity.ToTable("ComplianceSourceTypes", "Eth");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((99))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.ComplianceFieldType)
                    .WithMany(p => p.ComplianceSourceTypes)
                    .HasForeignKey(d => d.ComplianceFieldTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ComplianceSourceTypes_ComplianceFieldTypeId");

                entity.HasOne(d => d.ComplianceSource)
                    .WithMany(p => p.ComplianceSourceTypes)
                    .HasForeignKey(d => d.ComplianceSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ComplianceSource_ComplianceSourceId");
            });

            modelBuilder.Entity<InputBehaviour>(entity =>
            {
                entity.ToTable("InputBehaviour", "Gbl");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((99))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InputBehaviourName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<FileResourceExtension>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.FileResourceType)
                    .WithMany(p => p.FileResourceExtension)
                    .HasForeignKey(d => d.FileResourceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FileResou__FileR__4C57E14D");
            });

            modelBuilder.Entity<FileResourceType>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TranslationKey)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasIndex(e => e.Status);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Companyaddressid).HasColumnName("COMPANYADDRESSID");

                entity.Property(e => e.Companycode)
                    .HasColumnName("COMPANYCODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Companyemail)
                    .HasColumnName("COMPANYEMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Companyphone)
                    .HasColumnName("COMPANYPHONE")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencySymbol)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultCultureInfo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Isnfr).HasColumnName("ISNFR");

                entity.Property(e => e.MarketCurrency)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MarketDescription)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MarketName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaxamountNfr).HasColumnName("MAXAMOUNT_NFR");

                entity.Property(e => e.MaxamountlimitNfr)
                    .HasColumnName("MAXAMOUNTLIMIT_NFR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaxcurrencyNfr).HasColumnName("MAXCURRENCY_NFR");

                entity.Property(e => e.MaxcurrencylimitNfr)
                    .HasColumnName("MAXCURRENCYLIMIT_NFR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaxvolumeNfr).HasColumnName("MAXVOLUME_NFR");

                entity.Property(e => e.MaxvolumelimitNfr)
                    .HasColumnName("MAXVOLUMELIMIT_NFR")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MerchantCurrency)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MinAge).HasColumnName("MIN_AGE");

                entity.Property(e => e.Nfrcompanycode)
                    .HasColumnName("NFRCOMPANYCODE")
                    .HasMaxLength(50);

                entity.Property(e => e.Nfrcurrency)
                    .HasColumnName("NFRCURRENCY")
                    .HasMaxLength(50);

                entity.Property(e => e.Primarywarehouse).HasColumnName("PRIMARYWAREHOUSE");

                entity.Property(e => e.Secondarywarehouse).HasColumnName("SECONDARYWAREHOUSE");

                entity.Property(e => e.Setcompanydetail).HasColumnName("SETCOMPANYDETAIL");

                entity.Property(e => e.Settaxintegration).HasColumnName("SETTAXINTEGRATION");

                entity.Property(e => e.Shippingcurrency)
                    .HasColumnName("SHIPPINGCURRENCY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShowFlagStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StageNfr).HasColumnName("STAGE_NFR");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ComplianceSourceTypeMarkets>(ctm =>
            {
                ctm.HasKey(e => e.ComplianceSourceTypeMarketId)
                    .HasName("PK_ComplianceSourceTypeMarket_ComplianceSourceTypeMarketId");

                ctm.ToTable("ComplianceSourceTypeMarkets", "eth");

                ctm.Property(e => e.CreatedBy).HasDefaultValueSql("((99))");

                ctm.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                //ctm.Property(e => e.Status).HasDefaultValueSql("((1))");

                ctm.Property(e => e.UpdatedDate).HasColumnType("date");

                ctm.HasOne(d => d.Markets)
                    .WithMany(p => p.ComplianceSourceTypeMarkets)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplianceSourceTypeMarkets_Market");

                ctm.HasOne(d => d.ComplianceSourceType)
                    .WithMany(p => p.ComplianceSourceTypeMarkets)
                    .HasForeignKey(d => d.ComplianceSourceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplianceSourceTypeMarkets_ComplianceSourceType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
