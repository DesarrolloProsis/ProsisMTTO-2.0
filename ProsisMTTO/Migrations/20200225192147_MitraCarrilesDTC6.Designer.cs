﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProsisMTTO.Context;

namespace ProsisMTTO.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200225192147_MitraCarrilesDTC6")]
    partial class MitraCarrilesDTC6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProsisMTTO.Entities.AdminSquare", b =>
                {
                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NomOperador")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("NumCapufe")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("NumGea")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("SquaresCatalogId")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("AdminId");

                    b.HasIndex("SquaresCatalogId");

                    b.ToTable("AdminSquares");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.Component", b =>
                {
                    b.Property<int>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AutomaticSignature")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("ComponentName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Model")
                        .HasColumnName("Model")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("ComponentId");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCHeader", b =>
                {
                    b.Property<string>("DTCHeaderId")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("AgreementNum")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("DTCHeaderId")
                        .HasName("PrimaryKey_DTCHeaderId");

                    b.ToTable("DTCHeaders");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCInventory", b =>
                {
                    b.Property<string>("DTCTechnicalId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Authorization")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateRecordRequest")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.HasKey("DTCTechnicalId", "InventoryId");

                    b.HasIndex("InventoryId")
                        .IsUnique();

                    b.ToTable("DTCInventories");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCMovement", b =>
                {
                    b.Property<string>("MovementId")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("DTCTechnicalId")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovementId")
                        .HasName("PrimaryKey_MovementId");

                    b.HasIndex("DTCTechnicalId");

                    b.ToTable("DTCMovements");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCService", b =>
                {
                    b.Property<string>("DTCTechnicalId")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRecord")
                        .HasColumnType("datetime2");

                    b.HasKey("DTCTechnicalId", "ComponentId");

                    b.HasIndex("ComponentId");

                    b.ToTable("DTCServices");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCTechnical", b =>
                {
                    b.Property<string>("ReferenceNum")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("AxaNum")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("DTCHeaderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Diagnostic")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ElaborationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FailureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FailureNum")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("IncidentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LanesCatalogCapufeLaneNum")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LanesCatalogIdGare")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("OpinionType")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReferenceNum")
                        .HasName("PrimaryKey_ReferenceNum");

                    b.HasIndex("DTCHeaderId");

                    b.HasIndex("UserId");

                    b.HasIndex("LanesCatalogCapufeLaneNum", "LanesCatalogIdGare");

                    b.ToTable("DTCTechnical");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("InventoryImage")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("NumPart")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PieceYear")
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_Id");

                    b.HasIndex("ComponentId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.LanesCatalog", b =>
                {
                    b.Property<string>("CapufeLaneNum")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("IdGare")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Lane")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.Property<int>("LaneType")
                        .HasColumnType("int")
                        .HasMaxLength(15);

                    b.Property<string>("SquaresCatalogId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("TypeCarrilId")
                        .HasColumnType("int");

                    b.HasKey("CapufeLaneNum", "IdGare")
                        .HasName("PrimaryKey_CapufeLaneNum");

                    b.HasIndex("SquaresCatalogId");

                    b.HasIndex("TypeCarrilId");

                    b.ToTable("LanesCatalogs");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.ReplacementCatalog", b =>
                {
                    b.Property<int>("ReplacementCatalogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComponentId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ReplacementCatalogId");

                    b.HasIndex("ComponentId");

                    b.ToTable("ReplacementCatalogs");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.ServiceType", b =>
                {
                    b.Property<int>("ServiceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ServiceTypeId");

                    b.ToTable("ServiceTypes");

                    b.HasData(
                        new
                        {
                            ServiceTypeId = 1,
                            Name = "Servicio"
                        },
                        new
                        {
                            ServiceTypeId = 2,
                            Name = "Refaccion"
                        },
                        new
                        {
                            ServiceTypeId = 3,
                            Name = "Componente"
                        });
                });

            modelBuilder.Entity("ProsisMTTO.Entities.SquaresCatalog", b =>
                {
                    b.Property<string>("SquareNum")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Delegation")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("SquareName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("SquareNum")
                        .HasName("PrimaryKey_SquareNum");

                    b.ToTable("SquaresCatalogs");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.TypeCarril", b =>
                {
                    b.Property<int>("TypeCarrilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("TypeCarrilId");

                    b.ToTable("TypeCarrils");

                    b.HasData(
                        new
                        {
                            TypeCarrilId = 1,
                            Name = "Express"
                        },
                        new
                        {
                            TypeCarrilId = 2,
                            Name = "Multimodal"
                        });
                });

            modelBuilder.Entity("ProsisMTTO.Entities.Unit", b =>
                {
                    b.Property<int>("UnitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("UnitTypeId");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            UnitTypeId = 1,
                            Name = "Pza"
                        },
                        new
                        {
                            UnitTypeId = 2,
                            Name = "Metro"
                        },
                        new
                        {
                            UnitTypeId = 3,
                            Name = "Mano de Obra"
                        });
                });

            modelBuilder.Entity("ProsisMTTO.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("UserId")
                        .HasName("PrimaryKey_UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.AdminSquare", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.SquaresCatalog", null)
                        .WithMany("AdminSquares")
                        .HasForeignKey("SquaresCatalogId");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.Component", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.ServiceType", null)
                        .WithMany("Components")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.Unit", null)
                        .WithMany("Components")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCInventory", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.DTCTechnical", null)
                        .WithMany("DTCInventories")
                        .HasForeignKey("DTCTechnicalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.Inventory", null)
                        .WithOne("DTCInventory")
                        .HasForeignKey("ProsisMTTO.Entities.DTCInventory", "InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCMovement", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.DTCTechnical", "DTCTechnical")
                        .WithMany("DTCMovements")
                        .HasForeignKey("DTCTechnicalId");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCService", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.Component", null)
                        .WithMany("DTCServices")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.DTCTechnical", null)
                        .WithMany("DTCServices")
                        .HasForeignKey("DTCTechnicalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCTechnical", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.DTCHeader", null)
                        .WithMany("DTCTechnical")
                        .HasForeignKey("DTCHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.User", null)
                        .WithMany("DTCTechnical")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.LanesCatalog", "LanesCatalog")
                        .WithMany("DTCTechnical")
                        .HasForeignKey("LanesCatalogCapufeLaneNum", "LanesCatalogIdGare");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.Inventory", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.Component", null)
                        .WithMany("Inventories")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProsisMTTO.Entities.LanesCatalog", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.SquaresCatalog", null)
                        .WithMany("LanesCatalogs")
                        .HasForeignKey("SquaresCatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.TypeCarril", "TypeCarril")
                        .WithMany("LanesCatalogs")
                        .HasForeignKey("TypeCarrilId");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.ReplacementCatalog", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.Component", "component")
                        .WithMany("Replacements")
                        .HasForeignKey("ComponentId");
                });
#pragma warning restore 612, 618
        }
    }
}
