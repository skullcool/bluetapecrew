using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTapeCrew.Web.Migrations
{
    public partial class removedstyleview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StyleViews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StyleViews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    ColorText = table.Column<string>(maxLength: 25, nullable: true),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false),
                    SizeOrder = table.Column<int>(nullable: false),
                    SizeText = table.Column<string>(maxLength: 20, nullable: true),
                    StyleText = table.Column<string>(maxLength: 48, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleViews", x => x.Id);
                });
        }
    }
}
