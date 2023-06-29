using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changebookproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Books",
                newName: "FilePath");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 46, 231, 224, 97, 151, 98, 26, 238, 125, 39, 111, 171, 54, 172, 109, 20, 15, 37, 65, 67, 61, 102, 67, 225, 213, 87, 215, 107, 90, 204, 114, 125, 253, 90, 8, 207, 83, 55, 211, 176, 123, 165, 86, 243, 137, 172, 247, 196, 10, 244, 139, 33, 55, 117, 197, 238, 155, 190, 12, 41, 191, 95, 154, 127 }, new byte[] { 244, 241, 52, 3, 18, 183, 183, 128, 242, 231, 239, 159, 26, 130, 162, 145, 203, 29, 118, 20, 46, 113, 128, 201, 206, 135, 153, 83, 19, 47, 62, 170, 214, 41, 71, 207, 126, 219, 240, 104, 176, 208, 79, 134, 179, 189, 165, 53, 248, 60, 158, 208, 224, 60, 86, 48, 112, 97, 132, 152, 66, 178, 76, 81, 130, 201, 18, 214, 51, 138, 165, 131, 125, 137, 200, 125, 52, 240, 157, 57, 175, 70, 208, 36, 144, 19, 165, 115, 136, 242, 126, 36, 101, 201, 66, 231, 243, 243, 0, 5, 53, 177, 112, 113, 255, 3, 251, 10, 226, 57, 129, 9, 69, 105, 186, 137, 25, 192, 104, 129, 243, 13, 72, 142, 101, 235, 53, 114 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Books",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 143, 95, 167, 102, 120, 163, 80, 103, 2, 35, 108, 214, 211, 75, 8, 244, 67, 119, 155, 116, 24, 161, 154, 217, 74, 195, 16, 1, 4, 70, 176, 61, 8, 130, 155, 1, 194, 95, 163, 121, 0, 36, 44, 219, 27, 229, 180, 20, 129, 54, 11, 218, 249, 132, 141, 206, 245, 243, 110, 148, 208, 122, 47, 65 }, new byte[] { 210, 93, 60, 101, 170, 74, 214, 95, 151, 89, 142, 191, 151, 124, 95, 116, 129, 156, 105, 108, 3, 88, 140, 192, 186, 120, 78, 154, 117, 88, 186, 98, 192, 141, 29, 248, 131, 126, 246, 181, 115, 7, 67, 31, 227, 130, 188, 41, 23, 94, 79, 99, 70, 174, 142, 65, 34, 87, 253, 210, 185, 229, 138, 191, 4, 250, 229, 191, 175, 241, 176, 252, 138, 30, 172, 140, 38, 202, 192, 228, 40, 155, 104, 113, 14, 241, 251, 84, 112, 33, 109, 87, 247, 163, 79, 249, 82, 83, 220, 217, 237, 194, 51, 63, 88, 57, 17, 171, 240, 195, 19, 131, 19, 195, 220, 252, 36, 222, 158, 171, 68, 84, 159, 73, 125, 80, 241, 168 } });
        }
    }
}
