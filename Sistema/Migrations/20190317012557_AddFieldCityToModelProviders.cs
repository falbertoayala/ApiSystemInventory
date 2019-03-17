using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class AddFieldCityToModelProviders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Providers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "City",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CityId",
                table: "Providers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CityId1",
                table: "City",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_City_City_CityId1",
                table: "City",
                column: "CityId1",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_City_CityId",
                table: "Providers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_City_CityId1",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_City_CityId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_CityId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_City_CityId1",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "City");
        }
    }
}
