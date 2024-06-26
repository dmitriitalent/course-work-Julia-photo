﻿// <auto-generated />
using System;
using JuliaPhotoServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JuliaPhotoServer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230704124609_CreateAboutTable")]
    partial class CreateAboutTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JuliaPhotoServer.Models.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhotoSetId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoSetId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.PhotoSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PhotoSetTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoSetTypeId");

                    b.ToTable("PhotoSets");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.PhotoSetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhotoSetTypes");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.About", b =>
                {
                    b.HasOne("JuliaPhotoServer.Models.Photo", "Photo")
                        .WithMany()
                        .HasForeignKey("PhotoId");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.Photo", b =>
                {
                    b.HasOne("JuliaPhotoServer.Models.PhotoSet", "PhotoSet")
                        .WithMany("Photos")
                        .HasForeignKey("PhotoSetId");

                    b.Navigation("PhotoSet");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.PhotoSet", b =>
                {
                    b.HasOne("JuliaPhotoServer.Models.PhotoSetType", "PhotoSetType")
                        .WithMany("PhotoSets")
                        .HasForeignKey("PhotoSetTypeId");

                    b.Navigation("PhotoSetType");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.PhotoSet", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("JuliaPhotoServer.Models.PhotoSetType", b =>
                {
                    b.Navigation("PhotoSets");
                });
#pragma warning restore 612, 618
        }
    }
}
