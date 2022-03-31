using Microsoft.EntityFrameworkCore.Migrations;

namespace BookEventApplication.Migrations
{
    public partial class oneCommentColumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserComment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserComment");
        }
    }
}
