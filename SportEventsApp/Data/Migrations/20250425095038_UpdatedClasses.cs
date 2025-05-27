using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportEventsApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SportsLevels",
                newName: "Sport");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SportsLevels",
                newName: "Level");

            migrationBuilder.AddColumn<bool>(
                name: "IsFemale",
                table: "SportEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMale",
                table: "SportEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Accept",
                table: "Invites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Decline",
                table: "Invites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFemale",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "IsMale",
                table: "SportEvents");

            migrationBuilder.DropColumn(
                name: "Accept",
                table: "Invites");

            migrationBuilder.DropColumn(
                name: "Decline",
                table: "Invites");

            migrationBuilder.RenameColumn(
                name: "Sport",
                table: "SportsLevels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "SportsLevels",
                newName: "Description");
        }
    }
}
