﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolutionsService.Data;

namespace SolutionsService.Migrations
{
    [DbContext(typeof(SolutionsServiceContext))]
    partial class SolutionsServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SolutionsService.Models.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SolutionId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("SolutionsService.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SolutionId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SolutionsService.Models.SDG", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SDGNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SDGs");
                });

            modelBuilder.Entity("SolutionsService.Models.SDGSolution", b =>
                {
                    b.Property<Guid>("SDGId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SDGId", "SolutionId");

                    b.HasIndex("SolutionId");

                    b.ToTable("SDGSolutions");
                });

            modelBuilder.Entity("SolutionsService.Models.Solution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeaderImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.Property<string>("WeatherExtreme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("SolutionsService.Models.Step", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SolutionId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("SolutionsService.Models.Tool", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SolutionId");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("SolutionsService.Models.Article", b =>
                {
                    b.HasBaseType("SolutionsService.Models.Solution");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("SolutionsService.Models.HowTo", b =>
                {
                    b.HasBaseType("SolutionsService.Models.Solution");

                    b.Property<string>("Difficulty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("HowTos");
                });

            modelBuilder.Entity("SolutionsService.Models.Like", b =>
                {
                    b.HasOne("SolutionsService.Models.Solution", "Solution")
                        .WithMany("Likes")
                        .HasForeignKey("SolutionId");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("SolutionsService.Models.Material", b =>
                {
                    b.HasOne("SolutionsService.Models.HowTo", "Solution")
                        .WithMany("Materials")
                        .HasForeignKey("SolutionId");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("SolutionsService.Models.SDGSolution", b =>
                {
                    b.HasOne("SolutionsService.Models.SDG", "SDG")
                        .WithMany("Solutions")
                        .HasForeignKey("SDGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SolutionsService.Models.Solution", "Solution")
                        .WithMany("SDGs")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SDG");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("SolutionsService.Models.Step", b =>
                {
                    b.HasOne("SolutionsService.Models.HowTo", "Solution")
                        .WithMany("Steps")
                        .HasForeignKey("SolutionId");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("SolutionsService.Models.Tool", b =>
                {
                    b.HasOne("SolutionsService.Models.HowTo", "Solution")
                        .WithMany("Tools")
                        .HasForeignKey("SolutionId");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("SolutionsService.Models.Article", b =>
                {
                    b.HasOne("SolutionsService.Models.Solution", null)
                        .WithOne()
                        .HasForeignKey("SolutionsService.Models.Article", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SolutionsService.Models.HowTo", b =>
                {
                    b.HasOne("SolutionsService.Models.Solution", null)
                        .WithOne()
                        .HasForeignKey("SolutionsService.Models.HowTo", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SolutionsService.Models.SDG", b =>
                {
                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("SolutionsService.Models.Solution", b =>
                {
                    b.Navigation("Likes");

                    b.Navigation("SDGs");
                });

            modelBuilder.Entity("SolutionsService.Models.HowTo", b =>
                {
                    b.Navigation("Materials");

                    b.Navigation("Steps");

                    b.Navigation("Tools");
                });
#pragma warning restore 612, 618
        }
    }
}
