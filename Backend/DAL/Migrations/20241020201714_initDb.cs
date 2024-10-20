using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthDeclarations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeartDisease = table.Column<bool>(type: "bit", nullable: false),
                    ChestPainInRest = table.Column<bool>(type: "bit", nullable: false),
                    ChestPainInDaily = table.Column<bool>(type: "bit", nullable: false),
                    ChestPainInActivity = table.Column<bool>(type: "bit", nullable: false),
                    Dizzy = table.Column<bool>(type: "bit", nullable: false),
                    LostConsciousness = table.Column<bool>(type: "bit", nullable: false),
                    AsthmaTreatment = table.Column<bool>(type: "bit", nullable: false),
                    ShortBreath = table.Column<bool>(type: "bit", nullable: false),
                    FamilyDeathHeartDisease = table.Column<bool>(type: "bit", nullable: false),
                    FamilySuddenEarlyAgeDeath = table.Column<bool>(type: "bit", nullable: false),
                    TrainUnderSupervision = table.Column<bool>(type: "bit", nullable: false),
                    ChronicIllness = table.Column<bool>(type: "bit", nullable: false),
                    IsPregnant = table.Column<bool>(type: "bit", nullable: false),
                    DateOfSignature = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthDeclarations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    NeckCircumference = table.Column<double>(type: "float", nullable: false),
                    PecsCircumference = table.Column<double>(type: "float", nullable: false),
                    WaistCircumference = table.Column<double>(type: "float", nullable: false),
                    AbdominalCircumference = table.Column<double>(type: "float", nullable: false),
                    HipsCircumference = table.Column<double>(type: "float", nullable: false),
                    ThighsCircumference = table.Column<double>(type: "float", nullable: false),
                    ArmCircumference = table.Column<double>(type: "float", nullable: false),
                    BodyFatPrecentage = table.Column<double>(type: "float", nullable: false),
                    AgreedToTerms = table.Column<bool>(type: "bit", nullable: false),
                    HealthDeclarationId = table.Column<int>(type: "int", nullable: true),
                    MenuId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_HealthDeclarations_HealthDeclarationId",
                        column: x => x.HealthDeclarationId,
                        principalTable: "HealthDeclarations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ProteinPoints = table.Column<int>(type: "int", nullable: false),
                    CarbsPoints = table.Column<int>(type: "int", nullable: false),
                    FatsPoints = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PlansDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    OrderInPlan = table.Column<int>(type: "int", nullable: false),
                    CurrentWeight = table.Column<double>(type: "float", nullable: true),
                    PreviousWeight = table.Column<double>(type: "float", nullable: true),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlansDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlansDetails_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlansDetails_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "ed3c2fe3-eeee-4fc2-a631-87833bbc8173", "Admin", "ADMIN" },
                    { 2, "875d2510-f59e-4a78-8341-ff0dc7f76974", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AbdominalCircumference", "AccessFailedCount", "Age", "AgreedToTerms", "ArmCircumference", "BodyFatPrecentage", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "Goal", "HealthDeclarationId", "Height", "HipsCircumference", "LastName", "LockoutEnabled", "LockoutEnd", "MenuId", "NeckCircumference", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PecsCircumference", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ThighsCircumference", "TwoFactorEnabled", "UserName", "WaistCircumference" },
                values: new object[,]
                {
                    { 1, 0.0, 0, 0, false, 0.0, 0.0, "", "147f9546-3a81-4420-a084-c337672fd390", "a@gmail.com", false, "Avner", "", "", null, 0, 0.0, "Hazan", false, null, null, 0.0, "A@GMAIL.COM", "A@GMAIL.COM", "AQAAAAIAAYagAAAAEMexqKO+WTrXsdh6uVSUO8HSEd9MhkhS/TD1oHcJ2kgj/uPgFYhDDowsMp1orB9png==", 0.0, null, false, "87d23c3b-d911-44c0-9d80-ae291a217166", 0.0, false, "a@gmail.com", 0.0 },
                    { 2, 0.0, 0, 0, false, 0.0, 0.0, "", "5f78c918-55d8-4853-bc0a-2caf4285a448", "d@gmail.com", false, "Daniel", "", "", null, 0, 0.0, "Hazan", false, null, null, 0.0, "D@GMAIL.COM", "D@GMAIL.COM", "AQAAAAIAAYagAAAAEHRpCzchIxjLgflzSfWSx30pyehgX7xUL1Xa7lpG9hW0mSBA5lEAt4l20N3KRiKRDA==", 0.0, null, false, "0f6042b6-27f3-40bb-a2ce-93800773f2bf", 0.0, false, "d@gmail.com", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "MuscleGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chest" },
                    { 2, "Back" },
                    { 3, "Biceps" },
                    { 4, "Triceps" },
                    { 5, "Abs" },
                    { 6, "Shoulders" },
                    { 7, "Legs" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "MuscleGroupId", "Name" },
                values: new object[,]
                {
                    { 1, 7, "Leg curls" },
                    { 2, 1, "Bench press" },
                    { 3, 3, "Hammer curls" },
                    { 4, 4, "Skull Crushers" },
                    { 5, 6, "Arnold press" },
                    { 6, 5, "Plank" },
                    { 7, 2, "Pull-down" }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id", "AppUserId", "IsCompleted", "Name" },
                values: new object[,]
                {
                    { 1, 2, false, "Push" },
                    { 2, 2, false, "Pull" }
                });

            migrationBuilder.InsertData(
                table: "PlansDetails",
                columns: new[] { "Id", "CurrentWeight", "ExerciseId", "OrderInPlan", "PlanId", "PreviousWeight", "Reps", "Sets" },
                values: new object[,]
                {
                    { 1, 15.0, 2, 1, 1, 12.5, 12, 4 },
                    { 2, null, 5, 2, 1, null, 10, 4 },
                    { 3, null, 3, 1, 2, null, 10, 4 },
                    { 4, null, 7, 2, 2, null, 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HealthDeclarationId",
                table: "AspNetUsers",
                column: "HealthDeclarationId",
                unique: true,
                filter: "[HealthDeclarationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MenuId",
                table: "AspNetUsers",
                column: "MenuId",
                unique: true,
                filter: "[MenuId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MuscleGroupId",
                table: "Exercises",
                column: "MuscleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuId",
                table: "Meals",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_AppUserId",
                table: "Plans",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlansDetails_ExerciseId",
                table: "PlansDetails",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlansDetails_PlanId",
                table: "PlansDetails",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_AppUserId",
                table: "Weight",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "PlansDetails");

            migrationBuilder.DropTable(
                name: "Weight");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HealthDeclarations");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
