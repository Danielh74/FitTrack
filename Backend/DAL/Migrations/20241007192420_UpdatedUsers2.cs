using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "784aff2a-8e53-4eaa-96b7-d0946276e6dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95e0238b-608a-4387-819a-0da8632c7c07");

            migrationBuilder.AlterColumn<string>(
                name: "TimeStamp",
                table: "Weight",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eb03bdf-397b-49c2-8f3c-95d3204313b3", "2766d4b7-37ff-49a3-bbd4-21c3810d8aad", "User", "USER" },
                    { "98eb412d-9c9b-4a4d-bf5b-ba3451765294", "4b6f1b8a-a2a8-49ea-b5c7-2593735be0f2", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eb03bdf-397b-49c2-8f3c-95d3204313b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98eb412d-9c9b-4a4d-bf5b-ba3451765294");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Weight",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "784aff2a-8e53-4eaa-96b7-d0946276e6dd", "8cb99d5d-240d-4d95-a2e9-af0192d15c05", "Admin", "ADMIN" },
                    { "95e0238b-608a-4387-819a-0da8632c7c07", "4396576c-f749-4915-8bd5-b1befa97d600", "User", "USER" }
                });
        }
    }
}
