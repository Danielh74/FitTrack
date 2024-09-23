using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HealthDeclarations_HealthDeclarationId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4722c66c-8714-482c-85ce-db25160a584f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b8992a2-df08-414a-a821-3ad548505040");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ebb6b5ea-0b7f-42c2-9bc1-7d0b9e613244", "3bf75a27-869d-411d-94ad-4599e3de86fd", "Admin", "ADMIN" },
                    { "f3a27608-3e24-4387-a84a-3197085d4727", "660b3238-ea6c-4d70-a7dd-34b052682629", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HealthDeclarations_HealthDeclarationId",
                table: "AspNetUsers",
                column: "HealthDeclarationId",
                principalTable: "HealthDeclarations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HealthDeclarations_HealthDeclarationId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebb6b5ea-0b7f-42c2-9bc1-7d0b9e613244");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3a27608-3e24-4387-a84a-3197085d4727");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4722c66c-8714-482c-85ce-db25160a584f", "245b8763-d7ab-4ab8-9738-2f66e77b3bcc", "User", "USER" },
                    { "8b8992a2-df08-414a-a821-3ad548505040", "c6b3e05a-8d63-4f9e-8ca3-09b8a28fb82a", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HealthDeclarations_HealthDeclarationId",
                table: "AspNetUsers",
                column: "HealthDeclarationId",
                principalTable: "HealthDeclarations",
                principalColumn: "Id");
        }
    }
}
