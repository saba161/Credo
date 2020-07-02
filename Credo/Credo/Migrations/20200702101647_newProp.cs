using Microsoft.EntityFrameworkCore.Migrations;

namespace Credo.Migrations
{
    public partial class newProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUser",
                table: "Loans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUser",
                table: "Loans");
        }
    }
}
