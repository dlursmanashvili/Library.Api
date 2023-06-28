using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyIsAdministrator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdministrator",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "IsAdministrator", "PasswordHash", "PasswordSalt" },
                values: new object[] { true, new byte[] { 143, 95, 167, 102, 120, 163, 80, 103, 2, 35, 108, 214, 211, 75, 8, 244, 67, 119, 155, 116, 24, 161, 154, 217, 74, 195, 16, 1, 4, 70, 176, 61, 8, 130, 155, 1, 194, 95, 163, 121, 0, 36, 44, 219, 27, 229, 180, 20, 129, 54, 11, 218, 249, 132, 141, 206, 245, 243, 110, 148, 208, 122, 47, 65 }, new byte[] { 210, 93, 60, 101, 170, 74, 214, 95, 151, 89, 142, 191, 151, 124, 95, 116, 129, 156, 105, 108, 3, 88, 140, 192, 186, 120, 78, 154, 117, 88, 186, 98, 192, 141, 29, 248, 131, 126, 246, 181, 115, 7, 67, 31, 227, 130, 188, 41, 23, 94, 79, 99, 70, 174, 142, 65, 34, 87, 253, 210, 185, 229, 138, 191, 4, 250, 229, 191, 175, 241, 176, 252, 138, 30, 172, 140, 38, 202, 192, 228, 40, 155, 104, 113, 14, 241, 251, 84, 112, 33, 109, 87, 247, 163, 79, 249, 82, 83, 220, 217, 237, 194, 51, 63, 88, 57, 17, 171, 240, 195, 19, 131, 19, 195, 220, 252, 36, 222, 158, 171, 68, 84, 159, 73, 125, 80, 241, 168 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdministrator",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 47, 22, 218, 138, 219, 213, 220, 202, 243, 237, 5, 76, 154, 212, 190, 30, 122, 183, 43, 240, 229, 229, 76, 129, 15, 134, 53, 112, 234, 224, 196, 28, 115, 4, 241, 199, 7, 61, 193, 143, 7, 0, 142, 24, 143, 0, 191, 124, 223, 156, 195, 186, 47, 15, 184, 224, 111, 136, 226, 205, 154, 123, 17 }, new byte[] { 18, 125, 80, 218, 6, 19, 214, 50, 14, 89, 5, 163, 23, 230, 202, 10, 204, 32, 21, 90, 92, 244, 126, 197, 207, 213, 223, 57, 166, 66, 172, 140, 50, 54, 29, 43, 103, 98, 234, 170, 233, 47, 138, 123, 132, 69, 135, 203, 206, 194, 43, 236, 87, 110, 221, 83, 237, 253, 224, 115, 156, 129, 235, 93, 78, 53, 40, 207, 20, 206, 187, 64, 118, 101, 121, 138, 240, 191, 177, 90, 136, 166, 212, 97, 97, 209, 155, 78, 184, 226, 6, 105, 150, 254, 32, 203, 179, 16, 58, 195, 131, 249, 137, 187, 245, 155, 42, 67, 132, 75, 13, 137, 208, 183, 57, 106, 254, 201, 129, 228, 187, 135, 185, 193, 198, 105, 233, 94 } });
        }
    }
}
