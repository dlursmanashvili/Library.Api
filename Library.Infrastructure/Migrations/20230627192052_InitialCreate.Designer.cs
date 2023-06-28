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
    [Migration("20230627192052_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Author", b =>
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

            modelBuilder.Entity("Library.Models.Book", b =>
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

            modelBuilder.Entity("Library.Models.BookAuthor", b =>
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

            modelBuilder.Entity("Library.Models.Employee.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            IsDeleted = false,
                            PasswordHash = new byte[] { 194, 47, 22, 218, 138, 219, 213, 220, 202, 243, 237, 5, 76, 154, 212, 190, 30, 122, 183, 43, 240, 229, 229, 76, 129, 15, 134, 53, 112, 234, 224, 196, 28, 115, 4, 241, 199, 7, 61, 193, 143, 7, 0, 142, 24, 143, 0, 191, 124, 223, 156, 195, 186, 47, 15, 184, 224, 111, 136, 226, 205, 154, 123, 17 },
                            PasswordSalt = new byte[] { 18, 125, 80, 218, 6, 19, 214, 50, 14, 89, 5, 163, 23, 230, 202, 10, 204, 32, 21, 90, 92, 244, 126, 197, 207, 213, 223, 57, 166, 66, 172, 140, 50, 54, 29, 43, 103, 98, 234, 170, 233, 47, 138, 123, 132, 69, 135, 203, 206, 194, 43, 236, 87, 110, 221, 83, 237, 253, 224, 115, 156, 129, 235, 93, 78, 53, 40, 207, 20, 206, 187, 64, 118, 101, 121, 138, 240, 191, 177, 90, 136, 166, 212, 97, 97, 209, 155, 78, 184, 226, 6, 105, 150, 254, 32, 203, 179, 16, 58, 195, 131, 249, 137, 187, 245, 155, 42, 67, 132, 75, 13, 137, 208, 183, 57, 106, 254, 201, 129, 228, 187, 135, 185, 193, 198, 105, 233, 94 }
                        });
                });

            modelBuilder.Entity("Library.Models.BookAuthor", b =>
                {
                    b.HasOne("Library.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });
#pragma warning restore 612, 618
        }
    }
}
