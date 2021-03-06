﻿using Microsoft.EntityFrameworkCore;
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
            public DbSet<SquaresCatalog> SquaresCatalogs { get; set; }
            public DbSet<LanesCatalog> LanesCatalogs { get; set; }
            public DbSet<DTCHeader> DTCHeaders { get; set; }
            public DbSet<DTCMovement> DTCMovements { get; set; }
            public DbSet<DTCTechnical> DTCTechnical { get; set; }
            public DbSet<TypeCarril> TypeCarrils { get; set; }
            public DbSet<Inventory> Inventories { get; set; }
            public DbSet<DTCInventory> DTCInventories { get; set; }
            public DbSet<Unit> Units { get; set; }
            public DbSet<ServiceType> ServiceTypes { get; set; }
            public DbSet<DTCService> DTCServices { get; set; }
            public DbSet<Component> Components { get; set; }
            public DbSet<AdminSquare> AdminSquares{ get; set; }
            public DbSet<ReplacementCatalog> ReplacementCatalogs{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            modelBuilder.Entity<TypeCarril>().HasData(
                new TypeCarril {TypeCarrilId = 1, Name = "Express"},
                new TypeCarril { TypeCarrilId = 2, Name = "Multimodal"}
            );

            modelBuilder.Entity<TypeCarril>(db =>
            {
                db.Property<string>("Name")
                    .HasColumnType("nvarchar(10)")
                    .HasMaxLength(10);

            });

            modelBuilder.Entity<ServiceType>().HasData(
                new ServiceType { ServiceTypeId = 1, Name = "Servicio" },
                new ServiceType { ServiceTypeId = 2, Name = "Refaccion" },
                new ServiceType { ServiceTypeId = 3, Name = "Componente" }
            );

            modelBuilder.Entity<ServiceType>(db =>
            {
                db.Property<string>("Name")
                    .HasColumnType("nvarchar(20)")
                    .HasMaxLength(20);

            });

            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitTypeId = 1, Name = "Pza" },
                new Unit { UnitTypeId = 2, Name = "Metro" },
                new Unit { UnitTypeId = 3, Name = "Mano de Obra" }
            );

            modelBuilder.Entity<Unit>(db =>
            {
                db.HasKey("UnitTypeId");

                db.Property<string>("Name")
                    .HasColumnType("nvarchar(20)")
                    .HasMaxLength(20);

            });




            modelBuilder.Entity<Component>(db =>
            {
                db.Property<string>("ComponentName")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

                db.Property<string>("Year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                db.Property<double>("Price")
                        .HasColumnType("real");

                db.Property<string>("Brand")
                    .HasColumnType("nvarchar(25)")
                    .HasMaxLength(25);

                db.Property<string>("Model")
                    .HasColumnType("nvarchar(25)")
                    .HasColumnName("Model")
                    .HasMaxLength(25);

                db.Property<string>("Description")
                    .HasColumnType("nvarchar(300)")
                    .HasMaxLength(300);
            });


            modelBuilder.Entity<DTCInventory>(db =>
            {
                db.HasKey("DTCTechnicalId", "InventoryId");

                db.Property<DateTime>("DateRecordRequest")
                        .HasColumnType("datetime2");

                db.Property<string>("Location")
                   .HasColumnType("nvarchar(5)")
                   .HasMaxLength(5);



            });

            modelBuilder.Entity<DTCService>(db =>
            {
                db.HasKey("DTCTechnicalId", "ComponentId");

                db.Property<DateTime>("DateRecord")
                        .HasColumnType("datetime2");

            });


            modelBuilder.Entity<AdminSquare>(db =>
            {
     
                db.HasKey("AdminId");

                db.Property<string>("NumCapufe")
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                db.Property<string>("NumGea")
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30);

                db.Property<string>("NomOperador")
                .HasColumnType("nvarchar(60)")
                .HasMaxLength(60);
                
            });


            modelBuilder.Entity<ReplacementCatalog>(db =>
            {

                db.HasKey("ReplacementCatalogId");
               

                db.Property<string>("Model")
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30);

                //db.HasOne("ProsisMTTO.Entities.Component", null)
                //       .WithMany("ReplacementCatalog")
                //       .HasForeignKey( "ComponentId")
                //       .OnDelete(DeleteBehavior.Cascade)
                //       .IsRequired();

              

            });



            modelBuilder.Entity<User>(db =>
                {
                    db.Property<int>("UserId")
                            .HasColumnType("int")
                            .HasMaxLength(10);

                    db.Property<string>("Email")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    db.Property<string>("UserName")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    db.Property<string>("Password")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

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

            modelBuilder.Entity<Inventory>(db =>
            {
                db.Property<int>("Id")
                        .HasColumnType("int");

                db.Property<string>("NumPart")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                db.Property<string>("Description")
                    .HasColumnType("nvarchar(300)")
                    .HasMaxLength(300);

                db.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(25)")
                    .HasMaxLength(25);

                db.Property<string>("PieceYear")
                    .HasColumnType("nvarchar(4)")
                    .HasMaxLength(4);

                db.Property<string>("InventoryImage")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(500);

                db.Property<int>("Unit")
                    .HasColumnType("int");

                db.HasKey("Id")
                    .HasName("PrimaryKey_Id");

                db.ToTable("Inventory");
            });

            modelBuilder.Entity<LanesCatalog>(db =>
                {
                    db.Property<string>("CapufeLaneNum")
                            .HasColumnType("nvarchar(20)")
                            .HasMaxLength(20);

                    db.Property<string>("IdGare")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    db.Property<string>("Lane")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    db.Property<int>("LaneType")
                        .HasColumnType("int")
                        .HasMaxLength(15);

                    db.Property<string>("SquaresCatalogId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    db.HasKey("CapufeLaneNum", "IdGare")
                        .HasName("PrimaryKey_CapufeLaneNum");
                

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
                    .HasColumnType("nvarchar(300)")
                    .HasMaxLength(300);

                db.Property<string>("Diagnostic")
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                db.Property<DateTime>("ElaborationDate")
                    .HasColumnType("datetime2");

                db.Property<DateTime>("FailureDate")
                    .HasColumnType("datetime2");

                //db.Property<int>("FailureNum")
                //    .HasColumnType("int");

                db.Property<string>("Image")
                    .HasColumnType("nvarchar(500)")
                    .HasMaxLength(500);

                db.Property<DateTime>("IncidentDate")
                    .HasColumnType("datetime2");

                //db.Property<string>("LanesCatalogId")
                //    .IsRequired()
                //    .HasColumnType("nvarchar(20)");

                //db.Property<string>("IdGare")
                //    .IsRequired()
                //    .HasColumnType("nvarchar(3)")
                //    .HasMaxLength(3);

                db.Property<string>("Observation")
                    .HasColumnType("nvarchar(300)")
                    .HasMaxLength(300);

                db.Property<string>("OpinionType")
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                db.Property<DateTime>("ShippingDate")
                    .HasColumnType("datetime2");

                db.Property<string>("Status")
                    .HasColumnType("nvarchar(30)")
                    .HasMaxLength(30);

                //db.Property<int>("UserId")
                //    .HasColumnType("int");

                db.HasKey("ReferenceNum")
                    .HasName("PrimaryKey_ReferenceNum");
                

                db.HasOne("ProsisMTTO.Entities.DTCHeader", null)
                        .WithOne("DTCTechnical")
                        .HasForeignKey("ProsisMTTO.Entities.DTCTechnical", "DTCHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                //db.HasOne("ProsisMTTO.Entities.LanesCatalog", null)
                //    .WithMany("DTCTechnical")
                //    .HasForeignKey("ProsisMTTO.Entities.DTCTechnical", "LanesCatalogId", "IdGare")
                //    .OnDelete(DeleteBehavior.Cascade)
                //    .IsRequired();


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
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

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

                    db.Property<string>("Mail")
                    .HasColumnType("nvarchar(35)")
                    .HasMaxLength(35);
                });
            }
        }
}

