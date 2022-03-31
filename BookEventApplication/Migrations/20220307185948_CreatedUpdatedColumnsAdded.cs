using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookEventApplication.Migrations
{
    public partial class CreatedUpdatedColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Event");
        }
    }
}
