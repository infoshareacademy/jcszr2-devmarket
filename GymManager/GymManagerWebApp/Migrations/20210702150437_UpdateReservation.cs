using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class UpdateReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "CalendarEvents");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "CalendarEvents",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "CalendarEvents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTime>(
                name: "Hour",
                table: "CalendarEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
