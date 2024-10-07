using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AspNetUsers_AppUserId",
                table: "Plans");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5a9a6be-74d8-46b7-92f9-8f90c934b992");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6c53209-dcf6-4ff3-b714-cc228a9bdf17");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Plans",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Plans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MuscleGroups",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89f90131-f854-4473-9184-f050b59bb8ad", "27a9bf54-8fb8-4e24-8a82-ef43014017bc", "Admin", "ADMIN" },
                    { "a8dd0af2-00e3-4f6d-992c-9de208211e82", "300e21a9-791d-48e4-b0fa-bba7122df150", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AspNetUsers_AppUserId",
                table: "Plans",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_AspNetUsers_AppUserId",
                table: "Plans");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89f90131-f854-4473-9184-f050b59bb8ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8dd0af2-00e3-4f6d-992c-9de208211e82");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Plans");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlansDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Plans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MuscleGroups",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d5a9a6be-74d8-46b7-92f9-8f90c934b992", "e73769ea-3cac-4342-9cb8-a4724fb87f8f", "User", "USER" },
                    { "f6c53209-dcf6-4ff3-b714-cc228a9bdf17", "bf1a3f84-849b-485c-942b-9cffa27d35bd", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_AspNetUsers_AppUserId",
                table: "Plans",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
