﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Venu.Ticketing.Infrastructure;

namespace Venu.Ticketing.API.Data.Migrations
{
    [DbContext(typeof(TicketingContext))]
    [Migration("20200426045609_UpdateVenueSection")]
    partial class UpdateVenueSection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Venu.Ticketing.Domain.AggregatesModel.EventAggregate.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Venu.Ticketing.Domain.AggregatesModel.EventAggregate.VenueSection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("VenueSectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("EventId")
                        .HasColumnType("text");

                    b.Property<string>("VenueId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("VenueSection");
                });

            modelBuilder.Entity("Venu.Ticketing.Domain.AggregatesModel.EventAggregate.VenueSection", b =>
                {
                    b.HasOne("Venu.Ticketing.Domain.AggregatesModel.EventAggregate.Event", null)
                        .WithMany("VenueSections")
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}
