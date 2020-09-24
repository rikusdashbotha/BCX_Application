using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class UpdatedTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskAssigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTS = table.Column<DateTime>(nullable: false),
                    UpdatedTS = table.Column<DateTime>(nullable: false),
                    CANCELLED = table.Column<bool>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    HoursLogged = table.Column<double>(nullable: false),
                    AtCurrentRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTS = table.Column<DateTime>(nullable: false),
                    UpdatedTS = table.Column<DateTime>(nullable: false),
                    CANCELLED = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Duration = table.Column<double>(nullable: false),
                    TaskAssignId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskAssigns_TaskAssignId",
                        column: x => x.TaskAssignId,
                        principalTable: "TaskAssigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskAssignId",
                table: "Tasks",
                column: "TaskAssignId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskAssigns");
        }
    }
}
