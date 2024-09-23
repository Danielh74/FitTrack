using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBehaviorAgain : Migration
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
                keyValue: "ebb6b5ea-0b7f-42c2-9bc1-7d0b9e613244");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3a27608-3e24-4387-a84a-3197085d4727");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ef8c2be-cc5f-48ae-8025-303823868456", "6ca2d3b2-dd26-48bb-aaee-f274ee28926a", "User", "USER" },
                    { "bbb196e6-120a-4da7-9bcd-0495e248cdad", "5b295c21-f1f2-4cac-9001-b1e1d34319a0", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HealthDeclarations_HealthDeclarationId",
                table: "AspNetUsers",
                column: "HealthDeclarationId",
                principalTable: "HealthDeclarations",
                principalColumn: "Id");
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
                keyValue: "5ef8c2be-cc5f-48ae-8025-303823868456");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbb196e6-120a-4da7-9bcd-0495e248cdad");

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
    }
}
