using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class AddObservationRquesitionDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "RequisitionDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observation",
                table: "RequisitionDetail");
        }
    }
}
