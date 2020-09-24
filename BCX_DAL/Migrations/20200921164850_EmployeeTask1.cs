using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class EmployeeTask1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssigns_Employees_EmployeeId",
                table: "TaskAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssigns_Tasks_TaskId",
                table: "TaskAssigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskAssigns_TaskAssignId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskAssignId1",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskAssigns_EmployeeId",
                table: "TaskAssigns");

            migrationBuilder.DropColumn(
                name: "TaskAssignId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskAssignId1",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskAssignId",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTS = table.Column<DateTime>(nullable: false),
                    UpdatedTS = table.Column<DateTime>(nullable: false),
                    CANCELLED = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TaskAssignId",
                table: "Employees",
                column: "TaskAssignId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_EmployeeId",
                table: "EmployeeTask",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_TaskId",
                table: "EmployeeTask",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TaskAssigns_TaskAssignId",
                table: "Employees",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssigns_Tasks_TaskId",
                table: "TaskAssigns",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TaskAssigns_TaskAssignId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssigns_Tasks_TaskId",
                table: "TaskAssigns");

            migrationBuilder.DropTable(
                name: "EmployeeTask");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TaskAssignId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TaskAssignId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "TaskAssignId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskAssignId1",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskAssignId1",
                table: "Tasks",
                column: "TaskAssignId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssigns_EmployeeId",
                table: "TaskAssigns",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssigns_Employees_EmployeeId",
                table: "TaskAssigns",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskAssigns_Tasks_TaskId",
                table: "TaskAssigns",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskAssigns_TaskAssignId1",
                table: "Tasks",
                column: "TaskAssignId1",
                principalTable: "TaskAssigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
