using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class check3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 175, 135, 147, 69, 199, 54, 222, 16, 1, 188, 226, 241, 157, 242, 40, 200, 60, 68, 82, 86, 166, 190, 102, 121, 145, 92, 138, 199, 116, 173, 55, 43, 207, 179, 190, 185, 98, 63, 157, 219, 54, 105, 43, 214, 60, 192, 81, 44, 58, 230, 124, 68, 8, 203, 141, 28, 193, 238, 46, 211, 53, 59, 161, 21 }, new byte[] { 33, 160, 84, 176, 66, 61, 120, 117, 230, 105, 244, 148, 47, 170, 71, 68, 92, 195, 172, 192, 183, 217, 98, 112, 109, 206, 65, 62, 213, 237, 208, 24, 81, 3, 183, 60, 202, 11, 248, 241, 12, 186, 103, 3, 24, 64, 180, 42, 246, 11, 72, 50, 197, 140, 162, 163, 48, 197, 27, 253, 33, 235, 233, 158, 86, 6, 64, 69, 251, 120, 208, 12, 104, 7, 17, 113, 122, 193, 75, 56, 117, 94, 111, 248, 116, 123, 12, 224, 42, 65, 2, 73, 48, 166, 252, 112, 140, 189, 73, 3, 250, 51, 36, 184, 96, 44, 233, 31, 217, 255, 201, 156, 110, 222, 135, 23, 134, 254, 9, 160, 84, 209, 169, 230, 173, 181, 202, 73 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 102, 115, 93, 246, 150, 127, 242, 184, 139, 30, 103, 190, 101, 164, 174, 246, 7, 228, 47, 7, 156, 72, 50, 63, 105, 231, 3, 46, 102, 135, 157, 125, 95, 217, 93, 53, 136, 57, 213, 209, 234, 58, 7, 196, 144, 189, 207, 128, 238, 182, 223, 235, 0, 201, 200, 133, 50, 165, 2, 216, 54, 109, 44, 170 }, new byte[] { 43, 248, 197, 215, 58, 201, 236, 190, 39, 68, 53, 25, 61, 18, 205, 98, 225, 92, 156, 10, 49, 161, 213, 50, 192, 141, 20, 175, 231, 66, 181, 83, 224, 48, 91, 218, 115, 111, 143, 69, 242, 228, 157, 0, 6, 130, 152, 206, 112, 56, 78, 83, 15, 170, 13, 66, 163, 96, 227, 185, 83, 208, 207, 201, 37, 138, 14, 147, 252, 76, 125, 57, 245, 231, 246, 23, 187, 233, 108, 33, 175, 67, 96, 83, 165, 139, 236, 255, 92, 106, 129, 192, 155, 78, 89, 27, 89, 106, 139, 24, 218, 110, 205, 0, 96, 26, 231, 64, 108, 106, 170, 31, 18, 163, 164, 160, 84, 179, 85, 217, 136, 9, 75, 22, 255, 47, 48, 46 } });
        }
    }
}
