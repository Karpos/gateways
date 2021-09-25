﻿// <auto-generated />
using System;
using Gateways.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gateways.Migrations
{
    [DbContext(typeof(GatewaysContext))]
    partial class GatewaysContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gateways.Models.Device", b =>
                {
                    b.Property<long>("UID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Vendor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID");

                    b.HasIndex("SerialNumber");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Gateways.Models.Gateway", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IpAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerialNumber");

                    b.ToTable("Gateways");
                });

            modelBuilder.Entity("Gateways.Models.Device", b =>
                {
                    b.HasOne("Gateways.Models.Gateway", "Gateway")
                        .WithMany("Devices")
                        .HasForeignKey("SerialNumber");

                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("Gateways.Models.Gateway", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
