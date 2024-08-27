﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restful_API.Data;

#nullable disable

namespace Restful_API.Migrations
{
    [DbContext(typeof(MarketVisitContext))]
    partial class MarketVisitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restful_API.MarketVisit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("isr_id")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("visit_accountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_accountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_averageOffTakePd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_competitorsCheck")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_distributor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_isrNeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_pap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_payolaMerchandiser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_payolaSupervisor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_podCanned")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_podMPP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("visit_salesPersonnel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("isr_id");

                    b.HasIndex("user_id");

                    b.ToTable("MarketVisits");
                });

            modelBuilder.Entity("Restful_API.Model.Isr", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("image_path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("isr_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("isr_others")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("isr_type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Isrs");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("abfi_id")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("contact_num")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("date_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("email_add")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Restful_API.MarketVisit", b =>
                {
                    b.HasOne("Restful_API.Model.Isr", "Isr")
                        .WithMany()
                        .HasForeignKey("isr_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Isr");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
