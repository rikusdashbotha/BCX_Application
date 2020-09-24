using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class AddedHours2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_Roles_RoleId",
                table: "Hours");

            migrationBuilder.DropForeignKey(
                name: "FK_Hours_TaskAssigns_TaskAssignId",
                table: "Hours");

            migrationBuilder.DropIndex(
                name: "IX_Hours_RoleId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Hours");

            migrationBuilder.AddColumn<int>(
                name: "HourId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaskAssignId",
                table: "Hours",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTaskId",
                table: "Hours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "HoursWorked",
                table: "Hours",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_HourId",
                table: "Roles",
                column: "HourId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_TaskAssigns_TaskAssignId",
                table: "Hours",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Hours_HourId",
                table: "Roles",
                column: "HourId",
                principalTable: "Hours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_EmployeeTasks_EmployeeTaskId",
                table: "Hours");

            migrationBuilder.DropForeignKey(
                name: "FK_Hours_TaskAssigns_TaskAssignId",
                table: "Hours");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Hours_HourId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_HourId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Hours_EmployeeTaskId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "HourId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EmployeeTaskId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "HoursWorked",
                table: "Hours");

            migrationBuilder.AlterColumn<int>(
                name: "TaskAssignId",
                table: "Hours",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Hours",
                table: "Hours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Hours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hours_RoleId",
                table: "Hours",
                column: "RoleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_Roles_RoleId",
                table: "Hours",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_TaskAssigns_TaskAssignId",
                table: "Hours",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
