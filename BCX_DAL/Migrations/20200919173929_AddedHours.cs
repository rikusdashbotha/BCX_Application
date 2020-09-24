using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class AddedHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursLogged",
                table: "TaskAssigns");

            migrationBuilder.CreateTable(
                name: "Hours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTS = table.Column<DateTime>(nullable: false),
                    UpdatedTS = table.Column<DateTime>(nullable: false),
                    CANCELLED = table.Column<bool>(nullable: false),
                    TaskAssignId = table.Column<int>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    RoleRateAtTime = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hours_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Hours_TaskAssigns_TaskAssignId",
                        column: x => x.TaskAssignId,
                        principalTable: "TaskAssigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hours_RoleId",
                table: "Hours",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hours_TaskAssignId",
                table: "Hours",
                column: "TaskAssignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hours");

            migrationBuilder.AddColumn<double>(
                name: "HoursLogged",
                table: "TaskAssigns",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
