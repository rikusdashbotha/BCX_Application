using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class FixedRolesIndex3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskAssigns_TaskAssignId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskAssignId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskAssignId1",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskAssignId1",
                table: "Tasks",
                column: "TaskAssignId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssigns_TaskId",
                table: "TaskAssigns",
                column: "TaskId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_TaskAssigns_TaskId",
                table: "TaskAssigns");

            migrationBuilder.DropColumn(
                name: "TaskAssignId1",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskAssignId",
                table: "Tasks",
                column: "TaskAssignId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskAssigns_TaskAssignId",
                table: "Tasks",
                column: "TaskAssignId",
                principalTable: "TaskAssigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
