using Microsoft.EntityFrameworkCore.Migrations;

namespace EcomerceWebsite_Backend.Data.Migrations
{
    public partial class InitialDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Comments",
                newName: "Star");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Star",
                table: "Comments",
                newName: "Rating");
        }
    }
}
