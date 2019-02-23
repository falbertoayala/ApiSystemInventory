using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class NormalizationBdProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductCost",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductCost",
                table: "Product",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
