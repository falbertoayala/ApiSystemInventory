using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class AddDBProduct2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product2",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductCode = table.Column<string>(maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    ProductCost = table.Column<decimal>(nullable: false),
                    ProductBrandId = table.Column<int>(nullable: false),
                    ProvidersId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false),
                    TypeProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product2", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product2_ProductBrand_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "ProductBrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product2_Providers_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "Providers",
                        principalColumn: "ProvidersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product2_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product2_TypeProduct_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProduct",
                        principalColumn: "TypeProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product2_ProductBrandId",
                table: "Product2",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product2_ProvidersId",
                table: "Product2",
                column: "ProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_Product2_StorageId",
                table: "Product2",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Product2_TypeProductId",
                table: "Product2",
                column: "TypeProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product2");
        }
    }
}
