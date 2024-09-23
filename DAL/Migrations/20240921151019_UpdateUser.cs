using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c89246a-e0eb-49bc-ab07-371656c79660");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7b844ac-4143-4eff-b3ad-f05561ba14f3");

            migrationBuilder.DropColumn(
                name: "StomachCircumference",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "WaistCircumference",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "ThighsCircumference",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "PecsCircumference",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "NeckCircumference",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "HipsCircumference",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "BodyFatPrecentage",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "ArmCircumference",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<double>(
                name: "AbdominalCircumference",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4722c66c-8714-482c-85ce-db25160a584f", "245b8763-d7ab-4ab8-9738-2f66e77b3bcc", "User", "USER" },
                    { "8b8992a2-df08-414a-a821-3ad548505040", "c6b3e05a-8d63-4f9e-8ca3-09b8a28fb82a", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4722c66c-8714-482c-85ce-db25160a584f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b8992a2-df08-414a-a821-3ad548505040");

            migrationBuilder.DropColumn(
                name: "AbdominalCircumference",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "WaistCircumference",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "ThighsCircumference",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "PecsCircumference",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "NeckCircumference",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "HipsCircumference",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "BodyFatPrecentage",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "ArmCircumference",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<float>(
                name: "StomachCircumference",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c89246a-e0eb-49bc-ab07-371656c79660", "8344fdb7-0684-4a55-b2b5-77c2692175d7", "User", "USER" },
                    { "b7b844ac-4143-4eff-b3ad-f05561ba14f3", "c6f0f8c3-b8fb-43cf-b16f-017dd3886b3f", "Admin", "ADMIN" }
                });
        }
    }
}
