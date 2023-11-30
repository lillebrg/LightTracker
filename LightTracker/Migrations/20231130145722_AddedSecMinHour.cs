using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LightTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedSecMinHour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeOnly",
                table: "LightLogs",
                newName: "Seconds");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "LightLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "LightLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "LightLogs");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "LightLogs");

            migrationBuilder.RenameColumn(
                name: "Seconds",
                table: "LightLogs",
                newName: "TimeOnly");
        }
    }
}
