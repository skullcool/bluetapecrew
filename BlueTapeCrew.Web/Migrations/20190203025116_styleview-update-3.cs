using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueTapeCrew.Web.Migrations
{
    public partial class styleviewupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_StyleViews_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleViews");

            migrationBuilder.AlterColumn<string>(
                name: "StyleText",
                table: "StyleViews",
                maxLength: 48,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 48);

            migrationBuilder.AlterColumn<string>(
                name: "SizeText",
                table: "StyleViews",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ColorText",
                table: "StyleViews",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StyleText",
                table: "StyleViews",
                maxLength: 48,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 48,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SizeText",
                table: "StyleViews",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ColorText",
                table: "StyleViews",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StyleViews_Id_ProductId_SizeId_SizeOrder_SizeText_ColorId_ColorText_Price_StyleText",
                table: "StyleViews",
                columns: new[] { "Id", "ProductId", "SizeId", "SizeOrder", "SizeText", "ColorId", "ColorText", "Price", "StyleText" });
        }
    }
}
