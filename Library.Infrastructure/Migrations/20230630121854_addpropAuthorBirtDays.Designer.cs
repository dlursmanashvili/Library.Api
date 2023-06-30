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
    [Migration("20230630121854_addpropAuthorBirtDays")]
    partial class addpropAuthorBirtDays
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

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

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

                    b.Property<string>("FilePath")
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
                            PasswordHash = new byte[] { 102, 115, 93, 246, 150, 127, 242, 184, 139, 30, 103, 190, 101, 164, 174, 246, 7, 228, 47, 7, 156, 72, 50, 63, 105, 231, 3, 46, 102, 135, 157, 125, 95, 217, 93, 53, 136, 57, 213, 209, 234, 58, 7, 196, 144, 189, 207, 128, 238, 182, 223, 235, 0, 201, 200, 133, 50, 165, 2, 216, 54, 109, 44, 170 },
                            PasswordSalt = new byte[] { 43, 248, 197, 215, 58, 201, 236, 190, 39, 68, 53, 25, 61, 18, 205, 98, 225, 92, 156, 10, 49, 161, 213, 50, 192, 141, 20, 175, 231, 66, 181, 83, 224, 48, 91, 218, 115, 111, 143, 69, 242, 228, 157, 0, 6, 130, 152, 206, 112, 56, 78, 83, 15, 170, 13, 66, 163, 96, 227, 185, 83, 208, 207, 201, 37, 138, 14, 147, 252, 76, 125, 57, 245, 231, 246, 23, 187, 233, 108, 33, 175, 67, 96, 83, 165, 139, 236, 255, 92, 106, 129, 192, 155, 78, 89, 27, 89, 106, 139, 24, 218, 110, 205, 0, 96, 26, 231, 64, 108, 106, 170, 31, 18, 163, 164, 160, 84, 179, 85, 217, 136, 9, 75, 22, 255, 47, 48, 46 }
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
