using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportEventsApp.Migrations
{
    /// <inheritdoc />
    public partial class modifiedSportLevelAddedEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportsLevels_Sports_SportId",
                table: "SportsLevels");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_SportsLevels_SportId",
                table: "SportsLevels");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "SportsLevels");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "SportsLevels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "SportsLevels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SportsLevels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SportsLevels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "SportsLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SportsLevels_SportId",
                table: "SportsLevels",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsLevels_Sports_SportId",
                table: "SportsLevels",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
