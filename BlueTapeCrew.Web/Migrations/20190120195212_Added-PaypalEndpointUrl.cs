using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTapeCrew.Web.Migrations
{
    public partial class AddedPaypalEndpointUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaypalEndpointUrl",
                table: "SiteSettings",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaypalEndpointUrl",
                table: "SiteSettings");
        }
    }
}
