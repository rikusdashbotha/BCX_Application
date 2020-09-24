using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BCX_DAL.Migrations
{
    public partial class UpdatedHourWithDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateWorked",
                table: "Hours",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateWorked",
                table: "Hours");
        }
    }
}
