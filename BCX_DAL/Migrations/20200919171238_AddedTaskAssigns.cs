using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class AddedTaskAssigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TaskAssigns",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskAssigns_Employees_EmployeeId",
                table: "TaskAssigns");

            migrationBuilder.DropIndex(
                name: "IX_TaskAssigns_EmployeeId",
                table: "TaskAssigns");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TaskAssigns");
        }
    }
}
