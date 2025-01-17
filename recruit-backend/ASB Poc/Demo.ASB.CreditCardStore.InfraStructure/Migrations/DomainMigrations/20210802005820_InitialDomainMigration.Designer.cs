﻿// <auto-generated />
using System;
using Demo.ASB.CreditCardStore.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.ASB.CreditCardStore.InfraStructure.Migrations.DomainMigrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210802005820_InitialDomainMigration")]
    partial class InitialDomainMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Demo.ASB.CreditCardStore.Domain.Entities.CardHolder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardHolderName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CardHolders");
                });

            modelBuilder.Entity("Demo.ASB.CreditCardStore.Domain.Entities.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CVC")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<Guid>("CardHolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreditCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CardHolderId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Demo.ASB.CreditCardStore.Domain.Entities.CreditCard", b =>
                {
                    b.HasOne("Demo.ASB.CreditCardStore.Domain.Entities.CardHolder", "CardHolder")
                        .WithMany("CreditCards")
                        .HasForeignKey("CardHolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
