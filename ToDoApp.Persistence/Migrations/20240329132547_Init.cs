using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_UserTasks_T_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "T_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_UserTasks_T_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "T_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "T_Categories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { 1, new DateTime(2024, 3, 29, 16, 55, 46, 775, DateTimeKind.Local).AddTicks(5278), new DateTime(2024, 3, 29, 16, 55, 46, 775, DateTimeKind.Local).AddTicks(5288), "Category", "Sleep" });

            migrationBuilder.InsertData(
                table: "T_Users",
                columns: new[] { "Id", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { 1, new DateTime(2024, 3, 29, 16, 55, 46, 775, DateTimeKind.Local).AddTicks(8120), new DateTime(2024, 3, 29, 16, 55, 46, 775, DateTimeKind.Local).AddTicks(8122), "user@user.com", "John", "Doe", "112233" });

            migrationBuilder.InsertData(
                table: "T_UserTasks",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "DueDate", "IsCompleted", "Title", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 3, 29, 13, 25, 46, 776, DateTimeKind.Utc).AddTicks(306), new DateTime(2024, 3, 29, 13, 25, 46, 776, DateTimeKind.Utc).AddTicks(303), "Description", new DateTime(2024, 3, 29, 13, 25, 46, 776, DateTimeKind.Utc).AddTicks(304), true, "Title", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_T_UserTasks_CategoryId",
                table: "T_UserTasks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_T_UserTasks_UserId",
                table: "T_UserTasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_UserTasks");

            migrationBuilder.DropTable(
                name: "T_Categories");

            migrationBuilder.DropTable(
                name: "T_Users");
        }
    }
}
