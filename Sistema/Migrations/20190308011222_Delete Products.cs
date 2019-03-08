using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class DeleteProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    MedicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaNacmiento = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.MedicId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductBrandId = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 100, nullable: false),
                    ProductCost = table.Column<decimal>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    ProvidersId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false),
                    TypeProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductBrand_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "ProductBrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Providers_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "Providers",
                        principalColumn: "ProvidersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_TypeProduct_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProduct",
                        principalColumn: "TypeProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductBrandId",
                table: "Product",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProvidersId",
                table: "Product",
                column: "ProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StorageId",
                table: "Product",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeProductId",
                table: "Product",
                column: "TypeProductId");
        }
    }
}
