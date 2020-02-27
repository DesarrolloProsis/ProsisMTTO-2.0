using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProsisMTTO.Model
{
    public partial class ProsisMTTOContext : DbContext
    {
        public ProsisMTTOContext()
        {
        }

        public ProsisMTTOContext(DbContextOptions<ProsisMTTOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminSquares> AdminSquares { get; set; }
        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Dtcheaders> Dtcheaders { get; set; }
        public virtual DbSet<Dtcinventories> Dtcinventories { get; set; }
        public virtual DbSet<Dtcmovements> Dtcmovements { get; set; }
        public virtual DbSet<Dtcservices> Dtcservices { get; set; }
        public virtual DbSet<Dtctechnical> Dtctechnical { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<LanesCatalogs> LanesCatalogs { get; set; }
        public virtual DbSet<ReplacementCatalogs> ReplacementCatalogs { get; set; }
        public virtual DbSet<ServiceTypes> ServiceTypes { get; set; }
        public virtual DbSet<SquaresCatalogs> SquaresCatalogs { get; set; }
        public virtual DbSet<TypeCarrils> TypeCarrils { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=192.168.0.23 ;Initial Catalog=ProsisMTTO;
	Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminSquares>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.HasIndex(e => e.SquaresCatalogId);

                entity.Property(e => e.NomOperador).HasMaxLength(60);

                entity.Property(e => e.NumCapufe).HasMaxLength(30);

                entity.Property(e => e.NumGea).HasMaxLength(30);

                entity.Property(e => e.SquaresCatalogId).HasMaxLength(10);

                entity.HasOne(d => d.SquaresCatalog)
                    .WithMany(p => p.AdminSquares)
                    .HasForeignKey(d => d.SquaresCatalogId);
            });

            modelBuilder.Entity<Components>(entity =>
            {
                entity.HasKey(e => e.ComponentId);

                entity.HasIndex(e => e.ServiceTypeId);

                entity.HasIndex(e => e.UnitId);

                entity.Property(e => e.Brand).HasMaxLength(25);

                entity.Property(e => e.ComponentName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Model).HasMaxLength(25);

                entity.Property(e => e.Year).HasMaxLength(4);

                entity.HasOne(d => d.AgreementNum)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.AgreementNumId)
                    .HasConstraintName("FK_Component_DTCHeader");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.ServiceTypeId);

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.UnitId);
            });

            modelBuilder.Entity<Dtcheaders>(entity =>
            {
                entity.HasKey(e => e.AgreementNum);

                entity.ToTable("DTCHeaders");

                entity.Property(e => e.AgreementNum).ValueGeneratedNever();

                entity.Property(e => e.Mail).HasMaxLength(35);

                entity.Property(e => e.ManagerName).HasMaxLength(40);

                entity.Property(e => e.Position).HasMaxLength(80);
            });

            modelBuilder.Entity<Dtcinventories>(entity =>
            {
                entity.HasKey(e => new { e.DtctechnicalId, e.InventoryId });

                entity.ToTable("DTCInventories");

                entity.HasIndex(e => e.InventoryId)
                    .IsUnique();

                entity.Property(e => e.DtctechnicalId)
                    .HasColumnName("DTCTechnicalId")
                    .HasMaxLength(20);

                entity.Property(e => e.Location).HasMaxLength(5);

                entity.HasOne(d => d.Dtctechnical)
                    .WithMany(p => p.Dtcinventories)
                    .HasForeignKey(d => d.DtctechnicalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DTCInventories_DTCTechnical");

                entity.HasOne(d => d.Inventory)
                    .WithOne(p => p.Dtcinventories)
                    .HasForeignKey<Dtcinventories>(d => d.InventoryId);
            });

            modelBuilder.Entity<Dtcmovements>(entity =>
            {
                entity.HasKey(e => e.MovementId)
                    .HasName("PrimaryKey_MovementId");

                entity.ToTable("DTCMovements");

                entity.HasIndex(e => e.DtctechnicalId);

                entity.Property(e => e.MovementId).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.DtctechnicalId)
                    .HasColumnName("DTCTechnicalId")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Dtctechnical)
                    .WithMany(p => p.Dtcmovements)
                    .HasForeignKey(d => d.DtctechnicalId)
                    .HasConstraintName("FK_DTCMovements_DTCTechnical");
            });

            modelBuilder.Entity<Dtcservices>(entity =>
            {
                entity.HasKey(e => new { e.DtctechnicalId, e.ComponentId });

                entity.ToTable("DTCServices");

                entity.HasIndex(e => e.ComponentId);

                entity.Property(e => e.DtctechnicalId)
                    .HasColumnName("DTCTechnicalId")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.Dtcservices)
                    .HasForeignKey(d => d.ComponentId);

                entity.HasOne(d => d.Dtctechnical)
                    .WithMany(p => p.Dtcservices)
                    .HasForeignKey(d => d.DtctechnicalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DTCServices_DTCTechnicals");
            });

            modelBuilder.Entity<Dtctechnical>(entity =>
            {
                entity.HasKey(e => e.ReferenceNum);

                entity.ToTable("DTCTechnical");

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.LanesCatalogCapufeLaneNum, e.LanesCatalogIdGare });

                entity.Property(e => e.ReferenceNum).HasMaxLength(20);

                entity.Property(e => e.AxaNum).HasMaxLength(8);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.Diagnostic).HasMaxLength(30);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.LanesCatalogCapufeLaneNum).HasMaxLength(20);

                entity.Property(e => e.LanesCatalogIdGare).HasMaxLength(3);

                entity.Property(e => e.Observation).HasMaxLength(300);

                entity.Property(e => e.OpinionType).HasMaxLength(30);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.HasOne(d => d.AgreementNum)
                    .WithMany(p => p.Dtctechnical)
                    .HasForeignKey(d => d.AgreementNumId)
                    .HasConstraintName("FK_DTCTech_DTCHeader");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Dtctechnical)
                    .HasForeignKey(d => d.UserId);

                entity.HasOne(d => d.LanesCatalog)
                    .WithMany(p => p.Dtctechnical)
                    .HasForeignKey(d => new { d.LanesCatalogCapufeLaneNum, d.LanesCatalogIdGare });
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasIndex(e => e.ComponentId);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.InventoryImage).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.NumPart).HasMaxLength(50);

                entity.Property(e => e.PieceYear).HasMaxLength(4);

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.ComponentId);
            });

            modelBuilder.Entity<LanesCatalogs>(entity =>
            {
                entity.HasKey(e => new { e.CapufeLaneNum, e.IdGare })
                    .HasName("PrimaryKey_CapufeLaneNum");

                entity.HasIndex(e => e.SquaresCatalogId);

                entity.HasIndex(e => e.TypeCarrilId);

                entity.Property(e => e.CapufeLaneNum).HasMaxLength(20);

                entity.Property(e => e.IdGare).HasMaxLength(3);

                entity.Property(e => e.Lane)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.SquaresCatalogId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.SquaresCatalog)
                    .WithMany(p => p.LanesCatalogs)
                    .HasForeignKey(d => d.SquaresCatalogId);

                entity.HasOne(d => d.TypeCarril)
                    .WithMany(p => p.LanesCatalogs)
                    .HasForeignKey(d => d.TypeCarrilId);
            });

            modelBuilder.Entity<ReplacementCatalogs>(entity =>
            {
                entity.HasKey(e => e.ReplacementCatalogId);

                entity.HasIndex(e => e.ComponentId);

                entity.Property(e => e.Model).HasMaxLength(30);

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.ReplacementCatalogs)
                    .HasForeignKey(d => d.ComponentId);
            });

            modelBuilder.Entity<ServiceTypes>(entity =>
            {
                entity.HasKey(e => e.ServiceTypeId);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<SquaresCatalogs>(entity =>
            {
                entity.HasKey(e => e.SquareNum)
                    .HasName("PrimaryKey_SquareNum");

                entity.Property(e => e.SquareNum).HasMaxLength(10);

                entity.Property(e => e.Delegation)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SquareName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TypeCarrils>(entity =>
            {
                entity.HasKey(e => e.TypeCarrilId);

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.UnitTypeId);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PrimaryKey_UserId");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.Password).HasMaxLength(10);

                entity.Property(e => e.UserName).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
