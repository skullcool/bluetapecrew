using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTapeCrew.Web.Migrations
{
    public partial class styleviewupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleView",
                table: "StyleView");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleView",
                table: "StyleView",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StyleView_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleView",
                columns: new[] { "Id", "ProductId", "SizeId", "SizeOrder", "SizeText", "ColorId", "ColorText", "Price", "StyleText" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleView",
                table: "StyleView");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_StyleView_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleView");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleView",
                table: "StyleView",
                columns: new[] { "Id", "ProductId", "SizeId", "SizeOrder", "SizeText", "ColorId", "ColorText", "Price", "StyleText" });
        }
    }
}
