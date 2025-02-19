using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FidelityApi.Migrations
{
    /// <inheritdoc />
    public partial class LevelColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color1",
                table: "Levels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color2",
                table: "Levels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color1",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "Color2",
                table: "Levels");
        }
    }
}
