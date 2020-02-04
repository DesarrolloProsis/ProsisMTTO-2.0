using Microsoft.EntityFrameworkCore;
using ProsisMTTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsisMTTO.Context
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

            public DbSet<User> Users { get; set; }
            public DbSet<SparePartsCatalog> SparePartsCatalogs { get; set; }
            public DbSet<SquaresCatalog> SquaresCatalogs { get; set; }
            public DbSet<LanesCatalog> LanesCatalogs { get; set; }
            public DbSet<DTCHeader> DTCHeaders { get; set; }
            public DbSet<DTCMovement> DTCMovements { get; set; }
            public DbSet<DTCTechnical> DTCTechnical { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>(db =>
                {
                    db.Property<int>("UserId")
                            .HasColumnType("int")
                            .HasMaxLength(10);

                    db.Property<string>("Email")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    db.Property<string>("UserName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    db.HasKey("UserId")
                        .HasName("PrimaryKey_UserId");


                    db.ToTable("Users");
                });

                modelBuilder.Entity<SquaresCatalog>(db =>
                {
                    db.Property<string>("SquareNum")
                            .HasColumnType("nvarchar(10)")
                            .HasMaxLength(10);

                    db.Property<string>("Delegation")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    db.Property<string>("SquareName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    db.HasKey("SquareNum")
                        .HasName("PrimaryKey_SquareNum");

                    db.ToTable("SquaresCatalogs");
                });

                modelBuilder.Entity<SparePartsCatalog>(db =>
                {
                    db.Property<string>("NumPart")
                            .HasColumnType("nvarchar(50)")
                            .HasMaxLength(50);

                    db.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    db.Property<string>("DTCTechnicalReferenceNum")
                        .HasColumnType("nvarchar(10)");

                    db.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    db.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    db.Property<string>("PieceYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    db.Property<float>("Price")
                        .HasColumnType("real");

                    db.Property<string>("SparePartImage")
                        .HasColumnType("nvarchar(max)");

                    db.Property<string>("TypeService")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    db.Property<int>("Unit")
                        .HasColumnType("int");

                    db.HasKey("NumPart")
                        .HasName("PrimaryKey_NumPart");

                    db.HasIndex("DTCTechnicalReferenceNum");

                    db.ToTable("SparePartsCatalogs");
                });

                modelBuilder.Entity<LanesCatalog>(db =>
                {
                    db.Property<string>("CapufeLaneNum")
                            .HasColumnType("nvarchar(20)")
                            .HasMaxLength(20);

                    db.Property<string>("Lane")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    db.Property<int>("LaneType")
                        .HasColumnType("int")
                        .HasMaxLength(15);

                    db.Property<int>("SquaresCatalogId")
                        .HasColumnType("int");

                    db.Property<string>("SquaresCatalogSquareNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    db.HasKey("CapufeLaneNum")
                        .HasName("PrimaryKey_CapufeLaneNum");

                    db.HasIndex("SquaresCatalogSquareNum");

                    db.ToTable("LanesCatalogs");
                });

                modelBuilder.Entity<DTCTechnical>(db =>
                {
                    db.Property<string>("ReferenceNum")
                            .HasColumnType("nvarchar(10)")
                            .HasMaxLength(10);

                    db.Property<string>("AxaNum")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    db.Property<string>("DTCHeaderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    db.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    db.Property<string>("Diagnostic")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    db.Property<DateTime>("ElaborationDate")
                        .HasColumnType("datetime2");

                    db.Property<DateTime>("FailureDate")
                        .HasColumnType("datetime2");

                    db.Property<int>("FailureNum")
                        .HasColumnType("int");

                    db.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    db.Property<DateTime>("IncidentDate")
                        .HasColumnType("datetime2");

                    db.Property<string>("LanesCatalogId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    db.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    db.Property<string>("OpinionType")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    db.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    db.Property<string>("Status")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    db.Property<int>("UserId")
                        .HasColumnType("int");

                    db.HasKey("ReferenceNum")
                        .HasName("PrimaryKey_ReferenceNum");

                    db.HasIndex("DTCHeaderId")
                        .IsUnique();

                    db.HasIndex("LanesCatalogId")
                        .IsUnique();

                    db.HasIndex("UserId");

                    db.HasOne("ProsisMTTO.Entities.DTCHeader", null)
                            .WithOne("DTCTechnical")
                            .HasForeignKey("ProsisMTTO.Entities.DTCTechnical", "DTCHeaderId")
                            .OnDelete(DeleteBehavior.Cascade)
                            .IsRequired();

                    db.HasOne("ProsisMTTO.Entities.LanesCatalog", null)
                        .WithOne("DTCTechnical")
                        .HasForeignKey("ProsisMTTO.Entities.DTCTechnical", "LanesCatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    db.HasOne("ProsisMTTO.Entities.User", null)
                        .WithMany("DTCTechnical")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    db.ToTable("DTCTechnical");
                });

                modelBuilder.Entity<DTCMovement>(db =>
                {
                    db.Property<string>("MovementId")
                            .HasColumnType("nvarchar(20)")
                            .HasMaxLength(20);

                    db.Property<string>("DTCTechnicalId")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    db.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    db.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    db.HasKey("MovementId")
                        .HasName("PrimaryKey_MovementId");

                    db.HasIndex("DTCTechnicalId");

                    db.HasOne("ProsisMTTO.Entities.DTCTechnical", "DTCTechnical")
                            .WithMany("DTCMovements")
                            .HasForeignKey("DTCTechnicalId");

                    db.ToTable("DTCMovements");
                });

                modelBuilder.Entity<DTCHeader>(db =>
                {
                    db.Property<string>("DTCHeaderId")
                            .HasColumnType("nvarchar(20)")
                            .HasMaxLength(20);

                    db.Property<int>("AgreementNum")
                        .HasColumnType("int");

                    db.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    db.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    db.HasKey("DTCHeaderId")
                        .HasName("PrimaryKey_DTCHeaderId");

                    db.ToTable("DTCHeaders");
                });
            }
        }
}

