using Microsoft.EntityFrameworkCore.Migrations;

namespace OekakiTradingSite.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalLikes",
                table: "Drawings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalLikes",
                table: "Drawings");
        }
    }
}
