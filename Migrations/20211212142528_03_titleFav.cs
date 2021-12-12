using Microsoft.EntityFrameworkCore.Migrations;

namespace hey_istanbul_backend.Migrations
{
    public partial class _03_titleFav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Favorites",
                type: "text",
                nullable: false,
                defaultValue: "İsimsiz Mekan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Favorites");
        }
    }
}
