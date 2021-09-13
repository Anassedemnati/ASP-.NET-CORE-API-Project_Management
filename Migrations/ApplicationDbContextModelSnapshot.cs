﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_api_pract.Data;

namespace web_api_pract.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("web_api_pract.Data.Models.Devloper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devlopers");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("custumer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("finished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Project_Devloper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DevloperId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DevloperId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Project_Devlopers");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Project", b =>
                {
                    b.HasOne("web_api_pract.Data.Models.Manager", "manager")
                        .WithMany("Projects")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("manager");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Project_Devloper", b =>
                {
                    b.HasOne("web_api_pract.Data.Models.Devloper", "devloper")
                        .WithMany("project_devlopers")
                        .HasForeignKey("DevloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_api_pract.Data.Models.Project", "project")
                        .WithMany("project_devlopers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("devloper");

                    b.Navigation("project");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Devloper", b =>
                {
                    b.Navigation("project_devlopers");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Manager", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("web_api_pract.Data.Models.Project", b =>
                {
                    b.Navigation("project_devlopers");
                });
#pragma warning restore 612, 618
        }
    }
}
