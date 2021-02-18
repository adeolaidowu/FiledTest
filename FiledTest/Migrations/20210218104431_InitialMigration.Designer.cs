﻿// <auto-generated />
using System;
using FiledTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FiledTest.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210218104431_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("FiledTest.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityCode")
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FiledTest.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaymentState")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentStatus");
                });

            modelBuilder.Entity("FiledTest.Entities.PaymentStatus", b =>
                {
                    b.HasOne("FiledTest.Entities.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}