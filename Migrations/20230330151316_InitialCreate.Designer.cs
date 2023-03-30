﻿// <auto-generated />
using System;
using Aviasales_v3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aviasales_v3.Migrations
{
    [DbContext(typeof(Aviasales_v3Context))]
    [Migration("20230330151316_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aviasales_v3.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Free_Seats")
                        .HasColumnType("int");

                    b.Property<DateTime>("When")
                        .HasColumnType("datetime2");

                    b.Property<string>("Where_From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Where_To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("Aviasales_v3.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("Flight_Id")
                        .HasColumnType("int");

                    b.Property<int>("Ticket_Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Aviasales_v3.Models.Ticket", b =>
                {
                    b.HasOne("Aviasales_v3.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.Navigation("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
