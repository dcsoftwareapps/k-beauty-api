using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FidelityApi.Migrations
{
    /// <inheritdoc />
    public partial class PointsToNextLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PointsToNextLevel",
                table: "Users",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsToNextLevel",
                table: "Users");
        }
    }
}
