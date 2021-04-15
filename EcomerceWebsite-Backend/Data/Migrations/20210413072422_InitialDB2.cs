using Microsoft.EntityFrameworkCore.Migrations;

namespace EcomerceWebsite_Backend.Data.Migrations
{
    public partial class InitialDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Comments",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Comments",
                newName: "UserID");
        }
    }
}
