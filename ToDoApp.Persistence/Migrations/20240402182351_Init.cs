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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Categories", x => x.Id);
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                });

            migrationBuilder.InsertData(
                table: "T_Categories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { 1, new DateTime(2024, 4, 2, 21, 53, 49, 700, DateTimeKind.Local).AddTicks(1102), new DateTime(2024, 4, 2, 21, 53, 49, 700, DateTimeKind.Local).AddTicks(1116), "Category", "Sleep" });

            migrationBuilder.InsertData(
                table: "T_UserTasks",
                columns: new[] { "Id", "CategoryId", "DateCreated", "DateModified", "Description", "DueDate", "IsCompleted", "Title" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 2, 18, 23, 49, 700, DateTimeKind.Utc).AddTicks(3927), new DateTime(2024, 4, 2, 18, 23, 49, 700, DateTimeKind.Utc).AddTicks(3924), "Description", new DateTime(2024, 4, 2, 18, 23, 49, 700, DateTimeKind.Utc).AddTicks(3925), true, "Title" });

            migrationBuilder.CreateIndex(
                name: "IX_T_UserTasks_CategoryId",
                table: "T_UserTasks",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_UserTasks");

            migrationBuilder.DropTable(
                name: "T_Categories");
        }
    }
}
