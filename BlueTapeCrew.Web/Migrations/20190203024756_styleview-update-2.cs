using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTapeCrew.Web.Migrations
{
    public partial class styleviewupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleView",
                table: "StyleView");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_StyleView_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleView");

            migrationBuilder.RenameTable(
                name: "StyleView",
                newName: "StyleViews");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleViews",
                table: "StyleViews",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StyleViews_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleViews",
                columns: new[] { "Id", "ProductId", "SizeId", "SizeOrder", "SizeText", "ColorId", "ColorText", "Price", "StyleText" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleViews",
                table: "StyleViews");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_StyleViews_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleViews");

            migrationBuilder.RenameTable(
                name: "StyleViews",
                newName: "StyleView");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleView",
                table: "StyleView",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StyleView_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleView",
                columns: new[] { "Id", "ProductId", "SizeId", "SizeOrder", "SizeText", "ColorId", "ColorText", "Price", "StyleText" });
        }
    }
}
