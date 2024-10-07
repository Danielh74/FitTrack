using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89f90131-f854-4473-9184-f050b59bb8ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8dd0af2-00e3-4f6d-992c-9de208211e82");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Weight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weight_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "784aff2a-8e53-4eaa-96b7-d0946276e6dd", "8cb99d5d-240d-4d95-a2e9-af0192d15c05", "Admin", "ADMIN" },
                    { "95e0238b-608a-4387-819a-0da8632c7c07", "4396576c-f749-4915-8bd5-b1befa97d600", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weight_AppUserId",
                table: "Weight",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weight");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "784aff2a-8e53-4eaa-96b7-d0946276e6dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95e0238b-608a-4387-819a-0da8632c7c07");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89f90131-f854-4473-9184-f050b59bb8ad", "27a9bf54-8fb8-4e24-8a82-ef43014017bc", "Admin", "ADMIN" },
                    { "a8dd0af2-00e3-4f6d-992c-9de208211e82", "300e21a9-791d-48e4-b0fa-bba7122df150", "User", "USER" }
                });
        }
    }
}
