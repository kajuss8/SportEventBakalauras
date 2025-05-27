using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportEventsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedBoolToFriendListForNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "FriendList",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "FriendList");
        }
    }
}
