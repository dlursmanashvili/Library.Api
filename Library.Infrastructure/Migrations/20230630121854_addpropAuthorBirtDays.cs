using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpropAuthorBirtDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 102, 115, 93, 246, 150, 127, 242, 184, 139, 30, 103, 190, 101, 164, 174, 246, 7, 228, 47, 7, 156, 72, 50, 63, 105, 231, 3, 46, 102, 135, 157, 125, 95, 217, 93, 53, 136, 57, 213, 209, 234, 58, 7, 196, 144, 189, 207, 128, 238, 182, 223, 235, 0, 201, 200, 133, 50, 165, 2, 216, 54, 109, 44, 170 }, new byte[] { 43, 248, 197, 215, 58, 201, 236, 190, 39, 68, 53, 25, 61, 18, 205, 98, 225, 92, 156, 10, 49, 161, 213, 50, 192, 141, 20, 175, 231, 66, 181, 83, 224, 48, 91, 218, 115, 111, 143, 69, 242, 228, 157, 0, 6, 130, 152, 206, 112, 56, 78, 83, 15, 170, 13, 66, 163, 96, 227, 185, 83, 208, 207, 201, 37, 138, 14, 147, 252, 76, 125, 57, 245, 231, 246, 23, 187, 233, 108, 33, 175, 67, 96, 83, 165, 139, 236, 255, 92, 106, 129, 192, 155, 78, 89, 27, 89, 106, 139, 24, 218, 110, 205, 0, 96, 26, 231, 64, 108, 106, 170, 31, 18, 163, 164, 160, 84, 179, 85, 217, 136, 9, 75, 22, 255, 47, 48, 46 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 231, 224, 97, 151, 98, 26, 238, 125, 39, 111, 171, 54, 172, 109, 20, 15, 37, 65, 67, 61, 102, 67, 225, 213, 87, 215, 107, 90, 204, 114, 125, 253, 90, 8, 207, 83, 55, 211, 176, 123, 165, 86, 243, 137, 172, 247, 196, 10, 244, 139, 33, 55, 117, 197, 238, 155, 190, 12, 41, 191, 95, 154, 127 }, new byte[] { 244, 241, 52, 3, 18, 183, 183, 128, 242, 231, 239, 159, 26, 130, 162, 145, 203, 29, 118, 20, 46, 113, 128, 201, 206, 135, 153, 83, 19, 47, 62, 170, 214, 41, 71, 207, 126, 219, 240, 104, 176, 208, 79, 134, 179, 189, 165, 53, 248, 60, 158, 208, 224, 60, 86, 48, 112, 97, 132, 152, 66, 178, 76, 81, 130, 201, 18, 214, 51, 138, 165, 131, 125, 137, 200, 125, 52, 240, 157, 57, 175, 70, 208, 36, 144, 19, 165, 115, 136, 242, 126, 36, 101, 201, 66, 231, 243, 243, 0, 5, 53, 177, 112, 113, 255, 3, 251, 10, 226, 57, 129, 9, 69, 105, 186, 137, 25, 192, 104, 129, 243, 13, 72, 142, 101, 235, 53, 114 } });
        }
    }
}
