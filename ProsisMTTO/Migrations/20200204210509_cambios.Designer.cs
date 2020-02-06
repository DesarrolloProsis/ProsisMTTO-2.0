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
    [Migration("20200204210509_cambios")]
    partial class cambios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProsisMTTO.Entities.DTCHeader", b =>
                {
                    b.Property<string>("DTCHeaderId")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("AgreementNum")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ProsisMTTO.Entities.DTCMovement", b =>
                {
                    b.Property<string>("MovementId")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("DTCTechnicalId")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovementId")
                        .HasName("PrimaryKey_MovementId");

                    b.HasIndex("DTCTechnicalId");

                    b.ToTable("DTCMovements");
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
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IncidentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LanesCatalogId")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("DTCHeaderId")
                        .IsUnique();

                    b.HasIndex("LanesCatalogId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("DTCTechnical");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.LanesCatalog", b =>
                {
                    b.Property<string>("CapufeLaneNum")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

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

                    b.HasKey("CapufeLaneNum")
                        .HasName("PrimaryKey_CapufeLaneNum");

                    b.HasIndex("SquaresCatalogId");

                    b.ToTable("LanesCatalogs");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.SparePartsCatalog", b =>
                {
                    b.Property<string>("NumPart")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("DTCTechnicalReferenceNum")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("PieceYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("SparePartImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeService")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.HasKey("NumPart")
                        .HasName("PrimaryKey_NumPart");

                    b.HasIndex("DTCTechnicalReferenceNum");

                    b.ToTable("SparePartsCatalogs");
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

            modelBuilder.Entity("ProsisMTTO.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("UserId")
                        .HasName("PrimaryKey_UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCMovement", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.DTCTechnical", "DTCTechnical")
                        .WithMany("DTCMovements")
                        .HasForeignKey("DTCTechnicalId");
                });

            modelBuilder.Entity("ProsisMTTO.Entities.DTCTechnical", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.DTCHeader", null)
                        .WithOne("DTCTechnical")
                        .HasForeignKey("ProsisMTTO.Entities.DTCTechnical", "DTCHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.LanesCatalog", null)
                        .WithOne("DTCTechnical")
                        .HasForeignKey("ProsisMTTO.Entities.DTCTechnical", "LanesCatalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProsisMTTO.Entities.User", null)
                        .WithMany("DTCTechnical")
                        .HasForeignKey("UserId")
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
                });

            modelBuilder.Entity("ProsisMTTO.Entities.SparePartsCatalog", b =>
                {
                    b.HasOne("ProsisMTTO.Entities.DTCTechnical", "DTCTechnical")
                        .WithMany("SparePartsCatalogs")
                        .HasForeignKey("DTCTechnicalReferenceNum");
                });
#pragma warning restore 612, 618
        }
    }
}