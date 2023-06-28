﻿// <auto-generated />
using System;
using Library.Infrastructure.DataBaseHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230628192803_addPropertyIsAdministrator")]
    partial class addPropertyIsAdministrator
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Models.Authors.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Models.Models.BookAuthors.BookAuthor", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("Library.Models.Models.Books.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InLibrary")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.Models.Employee.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdministrator")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                            Email = "SuperAdmin@gmail.com",
                            IsAdministrator = true,
                            IsDeleted = false,
                            PasswordHash = new byte[] { 143, 95, 167, 102, 120, 163, 80, 103, 2, 35, 108, 214, 211, 75, 8, 244, 67, 119, 155, 116, 24, 161, 154, 217, 74, 195, 16, 1, 4, 70, 176, 61, 8, 130, 155, 1, 194, 95, 163, 121, 0, 36, 44, 219, 27, 229, 180, 20, 129, 54, 11, 218, 249, 132, 141, 206, 245, 243, 110, 148, 208, 122, 47, 65 },
                            PasswordSalt = new byte[] { 210, 93, 60, 101, 170, 74, 214, 95, 151, 89, 142, 191, 151, 124, 95, 116, 129, 156, 105, 108, 3, 88, 140, 192, 186, 120, 78, 154, 117, 88, 186, 98, 192, 141, 29, 248, 131, 126, 246, 181, 115, 7, 67, 31, 227, 130, 188, 41, 23, 94, 79, 99, 70, 174, 142, 65, 34, 87, 253, 210, 185, 229, 138, 191, 4, 250, 229, 191, 175, 241, 176, 252, 138, 30, 172, 140, 38, 202, 192, 228, 40, 155, 104, 113, 14, 241, 251, 84, 112, 33, 109, 87, 247, 163, 79, 249, 82, 83, 220, 217, 237, 194, 51, 63, 88, 57, 17, 171, 240, 195, 19, 131, 19, 195, 220, 252, 36, 222, 158, 171, 68, 84, 159, 73, 125, 80, 241, 168 }
                        });
                });

            modelBuilder.Entity("Library.Models.Models.BookAuthors.BookAuthor", b =>
                {
                    b.HasOne("Library.Models.Models.Authors.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Models.Books.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.Models.Models.Authors.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Library.Models.Models.Books.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });
#pragma warning restore 612, 618
        }
    }
}