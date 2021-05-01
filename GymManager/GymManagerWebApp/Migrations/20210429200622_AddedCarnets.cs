using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagerWebApp.Migrations
{
    public partial class AddedCarnets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RemainQty",
                table: "PurchasedCarnets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsedQty",
                table: "PurchasedCarnets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "PurchasedCarnets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "PurchasedCarnets",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedOn",
                table: "PurchasedCarnets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainQty",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "UsedQty",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "PurchasedCarnets");

            migrationBuilder.DropColumn(
                name: "UsedOn",
                table: "PurchasedCarnets");
        }
    }
}
