using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class FixedHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_EmployeeTasks_EmployeeTaskId",
                table: "Hours");

            migrationBuilder.DropIndex(
                name: "IX_Hours_EmployeeTaskId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "EmployeeTaskId",
                table: "Hours");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Hours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Hours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hours_EmployeeId",
                table: "Hours",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_Employees_EmployeeId",
                table: "Hours",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_Employees_EmployeeId",
                table: "Hours");

            migrationBuilder.DropIndex(
                name: "IX_Hours_EmployeeId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Hours");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTaskId",
                table: "Hours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hours_EmployeeTaskId",
                table: "Hours",
                column: "EmployeeTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_EmployeeTasks_EmployeeTaskId",
                table: "Hours",
                column: "EmployeeTaskId",
                principalTable: "EmployeeTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
